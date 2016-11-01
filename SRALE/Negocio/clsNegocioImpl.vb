Imports SRALE.SRALE.Models

Namespace SRALE.Negocio
    Public Class clsNegocioImpl
        Implements INegocio
        Private Function buscaCoord() As List(Of clsCoord) Implements INegocio.buscaCoordAF
            Dim lstCoord As List(Of clsCoord)
            Dim elementos As New clsElementos
            lstCoord = elementos.CoordAF
            Return lstCoord
        End Function
        Private Function buscaEtas(ByVal ID As Guid) As List(Of clsETAs) Implements INegocio.buscaEtasAF
            Dim lstEtas As List(Of clsETAs)
            Dim elementos As New clsElementos
            lstEtas = elementos.EtasAF
            Return lstEtas
        End Function
        Private Function buscaAtrib(ByVal ID As Guid, ByVal dtIni As String, ByVal dtFin As String) As List(Of clsAtributos) Implements INegocio.buscaAtribAF
            Dim lstAtrib As List(Of clsAtributos)
            Dim Atrib As New clsElementos
            lstAtrib = Atrib.buscaAtibAF(ID, dtIni, dtFin)
            Return lstAtrib
        End Function
    End Class
End Namespace