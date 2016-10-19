Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsETAsViewModel
        Private Property _DropDownCPRViewModel As clsDropDownCPRViewModel
        Private Property _DropDownETAViewModel As clsDropDownETAsViewModel
        Private Property _ListaETASelecionada As List(Of Guid)
        Private Property _ListaETADisponivel As List(Of clsETAs)
        Public Property DropDownCPRViewModel As clsDropDownCPRViewModel
            Get
                Return _DropDownCPRViewModel
            End Get
            Set(value As clsDropDownCPRViewModel)
                _DropDownCPRViewModel = value
            End Set
        End Property
        Public Property DropDownETAViewModel As clsDropDownETAsViewModel
            Get
                Return _DropDownETAViewModel
            End Get
            Set(value As clsDropDownETAsViewModel)
                _DropDownETAViewModel = value
            End Set
        End Property
        Public Property ListaETASelecionada As List(Of Guid)
            Get
                Return _ListaETASelecionada
            End Get
            Set(value As List(Of Guid))
                _ListaETASelecionada = value
            End Set
        End Property
        Public Property ListaETADisponivel As List(Of clsETAs)
            Get
                Return _ListaETADisponivel
            End Get
            Set(value As List(Of clsETAs))
                _ListaETADisponivel = value
            End Set
        End Property
        Public Sub New()
            DropDownCPRViewModel = New clsDropDownCPRViewModel()
            DropDownETAViewModel = New clsDropDownETAsViewModel()
            ListaETASelecionada = New List(Of Guid)
            ListaETADisponivel = New List(Of clsETAs)
        End Sub
    End Class
End Namespace

