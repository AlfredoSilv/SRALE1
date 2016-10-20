Imports SRALE.SRALE.Models

Namespace SRALE.Negocio
    Public Interface INegocio
        Function buscaCoordAF() As List(Of clsCoord)
        Function buscaEtasAF(ByVal ID As Guid) As List(Of clsETAs)
        Function buscaAtribAF(ByVal ID As Guid, ByVal dtIni As String, ByVal dtFin As String) As List(Of clsAtributos)
    End Interface
End Namespace