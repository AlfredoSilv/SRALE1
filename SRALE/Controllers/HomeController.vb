Imports SRALE.SRALE.Models
Namespace SRALE.Controller
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
        Public Function Index() As ActionResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            Return RedirectToAction("Index", "Home")
        End Function
        <HttpGet>
        Public Function CPRInicio() As PartialViewResult
            Dim coord As New clsCoord
            Dim lstCoord As List(Of clsCoord) = clsCoord.buscarCPRSQL()
            Dim model As New clsCoordDdlViewModel
            model.ListCoord = lstCoord
            Return PartialView(model)
        End Function

        Public Function Inicio() As PartialViewResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            Return PartialView()
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