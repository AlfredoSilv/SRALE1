Imports OSIsoft.AF.Asset
Imports SRALE.SRALE.Models
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.Web.Mvc
Imports SRALE.SRALE.DAO
Imports SRALE.SRALE.Models.Modelos

Namespace SRALE.Bussines
    Public Class clsCPRBussines
        Private CprDAO As ICPR

        Public Sub New()
            CprDAO = New clsCPRDAOImpl
        End Sub

        Public Function buscarCprAF() As List(Of clsCPR)
            Try
                Return Me.CprDAO.buscarCPRAF
            Catch generatedExceptionName As Exception
                Return New List(Of clsCPR)
            End Try
        End Function
        Public Sub montarDDLCpr(ByVal lstCpr As List(Of clsCPR))
            Dim ddlCpr As New clsDropDownCPRViewModel
            For Each item As clsCPR In lstCpr
                ddlCpr.IdGuid = item.ElementID
                ddlCpr.
            Next
    End Class
End Namespace

