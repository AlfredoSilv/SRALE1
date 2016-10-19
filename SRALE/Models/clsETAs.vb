Imports System.Data.SqlClient
Imports SRALE.EF.clsContext
Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Namespace SRALE.Models
    'Cria as propriedades privadas de ETAs
    Public Class clsETAs
        Implements IComparer(Of clsETAs)
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
        ''' <summary>
        ''' Permite a ordenação do objeto
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Function Compare(ByVal x As clsETAs, ByVal y As clsETAs) As Integer Implements IComparer(Of clsETAs).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function
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
End Namespace
