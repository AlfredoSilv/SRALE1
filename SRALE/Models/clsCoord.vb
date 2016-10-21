Imports System.Data.SqlClient
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports SRALE.SRALE.DAO
Namespace SRALE.Models
    ''' <summary>
    ''' Cria a classe CPR
    ''' </summary>
    Public Class clsCoord
        Implements IComparer(Of clsCoord)
        'Cria as propriendade privadas de CPR
        Private Property _ElementID As Guid
        Private Property _Nome As String
        Private Property _ListaEta As List(Of clsETAs)
        'Cria as propriedades públicas de CPR
        Public Property ElementID As Guid
            Get
                Return _ElementID
            End Get
            Set(value As Guid)
                _ElementID = value
            End Set
        End Property
        Public Property Nome As String
            Get
                Return _Nome
            End Get
            Set(value As String)
                _Nome = value
            End Set
        End Property
        Public Property ListaEta As List(Of clsETAs)
            Get
                Return _ListaEta
            End Get
            Set(value As List(Of clsETAs))
                _ListaEta = value
            End Set
        End Property
        ''' <summary>
        ''' Cria uma metódo new
        ''' </summary>
        Public Sub New()

        End Sub
        ''' <summary>
        ''' Cria um método new implementado para carregar a classe
        ''' </summary>
        ''' <param name="Nome"></param>
        ''' <param name="ElementID"></param>
        Public Sub New(ByVal ElementID As Guid, ByVal Nome As String, ByVal ListaEtas As List(Of clsETAs))
            Me.ElementID = ElementID
            Me.Nome = Nome
            Me.ListaEta = ListaEta
        End Sub
        ''' <summary>
        ''' Permite a ordenação do objeto
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Function Compare(ByVal x As clsCoord, ByVal y As clsCoord) As Integer Implements IComparer(Of clsCoord).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function
        ''' <summary>
        ''' Função que busca as Coordenações no AF
        ''' </summary>
        ''' <returns></returns>
        Public Function buscaAF() As List(Of clsCoord)
            Dim myPISystems As New PISystems
            Dim myCom As PISystem = myPISystems.DefaultPISystem
            Dim myDB As AFDatabase = myCom.Databases(My.Settings.myAFdb)
            Dim listaCPR As AFElements
            'My.Settings.myAFRootID > ElementID do \PORTAL COOPERAÇÃO\RELATÓRIO DE QUALIDADE DA ÁGUA\
            Dim myPathRootID As Guid = My.Settings.myAFRootID
            listaCPR = AFElement.FindElement(myCom, myPathRootID).Elements
            Dim CPR As New clsCoord()
            Dim retorno As New List(Of clsCoord)
            Dim ETA As New clsETAs
            For Each item As AFElement In listaCPR
                CPR = New clsCoord(item.ID, item.Name, ETA.buscaETAAF(item.ID))
                retorno.Add(CPR)
            Next
            Return retorno
        End Function
        ''' <summary>
        ''' Função que busca as Coordenações no SQL
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function buscarCPRSQL() As List(Of clsCoord)
            Dim conexao As New clsConexao(My.Settings.strCon)
            Dim sql As New StringBuilder
            sql.Append("SELECT cpr_ElementID, cpr_Nome FROM SRALE.dbo.tb_Coordenacao ORDER BY cpr_Nome")
            Dim dataReader As SqlDataReader = conexao.retornaDataReader(sql.ToString)
            Dim retorno As New List(Of clsCoord)
            Try
                If dataReader.HasRows Then
                    While dataReader.Read()
                        Dim CPR As New clsCoord()
                        CPR.ElementID = Guid.Parse(dataReader("cpr_ElementID").ToString)
                        CPR.Nome = dataReader("cpr_Nome").ToString
                        retorno.Add(CPR)
                    End While
                End If

                Return retorno
            Finally
            End Try
        End Function
        ''' <summary>
        ''' Método de inserção de Coordenada na base Sql
        ''' </summary>
        ''' <param name="ElementId"></param>
        ''' <param name="ElementName"></param>
        ''' <param name="cmdParam"></param>
        Public Sub insCoordSql(ByVal ElementId As Guid, ByVal ElementName As String, ByVal ParamArray cmdParam() As SqlParameter)
            Dim conexao As New clsConexao(My.Settings.strCon)
            Dim sql As New StringBuilder
            cmdParam(0).Value = ElementId.ToString
            cmdParam(1).Value = ElementName.ToString
            sql.Append("INSERT INTO [dbo].[tb_Coordenacao] ")
            sql.Append("([cpr_ElementID] ")
            sql.Append(",[cpr_Nome]) ")
            sql.Append("VALUES ")
            sql.Append("(@cpr_ElementID, @ElementName)")
            Try
                conexao.insertDados(sql.ToString, cmdParam)
            Catch ex As SqlException
            Finally
            End Try
        End Sub
    End Class
End Namespace
