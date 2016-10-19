Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsListSelectETAsViewModel
        Private Property _etaSelecionada As List(Of [String])
        Private Property _etaDisponivel As List(Of clsETAs)
        Public Property ETASelecionada As List(Of [String])
            Get
                Return _etaSelecionada
            End Get
            Set(value As List(Of [String]))
                _etaSelecionada = value
            End Set
        End Property
        Public Property ETADisponivel As List(Of clsETAs)
            Get
                Return _etaDisponivel
            End Get
            Set(value As List(Of clsETAs))
                _etaDisponivel = value
            End Set
        End Property
    End Class
End Namespace

