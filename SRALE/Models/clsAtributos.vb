Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports OSIsoft.AF.Time

Namespace SRALE.Models
    ''' <summary>
    ''' Cria as propriedades privadas do objeto atributo
    ''' </summary>
    Public Class clsAtributos
        Implements IComparer(Of clsAtributos)
        Private Property _AtributoID As Guid
        Private Property _AtributoNome As String
        Private Property _Grupo As String
        Private Property _Categoria As String
        Private Property _Data As DateTime
        Private Property _Valor As Double
        Private Property _AtributoUOM As String
        ''' <summary>
        ''' Cria as propriedades publicas do objeto atributo
        ''' </summary>
        ''' <returns></returns>
        Public Property AtributoID As Guid
            Get
                Return _AtributoID
            End Get
            Set(value As Guid)
                _AtributoID = value
            End Set
        End Property
        Public Property AtributoNome As String
            Get
                Return _AtributoNome
            End Get
            Set(value As String)
                _AtributoNome = value
            End Set
        End Property
        ''' <summary>
        ''' Cria uma propriedade somente leitura
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Grupo As String
            Get
                _Grupo = Agrupa(AtributoNome)
                Return _Grupo
            End Get
        End Property
        Public Property Categoria As String
            Get
                Return _Categoria
            End Get
            Set(value As String)
                _Categoria = value
            End Set
        End Property
        Public Property Data As DateTime
            Get
                Return _Data
            End Get
            Set(value As DateTime)
                _Data = value
            End Set
        End Property
        Public Property Valor As Double
            Get
                Return _Valor
            End Get
            Set(value As Double)
                _Valor = value
            End Set
        End Property
        Public Property AtributoUOM As String
            Get
                Return _AtributoUOM
            End Get
            Set(value As String)
                _AtributoUOM = value
            End Set
        End Property
        ''' <summary>
        ''' Cria um amétodo new
        ''' </summary>
        Public Sub New()

        End Sub
        ''' <summary>
        ''' Cria uma método new implementado para carregar a classe
        ''' </summary>
        ''' <param name="AtributoID"></param>
        ''' <param name="EtaID"></param>
        ''' <param name="AtributeNome"></param>
        ''' <param name="Categoria"></param>
        ''' <param name="Data"></param>
        ''' <param name="Valor"></param>
        ''' <param name="AtributoUOM"></param>
        Public Sub New(ByVal AtributoID As Guid, ByVal AtributeNome As String, ByVal Categoria As String, ByVal Data As DateTime,
                       ByVal Valor As Double, ByVal AtributoUOM As String)
            Me.AtributoID = AtributoID
            Me.AtributoNome = AtributoNome
            Me.Categoria = Categoria
            Me.Data = Data
            Me.Valor = Valor
            Me.AtributoUOM = AtributoUOM
        End Sub
        ''' <summary>
        ''' Ordena os atributos
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Function Compare(x As clsAtributos, y As clsAtributos) As Integer Implements IComparer(Of clsAtributos).Compare
            Return String.Compare(x.AtributoNome, y.AtributoNome)
        End Function
        ''' <summary>
        ''' Retorna uma grupo para o atributo
        ''' </summary>
        ''' <param name="Nome"></param>
        ''' <returns></returns>
        Public Function Agrupa(ByVal Nome As String) As String
            Dim Grupo As String = Nothing
            Select Case Left(Nome, 2)
                Case "AB"
                    Grupo = "ÁGUA BRUTA"
                Case "AD"
                    Grupo = "ÁGUA DECANTANDA"
                Case "AF"
                    Grupo = "ÁGUA FILTRADA"
                Case "AT"
                    Grupo = "ÁGUA TRATADA"
                Case "DO"
                    Grupo = "DOSADORES"
                Case "QT"
                    Grupo = "CONSUMO"
            End Select
            Return Grupo
        End Function
        ''' <summary>
        ''' Busca os atributos com base no ID da ETA e no intervalo de data
        ''' </summary>
        ''' <param name="IDRoot"></param>
        ''' <param name="dtIni"></param>
        ''' <param name="dtFin"></param>
        ''' <returns></returns>
        Public Function buscaAtibAF(ByVal IDRoot As Guid, ByVal dtIni As String, ByVal dtFin As String) As List(Of clsAtributos)
            If dtIni.ToString = "" Then
                dtIni = Today.AddMinutes(30).ToString("dd/MM/yyyy HH:mm:ss")
            Else
                dtIni += " 00:30:00"
            End If
            If dtFin.ToString = "" Then
                dtFin = Today.AddHours(23).ToString("dd/MM/yyyy HH:mm:ss")
            Else
                dtFin += "23:00:00"
            End If
            Dim myPathRootID As Guid = IDRoot
            Dim myPISystems As New PISystems
            Dim myCom As PISystem = myPISystems.DefaultPISystem
            Dim myDB As AFDatabase = myCom.Databases(My.Settings.myAFdb)
            Dim atributos As AFAttributes
            Dim valor As AFValues
            Dim st As AFTime = New AFTime(dtIni.ToString)
            Dim et As AFTime = New AFTime(dtFin.ToString)
            Dim tr As AFTimeRange = New AFTimeRange(st, et)
            Dim lstAtributos As New List(Of clsAtributos)
            Dim lstAtribSort As New List(Of clsAtributos)
            'A variável attributes, do tipo AFAttributes, recebe os atributos 
            atributos = AFElement.FindElement(myCom, myPathRootID).Attributes
            For Each item As AFAttribute In atributos
                If item.GetValue.IsGood Then
                    If Not item.GetValue.UOM = Nothing Then
                        valor = item.GetValues(tr, 24, item.DefaultUOM)
                        For Each val As AFValue In valor
                            lstAtributos.Add(New clsAtributos(item.ID, item.Name, item.CategoriesString, val.Timestamp.LocalTime, val.Value, item.DefaultUOM.Abbreviation))
                        Next
                    End If
                End If
            Next
            lstAtribSort = lstAtributos
            lstAtribSort.Sort(Function(p1 As clsAtributos, p2 As clsAtributos) p1.AtributoNome.CompareTo(p2.AtributoNome))
            Return lstAtribSort
        End Function
    End Class
End Namespace
