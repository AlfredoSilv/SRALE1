Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports OSIsoft.AF.Time

Namespace SRALE.Models
    ''' <summary>
    ''' Cria as propriedades privadas de Elementos
    ''' </summary>
    Public Class clsElementos
        Private Property _CoordAF As List(Of clsCoord)
        Private Property _EtaAF() As List(Of clsETAs)
        Public Property CoordAF As List(Of clsCoord)
            Get
                Return _CoordAF
            End Get
            Set(value As List(Of clsCoord))
                Dim lista As List(Of clsCoord) = buscaEtaAF()
                For Each coord As clsCoord In lista
                    value.Add(coord)
                Next
                _CoordAF = value
            End Set
        End Property
        Public Property EtasAF As List(Of clsETAs)
            Get
                Return _EtaAF
            End Get
            Set(value As List(Of clsETAs))
                Dim lista As List(Of clsCoord) = buscaEtaAF()
                For Each coord As clsCoord In lista
                    For Each eta As clsETAs In coord.lstEta
                        value.Add(eta)
                    Next
                Next
                _EtaAF = value
            End Set
        End Property
        ''' <summary>
        ''' Cria uma função para armazenar uma coleção de Coordenação
        ''' e Etas
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function buscaEtaAF() As List(Of clsCoord)
            Dim lista As New List(Of clsCoord)
            Dim myPISystems As New PISystems
            Dim myCom As PISystem = myPISystems.DefaultPISystem
            Dim myDB As AFDatabase = myCom.Databases.DefaultDatabase
            Dim myPathRootID As Guid = My.Settings.myAFRootID 'd4763b58-3566-4443-849f-e8cb49ff8096 - ID do COMPESA NOVO
            Dim myEtaTempID As Guid = My.Settings.myAFEtaTempID 'cf0e452d-636b-4194-9d32-31ebb3b45a58 - ID do Template ETA
            Dim elemRoot As AFElement = AFElement.FindElement(myCom, myPathRootID) 'Elemento COMPESA NOVO.
            Dim elemTemp As AFElementTemplate = AFElementTemplate.FindElementTemplate(myCom, myEtaTempID) 'Elemento Template ETA
            Dim myTimeRange As New AFTimeRange()
            myTimeRange.StartTime = New AFTime(DateTime.UtcNow.AddHours(-1))
            myTimeRange.EndTime = AFTime.Now
            Dim atribval As AFValues
            Dim myEtadAtr As AFAttributes
            Dim lstEtas As AFNamedCollectionList(Of AFElement)
            Dim pageSize As Integer = 100
            Dim startIndex As Integer = 0
            Dim totalCount As Integer = 0
            Dim dicCoord As New Dictionary(Of Guid, clsCoord)
            Dim dicEta As New Dictionary(Of Guid, clsETAs)
            Do
                'Listar as Etas.
                lstEtas = AFElement.FindElements(myDB, elemRoot, Nothing, Nothing, elemTemp, AFElementType.Any, True, AFSortField.Name, AFSortOrder.Ascending, startIndex, pageSize, totalCount)
                If (lstEtas Is Nothing) Then
                    Exit Do
                End If
                For Each item As AFElement In lstEtas
                    If Not item.Name = "ETA" Then
                        'Busca todos os atributos da elemnto ETA.
                        myEtadAtr = AFElement.FindElement(myCom, item.ID).Attributes
                        'Para cada atributo na lista de atributos.
                        For Each atrib As AFAttribute In myEtadAtr
                            If atrib.Name = "Coordenacao" Then
                                'Pego o valor de cada atributo.
                                atribval = atrib.GetValues(myTimeRange, 0, Nothing)
                                'Para cada valor de atributo.
                                For Each val As AFValue In atribval
                                    'Verifica se o valor do atributo é diferente de null.
                                    If Not val.Value = Nothing Then
                                        'Verifica se o valor já existe no dicionário de Etas
                                        If Not dicEta.ContainsKey(item.ID) Then
                                            Dim Eta As New clsETAs 'Instancia a a ETA.
                                            Dim lstEta As New List(Of clsETAs)  'Cria uma lista de Etas.
                                            'Carrega a Eta
                                            Eta.ElementID = item.ID
                                            Eta.Nome = item.Name
                                            lstEta.Add(Eta)
                                            dicEta.Add(item.ID, Eta)    'Carrega o dicionáario de Etas.
                                            'Verifica se o valor já existe no dicionário de Coordenação.
                                            If Not dicCoord.ContainsKey(val.Value.ID) Then
                                                Dim Coord As New clsCoord   'Instancia a Coordenação.
                                                'Carrega a Coordenação.
                                                Coord.ElementID = val.Value.ID
                                                Coord.Nome = val.Value.Name
                                                Coord.lstEta = lstEta
                                                dicCoord.Add(val.Value.ID, Coord)   'Carrega o dicionário de Coordenação.
                                            Else    'Se a coordenão já existir no dicinário.
                                                'Carrega a lista de Eta na Coordenação existente.
                                                dicCoord.Item(val.Value.ID).lstEta.Add(Eta) 'New clsETAs(item.ID, item.Name))
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
                startIndex = (startIndex + pageSize)
            Loop While (startIndex < totalCount)

            For Each par As KeyValuePair(Of Guid, clsCoord) In dicCoord
                lista.Add(par.Value)
            Next
            Return lista
        End Function
    End Class
End Namespace

