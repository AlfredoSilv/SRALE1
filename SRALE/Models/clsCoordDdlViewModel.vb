﻿Namespace SRALE.Models
    Public Class clsCoordDdlViewModel
        Private Property _ElementID As Guid
        Private Property _ListCoord As List(Of clsCoord)
        Public Property ElementID As Guid
            Get
                Return _ElementID
            End Get
            Set(value As Guid)
                _ElementID = value
            End Set
        End Property
        Public Property ListCoord As List(Of clsCoord)
            Get
                Return _ListCoord
            End Get
            Set(value As List(Of clsCoord))
                _ListCoord = value
            End Set
        End Property
    End Class
End Namespace