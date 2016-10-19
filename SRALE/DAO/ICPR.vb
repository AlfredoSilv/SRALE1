Imports OSIsoft.AF.Asset
Namespace SRALE.DAO
    Public Interface ICPR
        Function buscarCPRAF() As List(Of clsCPR)
        Function buscarCPRSQL() As List(Of clsCPR)
        'Sub atualizarListaCPRSQL(listaNovaCPR As List(Of clsCPR), listaAtivarCPR As List(Of clsCPR), listaDesativarCPR As List(Of clsCPR))
        Function buscarElementoAF(guid As Guid) As AFElements
    End Interface
End Namespace

