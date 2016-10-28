Imports System.Data.SqlClient
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports SRALE.SRALE.DAO
Namespace SRALE.Models
    ''' <summary>
    ''' Cria as propriedades privadas de Coordenações.
    ''' </summary>
    <Serializable>
    Public Class clsCoord
        Implements IComparer(Of clsCoord)
        Private Property _ElementID As Guid
        Private Property _Nome As String
        Private Property _lstEta As List(Of clsETAs)
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
        Public Property lstEta As List(Of clsETAs)
            Get
                Return _lstEta
            End Get
            Set(value As List(Of clsETAs))
                _lstEta = value
            End Set
        End Property
        ''' <summary>
        ''' Cria um amétodo new
        ''' </summary>
        Public Sub New()

        End Sub
        ''' <summary>
        ''' Cria uma método new implementado para carregar a classe.
        ''' </summary>
        ''' <param name="ElemnentId"></param>
        ''' <param name="Nome"></param>
        ''' <param name="lsEta"></param>
        Public Sub New(ByVal ElemnentId As Guid, ByVal Nome As String, ByVal lsEta As List(Of clsETAs))
            Me.ElementID = ElementID
            Me.Nome = Nome
            Me.lstEta = lsEta
        End Sub

        Public Function Compare(x As clsCoord, y As clsCoord) As Integer Implements IComparer(Of clsCoord).Compare
            Return String.Compare(x.Nome, y.Nome)
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
