Imports System.Data.SqlClient
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Namespace EF
    'Cria uma classe herdada de DBContext
    Public Class clsContext
        Inherits DbContext
        'Cria as propriedade privadas tipo DBSet para as classes CPR e ETAs
        Private Property _CPR() As DbSet(Of clsETAs)
        Private _ETAs As DbSet(Of clsETAs)
        'Cria as propriedade públicas tipo DBSet para as classes CPR e ETAs
        Public Property CPR() As DbSet(Of clsETAs)
            Get
                Return _CPR
            End Get
            Set(value As DbSet(Of clsETAs))
                _CPR = value
            End Set
        End Property
        Public Property ETAs() As DbSet(Of clsETAs)
            Get
                Return _ETAs
            End Get
            Set(value As DbSet(Of clsETAs))
                _ETAs = value
            End Set
        End Property
        'Remove a pluralização na criação dos modelos das tabelas
        Protected Overrides Sub OnModelCreating(dbModelBuilder As DbModelBuilder)
            dbModelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        End Sub
    End Class
End Namespace
'Cria a classe CPR
Public Class clsCPR
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
    Public Shared Function buscaAF() As List(Of clsCPR)
        Dim myPISystems As New PISystems
        Dim myCom As PISystem = myPISystems.DefaultPISystem
        Dim myDB As AFDatabase = myCom.Databases("Compesa")
        Dim listaCPR As AFElements
        '6aef0129-c77d-4828-98cc-3f80e059183e > ElementID do \PORTAL COOPERAÇÃO\RELATÓRIO DE QUALIDADE DA ÁGUA\
        Dim myPathRootID As Guid = New Guid("6aef0129-c77d-4828-98cc-3f80e059183e")
        listaCPR = AFElement.FindElement(myCom, myPathRootID).Elements
        Dim CPR As New clsCPR()
        Dim retorno As New List(Of clsCPR)
        For Each item As AFElement In listaCPR
            CPR.ElementID = item.ID
            CPR.Nome = item.Name
            retorno.Add(CPR)
        Next
        Return retorno
    End Function
    Public Shared Function buscarCPRSQL() As List(Of clsCPR)
        Dim conn As SqlConnection = Nothing
        Dim commad As SqlCommand = Nothing
        Dim dataReader As SqlDataReader = Nothing
        Try
            conn = New SqlConnection(SRALE.DAO.clsUtilDAO.connectionString)
            conn.Open()
            Dim sql As [String] = "SELECT cpr_ElementID, cpr_Nome FROM SRALE.dbo.tb_Coordenacao"
            commad = New SqlCommand(sql, conn)
            dataReader = commad.ExecuteReader()
            Dim retorno As New List(Of clsCPR)
            While dataReader.Read()
                Dim CPR As New clsCPR()
                CPR.ElementID = Guid.Parse(dataReader("cpr_ElementID").ToString)
                CPR.Nome = dataReader("cpr_Nome").ToString
                retorno.Add(CPR)
            End While
            Return retorno
        Finally
            If dataReader IsNot Nothing Then
                dataReader.Close()
            End If

            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try

    End Function
    Public Function criarCPRViewModel(ByVal listaCPR As List(Of clsCPR)) As SRALE.Models.Modelos.clsCPRViewModel
        Dim CPRViewModel As New SRALE.Models.Modelos.clsCPRViewModel()
        If listaCPR Is Nothing Then
            Return CPRViewModel
        End If

        Dim retorno As New StringBuilder()
        Dim listaCPRCadastrada As List(Of clsCPR) = buscaAF()

        Dim listGuiID As New List(Of Guid)

        For Each CPRCadastrada As clsCPR In listaCPRCadastrada
            If listaCPR.IndexOf(CPRCadastrada) >= 0 Then
                listGuiID.Add(CPRCadastrada.ElementID)
            End If
        Next

        CPRViewModel.CPRDisponivel = listaCPR
        CPRViewModel.CPRSelecionada = listGuiID

        Return CPRViewModel
    End Function

End Class
'Cria as propriedades privadas de ETAs
Public Class clsETAs
    Private Property _ElementID As Guid
    Private Property _ParentID As Guid
    Private Property _Nome As String
    'Cria as propriedades públicas de ETAs
    Public Property ElementID As Guid
        Get
            Return _ElementID
        End Get
        Set(value As Guid)
            _ElementID = value
        End Set
    End Property
    Public Property ParentID As Guid
        Get
            Return _ParentID
        End Get
        Set(value As Guid)
            _ParentID = value
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
    Public Sub New()

    End Sub
    Public Sub New(ByVal ElemnentId As Guid, ByVal ParentID As Guid, ByVal Nome As String)
        Me.ElementID = ElementID
        Me.ParentID = ParentID
        Me.Nome = Nome
    End Sub
    'Cria uma função para armazenar uma coleção de ETas
    Public Function buscaETAAF(ByVal IDRoot As Guid) As List(Of clsETAs)
        Dim myPathRootID As Guid = IDRoot
        Dim myPISystems As New PISystems
        Dim myCom As PISystem = myPISystems.DefaultPISystem
        Dim myDB As AFDatabase = myCom.Databases("Compesa")
        Dim listelements As AFElements
        Dim ETAs As clsETAs
        Dim cont As Integer = 0
        Dim listEtas As New List(Of clsETAs)

        'Procura os elementos filhos com base no ID do Path Root (myPathRootID).
        listelements = AFElement.FindElement(myCom, myPathRootID).Elements
        For Each eta As AFElement In listelements
            ETAs = New clsETAs(eta.ID, eta.Parent.ID, eta.Name)
            listEtas.Add(ETAs)
            cont += 1
        Next
        Return listEtas
    End Function
End Class
Public Class clsQuimica
    Implements IComparer(Of clsQuimica)
    Private Property _IDEta As Guid
    Private Property _Data As DateTime
    Private Property _Nome As String
    Private Property _Valor As Decimal
    Private Property _UOM As String
    Public Property IDEta As Guid
        Get
            Return _IDEta
        End Get
        Set(value As Guid)
            _IDEta = value
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
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _Valor
        End Get
        Set(value As Decimal)
            _Valor = value
        End Set
    End Property
    Public Property UOM As String
        Get
            Return _UOM
        End Get
        Set(value As String)
            _UOM = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
        Me.IDEta = IDEta
        Me.Data = Data
        Me.Nome = Nome
        Me.Valor = Valor
        Me.UOM = UOM
    End Sub
    Public Function Compare(ByVal x As clsQuimica, ByVal y As clsQuimica) As Integer _
       Implements System.Collections.Generic.IComparer(Of clsQuimica).Compare
        Return String.Compare(x.Nome, y.Nome)
    End Function
End Class
Public Class clsMetal
    Implements IComparer(Of clsMetal)
    Private Property _IDEta As Guid
    Private Property _Data As DateTime
    Private Property _Nome As String
    Private Property _Valor As Decimal
    Private Property _UOM As String
    Public Property IDEta As Guid
        Get
            Return _IDEta
        End Get
        Set(value As Guid)
            _IDEta = value
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
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _Valor
        End Get
        Set(value As Decimal)
            _Valor = value
        End Set
    End Property
    Public Property UOM As String
        Get
            Return _UOM
        End Get
        Set(value As String)
            _UOM = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
        Me.IDEta = IDEta
        Me.Data = Data
        Me.Nome = Nome
        Me.Valor = Valor
        Me.UOM = UOM
    End Sub
    Public Function Compare(ByVal x As clsMetal, ByVal y As clsMetal) As Integer _
      Implements System.Collections.Generic.IComparer(Of clsMetal).Compare
        Return String.Compare(x.Nome, y.Nome)
    End Function
End Class
Public Class clsDosador
    Implements IComparer(Of clsDosador)
    Private Property _IDEta As Guid
    Private Property _Data As DateTime
    Private Property _Nome As String
    Private Property _Valor As Decimal
    Private Property _UOM As String
    Public Property IDEta As Guid
        Get
            Return _IDEta
        End Get
        Set(value As Guid)
            _IDEta = value
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
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _Valor
        End Get
        Set(value As Decimal)
            _Valor = value
        End Set
    End Property
    Public Property UOM As String
        Get
            Return _UOM
        End Get
        Set(value As String)
            _UOM = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
        Me.IDEta = IDEta
        Me.Data = Data
        Me.Nome = Nome
        Me.Valor = Valor
        Me.UOM = UOM
    End Sub
    Public Function Compare(ByVal x As clsDosador, ByVal y As clsDosador) As Integer _
     Implements System.Collections.Generic.IComparer(Of clsDosador).Compare
        Return String.Compare(x.Nome, y.Nome)
    End Function
End Class
Public Class clsConsumo
    Implements IComparer(Of clsConsumo)
    Private Property _IDEta As Guid
    Private Property _Data As DateTime
    Private Property _Nome As String
    Private Property _Valor As Decimal
    Private Property _UOM As String
    Public Property IDEta As Guid
        Get
            Return _IDEta
        End Get
        Set(value As Guid)
            _IDEta = value
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
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _Valor
        End Get
        Set(value As Decimal)
            _Valor = value
        End Set
    End Property
    Public Property UOM As String
        Get
            Return _UOM
        End Get
        Set(value As String)
            _UOM = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
        Me.IDEta = IDEta
        Me.Data = Data
        Me.Nome = Nome
        Me.Valor = Valor
        Me.UOM = UOM
    End Sub
    Public Function Compare(ByVal x As clsConsumo, ByVal y As clsConsumo) As Integer _
     Implements System.Collections.Generic.IComparer(Of clsConsumo).Compare
        Return String.Compare(x.Nome, y.Nome)
    End Function
End Class
'Cria a classe de conexão ao banco
Public Class clsConexao
    'Cria um método vazio.
    Public Sub New()
    End Sub
    Private cn As String
    'Cria um método com string de conexão.
    Public Sub New(ByVal strConexao As String)
        'Permite que usemos uma string de conexão diferente da padrão.
        cn = strConexao
    End Sub
    'Método para fechar a conexão com o banco.
    Protected Sub FechaConexao(ByVal con As SqlConnection)
        con.Close()
        con = Nothing
    End Sub
    'Cria uma função que recebe a string de conexão e abre a conexão com o banco.
    Protected Function AbreConexao() As SqlConnection
        Dim retCon As SqlConnection
        retCon = New SqlConnection(cn)
        retCon.Open()
        AbreConexao = retCon
    End Function
    'Cria uma função sobrecarregada para o dataReader com base na Query e no parâmetros.
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
    'Cria uma função sobrecarregada para o dataReader com base na Query.
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
