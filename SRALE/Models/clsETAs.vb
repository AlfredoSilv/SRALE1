Imports System.Data.SqlClient
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Namespace SRALE.Models
    ''' <summary>
    ''' Cria as propriedades privadas de ETAs
    ''' </summary>
    Public Class clsETAs
        Implements IComparer(Of clsETAs)
        Private Property _ElementID As Guid
        Private Property _ParentID As Guid
        Private Property _Nome As String
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
        ''' <summary>
        ''' Cria um amétodo new
        ''' </summary>
        Public Sub New()

        End Sub
        ''' <summary>
        ''' Cria uma método new implementado para carregar a classe
        ''' </summary>
        ''' <param name="ElemnentId"></param>
        ''' <param name="ParentID"></param>
        ''' <param name="Nome"></param>
        Public Sub New(ByVal ElemnentId As Guid, ByVal ParentID As Guid, ByVal Nome As String)
            Me.ElementID = ElementID
            Me.ParentID = ParentID
            Me.Nome = Nome
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
        ''' <summary>
        ''' Cria uma função para armazenar uma coleção de ETas
        ''' </summary>
        ''' <param name="IDRoot"></param>
        ''' <returns></returns>
        Public Function buscaETAAF(ByVal IDRoot As Guid) As List(Of clsETAs)
            Dim myPathRootID As Guid = IDRoot
            Dim myPISystems As New PISystems
            Dim myCom As PISystem = myPISystems.DefaultPISystem
            Dim myDB As AFDatabase = myCom.Databases(My.Settings.myAFdb)
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
        ''' <summary>
        ''' Método de inserção de ETAs na base Sql
        ''' </summary>
        ''' <param name="ElementID"></param>
        ''' <param name="ParentID"></param>
        ''' <param name="ElementName"></param>
        Public Sub insETAs(ByVal ElementID As Guid, ByVal ParentID As Guid, ByVal ElementName As String)
            Dim conn As SqlConnection = Nothing
            Dim commad As SqlCommand = Nothing
            Try
                conn = New SqlConnection(My.Settings.strCon)
                conn.Open()
                Dim sql As New StringBuilder
                sql.Append("INSERT INTO [dbo].[tb_ETAs] ")
                sql.Append("([eta_ElementID] ")
                sql.Append(",[eta_ParentID] ")
                sql.Append(",[eta_Nome]) ")
                sql.Append("VALUES ")
                sql.Append("('" & ElementID.ToString & "', ")
                sql.Append("('" & ParentID.ToString & "', ")
                sql.Append("'" & ElementName & "'")
                commad = New SqlCommand(sql.ToString, conn)
                commad.ExecuteNonQuery()
                conn.Close() '
                commad.Dispose()
            Catch ex As SqlException
            Finally
            End Try
        End Sub
    End Class
End Namespace
