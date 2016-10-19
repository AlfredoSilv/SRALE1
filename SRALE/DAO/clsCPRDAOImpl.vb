Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports System.Data.SqlClient

Namespace SRALE.DAO
    Public Class clsCPRDAOImpl
        Implements ICPR
        Private Shared myPISystems As New PISystems
        Private Shared myCom As PISystem = myPISystems.DefaultPISystem
        Private Shared myDB As AFDatabase = myCom.Databases("Compesa")
        '6aef0129-c77d-4828-98cc-3f80e059183e > ElementID do \PORTAL COOPERAÇÃO\RELATÓRIO DE QUALIDADE DA ÁGUA\
        Private Shared myPathRootID As Guid = New Guid("6aef0129-c77d-4828-98cc-3f80e059183e")
        Private Shared mychildElements As AFElements
        Private Shared listaCPR As AFElements
        ''' <summary>
        ''' Retorna a lista de CPR vinda do AF
        ''' </summary>
        ''' <returns></returns>
        Public Function ICPRDAO_buscarCPRAF() As List(Of clsCPR) Implements ICPR.buscarCPRAF
            Return clsCPR.buscaAF()
        End Function
        ''' <summary>
        ''' Busca a CPR na tabela tb_Coordenação no banco SRALE e retorna uma lista de CPR
        ''' </summary>
        ''' <returns></returns>
        Public Function ICPRDAO_buscarCPRSQL() As List(Of clsCPR) Implements ICPR.buscarCPRSQL
            Return clsCPR.buscarCPRSQL
        End Function
        ''' <summary>
        ''' Retorn uma lista de elemnetos filhos e retorna uma lista de ETAs
        ''' </summary>
        ''' <param name="pathrootid"></param>
        ''' <returns></returns>
        Public Function ICPRDAO_buscarElementoAF(ByVal pathrootid As Guid) As AFElements Implements ICPR.buscarElementoAF
            'Procura os elementos filhso com base no ID do Path Root (PathRootID).
            mychildElements = AFElement.FindElement(myCom, pathrootid).Elements
            Return mychildElements
        End Function
    End Class
End Namespace

