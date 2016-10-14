Imports System.Collections.Generic
Imports SRALE.clsCPR
Namespace SRALE.Models.Modelos
    <Serializable>
    Public Class clsDropDownCPRViewModel
        Private Property _guid As Guid
        Private Property _lista As List(Of clsCPR)
        Public Property IdGuid As Guid
            Get
                Return _guid
            End Get
            Set(value As Guid)
                _guid = value
            End Set
        End Property
        Public Property Lista As List(Of clsCPR)
            Get
                Return _lista
            End Get
            Set(value As List(Of clsCPR))
                _lista = value
            End Set
        End Property
    End Class
End Namespace


