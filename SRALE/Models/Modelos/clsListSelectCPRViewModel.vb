Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsListSelectCPRViewModel
        Private Property _cprSelecionada As List(Of [String])
        Private Property _cprDisponivel As List(Of clsCPR)
        Public Property CPRSelecionada As List(Of [String])
            Get
                Return _cprSelecionada
            End Get
            Set(value As List(Of [String]))
                _cprSelecionada = value
            End Set
        End Property
        Public Property CPRDisponivel As List(Of clsCPR)
            Get
                Return _cprDisponivel
            End Get
            Set(value As List(Of clsCPR))
                _cprDisponivel = value
            End Set
        End Property
    End Class
End Namespace

