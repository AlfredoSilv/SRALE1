Imports OSIsoft.AF
Imports OSIsoft.AF.Asset
Imports OSIsoft.AF.Time

Namespace SRALE.Models
    ''' <summary>
    ''' Cria as propriedades privadas do objeto atributo
    ''' </summary>
    Public Class clsAtributos
        Implements IComparer(Of clsAtributos)
        ''' <summary>
        ''' Propriedades privadas da classe atributos
        ''' </summary>
        ''' <returns></returns>
        Private Property _AtribID As Guid
        Private Property _AtribNome As String
        Private Property _AtribData As DateTime
        Private Property _AtribVal As VariantType
        Private Property _AtribUOM As String
        ''' <summary>
        ''' Propriedades públicas da classe atributos
        ''' </summary>
        ''' <returns></returns>
        Public Property AtribID As Guid
            Get
                Return _AtribID
            End Get
            Set(value As Guid)
                _AtribID = value
            End Set
        End Property
        Public Property AtribNome As String
            Get
                Return _AtribNome
            End Get
            Set(value As String)
                _AtribNome = value
            End Set
        End Property
        Public Property AtribData As DateTime
            Get
                Return _AtribData
            End Get
            Set(value As DateTime)
                _AtribData = value
            End Set
        End Property
        Public Property AtribVal As VariantType
            Get
                Return _AtribVal
            End Get
            Set(value As VariantType)
                _AtribVal = value
            End Set
        End Property
        Public Property AtribUOM As String
            Get
                Return _AtribUOM
            End Get
            Set(value As String)
                _AtribUOM = value
            End Set
        End Property
        Public Sub New()

        End Sub
        Public Sub New(ByVal AtribID As Guid, ByVal AtribNome As String, ByVal AtribData As DateTime, ByVal AtribVal As VariantType, ByVal AtribUOM As String)
            Me.AtribID = AtribID
            Me.AtribNome = AtribNome
            Me.AtribData = AtribData
            Me.AtribVal = AtribVal
            Me.AtribUOM = AtribUOM
        End Sub

        ''' <summary>
        ''' Ordena os atributos por nome
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        Public Function Compare(x As clsAtributos, y As clsAtributos) As Integer Implements IComparer(Of clsAtributos).Compare
            Return String.Compare(x.AtribNome, y.AtribNome)
            Return DateTime.Compare(x.AtribData, y.AtribData)
        End Function

    End Class
End Namespace
