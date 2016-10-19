Imports System.Data.SqlClient
Namespace SRALE.DAO
    'Cria a classe de conexão ao banco
    Public Class clsConexao
        Private cn As String
        ''' <summary>
        ''' Cria um método vazio.
        ''' </summary>
        Public Sub New()
        End Sub
        ''' <summary>
        ''' Cria um método com string de conexão.
        ''' </summary>
        ''' <param name="strConexao"></param>    '
        Public Sub New(ByVal strConexao As String)
            'Permite que usemos uma string de conexão diferente da padrão.
            cn = strConexao
        End Sub
        ''' <summary>
        ''' Método para fechar a conexão com o banco.
        ''' </summary>
        ''' <param name="con"></param>
        Protected Sub FechaConexao(ByVal con As SqlConnection)
            con.Close()
            con = Nothing
        End Sub
        ''' <summary>
        ''' Cria uma função que recebe a string de conexão e abre a conexão com o banco.
        ''' </summary>
        ''' <returns></returns>
        Protected Function AbreConexao() As SqlConnection
            Dim retCon As SqlConnection
            retCon = New SqlConnection(cn)
            retCon.Open()
            AbreConexao = retCon
        End Function
        ''' <summary>
        ''' Cria uma função sobrecarregada para o dataReader com base na Query e no parâmetros.
        ''' </summary>
        ''' <param name="strSP"></param>
        ''' <param name="cmdParametros"></param>
        ''' <returns></returns>
        Public Overloads Function retornaDataReader(ByVal strSP As String, ByVal ParamArray cmdParametros() _
                            As SqlParameter) As SqlDataReader
            'Obtema string de conexão.
            Dim cn As SqlConnection = AbreConexao()
            Dim dr As SqlDataReader

            'Cria um objeto command a  partir da stored procedure
            Dim cmd As New SqlCommand(strSP, cn)
            cmd.CommandTimeout = 60
            cmd.CommandType = CommandType.StoredProcedure

            Dim par As SqlParameter

            'Percorre a coleção de parametros
            For Each par In cmdParametros
                par = cmd.Parameters.Add(par)
                par.Direction = ParameterDirection.Input
            Next

            'Executa o comando e retorna o datareader.
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            cmd.Dispose()
            Return dr
        End Function
        ''' <summary>
        ''' Cria uma função sobrecarregada para o dataReader com base na Query.
        ''' </summary>
        ''' <param name="strSP"></param>
        ''' <returns></returns>
        Public Overloads Function retornaDataReader(ByVal strSP As String) As SqlDataReader
            'Obtem a conexão.
            Dim cn As SqlConnection = AbreConexao()
            Dim dr As SqlDataReader

            'Cria o objeto command a partir da stored Procedure.
            Dim cmd As New SqlCommand(strSP, cn)
            cmd.CommandTimeout = 60
            cmd.CommandType = CommandType.Text

            'Executa o comando.
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            cmd.Dispose()

            'Retorna o datareader.
            Return dr
        End Function
    End Class
End Namespace