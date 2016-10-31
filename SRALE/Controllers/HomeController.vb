Imports SRALE.SRALE.Models
Namespace SRALE.Controller
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
        Public Function Index() As ActionResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"

            'Return RedirectToAction("Index", "Home")
            Return View()
        End Function

        <HttpGet>
        Public Function Inicio() As PartialViewResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            Dim model As New clsCoordDdlViewModel
            Dim coord As New clsElementos
            Dim lstCoord As New List(Of clsCoord)
            lstCoord = coord.buscaEtaAF
            For Each item As clsCoord In lstCoord
                With model
                    .Items =
                        {
                            New SelectListItem With {.Value = item.ElementID.ToString, .Text = item.Nome}
                        }
                End With
            Next

            'model.ListCoord = lstCoord
            Return PartialView(model)
        End Function

        Function About() As ActionResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            Return View()
        End Function

        Function Contact() As ActionResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            Return View()
        End Function
    End Class
End Namespace