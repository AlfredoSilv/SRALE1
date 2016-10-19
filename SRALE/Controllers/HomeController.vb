Imports SRALE.SRALE.Models.Modelos
Namespace SRALE.Controller
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
        Public Function Index() As ActionResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            Return RedirectToAction("Index", "Home")
        End Function
        <HttpGet>
        Public Function CPRInicio() As PartialViewResult
            Dim cpr As New clsCPR
            Dim listaCpr As List(Of clsCPR) = clsCPR.ListaCPR(Guid.Parse(""))
            Dim model As clsCPRViewModel = gerenciaBusiness.criarGerenciaViewModel(listaGerencia)

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