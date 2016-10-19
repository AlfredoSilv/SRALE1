Imports System.Data.SqlClient
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Namespace SRALE.Models
    'Cria a classe CPR
    Public Class clsCoord
        Implements IComparer(Of clsCoord)
        'Cria as propriendade privadas de CPR
        Private Property _ElementID As Guid
        Private Property _Nome As String
        'Cria as propriedades públicas de CPR
        Public Property Nome As String
            Get
                Return _Nome
            End Get
            Set(value As String)
                _Nome = value
            End Set
        End Property
        Public Property ElementID As Guid
            Get
                Return _ElementID
            End Get
            Set(value As Guid)
                _ElementID = value
            End Set
        End Property
        Public Sub New()

        End Sub
        Public Sub New(ByVal Nome As String, ByVal ElementID As Guid)
            Me.Nome = Nome
            Me.ElementID = ElementID
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
        Public Shared Function buscaAF() As List(Of clsCoord)
            Dim myPISystems As New PISystems
            Dim myCom As PISystem = myPISystems.DefaultPISystem
            Dim myDB As AFDatabase = myCom.Databases(My.Settings.myAFdb)
            Dim listaCPR As AFElements
            'My.Settings.myAFRootID > ElementID do \PORTAL COOPERAÇÃO\RELATÓRIO DE QUALIDADE DA ÁGUA\
            Dim myPathRootID As Guid = My.Settings.myAFRootID
            listaCPR = AFElement.FindElement(myCom, myPathRootID).Elements
            Dim CPR As New clsCoord()
            Dim retorno As New List(Of clsCoord)
            For Each item As AFElement In listaCPR
                CPR.ElementID = item.ID
                CPR.Nome = item.Name
                retorno.Add(CPR)
            Next
            Return retorno
        End Function
        ''' <summary>
        ''' Função que busca as Coordenações no SQL
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function buscarCPRSQL() As List(Of clsCoord)
            Dim conn As SqlConnection = Nothing
            Dim commad As SqlCommand = Nothing
            Dim dataReader As SqlDataReader = Nothing
            Try
                conn = New SqlConnection(My.Settings.strCon)
                conn.Open()
                Dim sql As New StringBuilder
                sql.Append("SELECT cpr_ElementID, cpr_Nome FROM SRALE.dbo.tb_Coordenacao ORDER BY cpr_Nome")
                commad = New SqlCommand(sql.ToString, conn)
                dataReader = commad.ExecuteReader()
                Dim retorno As New List(Of clsCoord)
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
                If dataReader IsNot Nothing Then
                    dataReader.Close()
                    conn.Close()
                    commad.Dispose()
                End If

                If conn IsNot Nothing Then
                    conn.Close()
                    commad.Dispose()
                End If
            End Try
        End Function
        ''' <summary>
        ''' Método de inserção de Coordenada na base Sql
        ''' </summary>
        ''' <param name="ElementId"></param>
        ''' <param name="ElemnetName"></param>
        Public Sub insCoordSql(ByVal ElementId As Guid, ByVal ElemnetName As String)
            Dim conn As SqlConnection = Nothing
            Dim commad As SqlCommand = Nothing
            Try
                conn = New SqlConnection(My.Settings.strCon)
                conn.Open()
                Dim sql As New StringBuilder
                sql.Append("INSERT INTO [dbo].[tb_Coordenacao] ")
                sql.Append("([cpr_ElementID] ")
                sql.Append(",[cpr_Nome]) ")
                sql.Append("VALUES ")
                sql.Append("('" & ElementId.ToString & "', ")
                sql.Append("'" & ElemnetName & "'")
                commad = New SqlCommand(sql.ToString, conn)
                commad.ExecuteNonQuery()
                conn.Close()
                commad.Dispose()
            Catch ex As SqlException
            Finally
            End Try
        End Sub
    End Class

End Namespace
