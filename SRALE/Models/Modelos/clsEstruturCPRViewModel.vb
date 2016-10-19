Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsEstruturCPRViewModel
        Private Property _ElementID As Guid
        Private Property _ListaCpr As List(Of clsCPR)
        Public Property ElementID As Guid
            Get
                Return _ElementID
            End Get
            Set(value As Guid)
                _ElementID = value
            End Set
        End Property
        Public Property ListaCpr As List(Of clsCPR)
            Get
                Return _ListaCpr
            End Get
            Set(value As List(Of clsCPR))
                _ListaCpr = value
            End Set
        End Property
    End Class
End Namespace
