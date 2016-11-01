Imports SRALE.SRALE.Models
Namespace SRALE.Controller
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
        Public Function Index() As ActionResult
            ViewData("Message") = "SRALE - Sistema de Registro de Análises Laboratoriais em ETA"
            ViewBag.ElementID = New SelectList(New clsCoordDdlViewModel().ListCoord(), "ElementID", "Nome")

            Return View()
        End Function
        <HttpPost>
        Public Function Index(elementId As Guid) As ActionResult
            ' O quarto parametro "clienteId" diz qual é o ID
            ' que deve vir pré-selecionado ao montar o DropDownList
            ViewBag.ElementID = New SelectList(New clsCoordDdlViewModel().ListCoord(), "ElementID", "Nome", elementId)

            Return View()
        End Function

        <HttpGet>
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