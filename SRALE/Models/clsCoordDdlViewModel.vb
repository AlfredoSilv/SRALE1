Namespace SRALE.Models
    Public Class clsCoordDdlViewModel
        'Public Property SelectedItems As IEnumerable(Of String)
        'Public Property SelectedItem As String
        'Public Property Items As IEnumerable(Of SelectListItem)
        Private Property _ElementID As Guid
        Private Property _ElementNome As String
        Public Property ElementID As Guid
            Get
                Return _ElementID
            End Get
            Set(value As Guid)
                _ElementID = value
            End Set
        End Property
        Public Property ElementNome As String
            Get
                Return _ElementNome
            End Get
            Set(value As String)
                _ElementNome = value
            End Set
        End Property
        Public Function ListCoord() As List(Of clsCoord)
            Dim elemento As New clsElementos
            Dim lstcoord As New List(Of clsCoord)
            lstcoord = elemento.buscaCoordAF
            Return lstcoord
        End Function

    End Class
End Namespace
