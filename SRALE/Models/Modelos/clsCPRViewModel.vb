Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsCPRViewModel
        Private Property _CPRSelecionada As List(Of Guid)
        Private Property _CPRDisponivel As List(Of clsCPR)
        Public Property CPRSelecionada As List(Of Guid)
            Get
                Return _CPRSelecionada
            End Get
            Set(value As List(Of Guid))
                _CPRSelecionada = value
            End Set
        End Property
        Public Property CPRDisponivel As List(Of clsCPR)
            Get
                Return _CPRDisponivel
            End Get
            Set(value As List(Of clsCPR))
                _CPRDisponivel = value
            End Set
        End Property
    End Class
End Namespace

