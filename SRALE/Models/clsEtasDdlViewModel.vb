Namespace SRALE.Models
    Public Class clsEtasDdlViewModel
        Private Property _ElementId As Guid
        Private Property _ListEtas As List(Of clsETAs)
        Public Property ElementId As Guid
            Get
                Return _ElementId
            End Get
            Set(value As Guid)
                _ElementId = value
            End Set
        End Property
        Public Property ListEtas As List(Of clsETAs)
            Get
                Return _ListEtas
            End Get
            Set(value As List(Of clsETAs))
                _ListEtas = value
            End Set
        End Property
    End Class
End Namespace
