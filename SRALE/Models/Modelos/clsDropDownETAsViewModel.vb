Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsDropDownETAsViewModel
        Private Property _guid As Guid
        Private Property _lista As List(Of clsETAs)
        Public Property IdGuid As Guid
            Get
                Return _guid
            End Get
            Set(value As Guid)
                _guid = value
            End Set
        End Property
        Public Property Lista As List(Of clsETAs)
            Get
                Return _lista
            End Get
            Set(value As List(Of clsETAs))
                _lista = value
            End Set
        End Property
    End Class
End Namespace


