Imports System.Data.SqlClient
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports SRALE.SRALE.DAO
Namespace SRALE.Models
    ''' <summary>
    ''' Cria as propriedades privadas de ETAs.
    ''' </summary>
    <Serializable>
    Public Class clsETAs
        Implements IComparer(Of clsETAs)
        Private Property _ElementID As Guid
        Private Property _Nome As String
        Private Property _lstAtrib As List(Of clsAtributos)
        ''' <summary>
        ''' Cria as propriedades públicas de ETAs
        ''' </summary>
        ''' <returns></returns>
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
        Public Property lstAtrib As List(Of clsAtributos)
            Get
                Return _lstAtrib
            End Get
            Set(value As List(Of clsAtributos))
                _lstAtrib = value
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
        ''' <param name="ElemnentId"></param>
        ''' <param name="Nome"></param>
        ''' <param name="lstAtrib"></param>
        Public Sub New(ByVal ElemnentId As Guid, ByVal Nome As String, ByVal lstAtrib As List(Of clsAtributos))
            Me.ElementID = ElementID
            Me.Nome = Nome
            Me.lstAtrib = lstAtrib
        End Sub
        ''' <summary>
        ''' Permite a ordenação do objeto
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Function Compare(ByVal x As clsETAs, ByVal y As clsETAs) As Integer Implements IComparer(Of clsETAs).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function

        '''' <summary>
        '''' Função que busca as ETAs no SQL
        '''' </summary>
        '''' <returns></returns>
        'Public Shared Function buscarEtasSQL() As List(Of clsETAs)
        '    Dim conexao As New clsConexao(My.Settings.strCon)
        '    Dim sql As New StringBuilder
        '    sql.Append("SELECT eta_ElementID, eta_Nome FROM dbo.tb_ETAs ORDER BY eta_Nome")
        '    Dim dataReader As SqlDataReader = conexao.retornaDataReader(sql.ToString)
        '    Dim retorno As New List(Of clsETAs)
        '    Try
        '        If dataReader.HasRows Then
        '            While dataReader.Read()
        '                Dim ETA As New clsETAs()
        '                ETA.ElementID = Guid.Parse(dataReader("eta_ElementID").ToString)
        '                ETA.Nome = dataReader("eta_Nome").ToString
        '                retorno.Add(ETA)
        '            End While
        '        End If
        '        Return retorno
        '    Finally
        '    End Try
        'End Function
        '''' <summary>
        '''' Método de inserção de ETAs na base Sql
        '''' </summary>
        '''' <param name="ElementID"></param>
        '''' <param name="ElementName"></param>
        '''' <param name="cmdParam"></param>
        'Public Sub insETAsSql(ByVal ElementID As Guid, ByVal ElementName As String, ByVal ParamArray cmdParam() As SqlParameter)
        '    Dim conexao As New clsConexao(My.Settings.strCon)
        '    Dim sql As New StringBuilder
        '    cmdParam(0).Value = ElementID.ToString
        '    cmdParam(1).Value = ElementName.ToString
        '    sql.Append("INSERT INTO [dbo].[tb_ETAs] ")
        '    sql.Append("([eta_ElementID] ")
        '    sql.Append(",[eta_Nome]) ")
        '    sql.Append("VALUES ")
        '    sql.Append("(@ElementID, ")
        '    sql.Append("@ElementName")
        '    Try
        '        conexao.insertDados(sql.ToString, cmdParam)
        '    Catch ex As SqlException
        '    Finally
        '    End Try
        'End Sub
    End Class
End Namespace
