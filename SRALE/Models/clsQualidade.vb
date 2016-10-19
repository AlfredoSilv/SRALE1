Namespace SRALE.Models
    Public Class clsQuimica
        Implements IComparer(Of clsQuimica)
        Private Property _IDEta As Guid
        Private Property _Data As DateTime
        Private Property _Nome As String
        Private Property _Valor As Decimal
        Private Property _UOM As String
        Public Property IDEta As Guid
            Get
                Return _IDEta
            End Get
            Set(value As Guid)
                _IDEta = value
            End Set
        End Property
        Public Property Data As DateTime
            Get
                Return _Data
            End Get
            Set(value As DateTime)
                _Data = value
            End Set
        End Property
        Public Property Nome As String
            Get
                Return _Nome
            End Get
            Set(value As String)
                _Nome = value
            End Set
        End Property
        Public Property Valor As Decimal
            Get
                Return _Valor
            End Get
            Set(value As Decimal)
                _Valor = value
            End Set
        End Property
        Public Property UOM As String
            Get
                Return _UOM
            End Get
            Set(value As String)
                _UOM = value
            End Set
        End Property
        Public Sub New()

        End Sub
        Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
            Me.IDEta = IDEta
            Me.Data = Data
            Me.Nome = Nome
            Me.Valor = Valor
            Me.UOM = UOM
        End Sub
        Public Function Compare(ByVal x As clsQuimica, ByVal y As clsQuimica) As Integer _
       Implements System.Collections.Generic.IComparer(Of clsQuimica).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function
    End Class
    Public Class clsMetal
        Implements IComparer(Of clsMetal)
        Private Property _IDEta As Guid
        Private Property _Data As DateTime
        Private Property _Nome As String
        Private Property _Valor As Decimal
        Private Property _UOM As String
        Public Property IDEta As Guid
            Get
                Return _IDEta
            End Get
            Set(value As Guid)
                _IDEta = value
            End Set
        End Property
        Public Property Data As DateTime
            Get
                Return _Data
            End Get
            Set(value As DateTime)
                _Data = value
            End Set
        End Property
        Public Property Nome As String
            Get
                Return _Nome
            End Get
            Set(value As String)
                _Nome = value
            End Set
        End Property
        Public Property Valor As Decimal
            Get
                Return _Valor
            End Get
            Set(value As Decimal)
                _Valor = value
            End Set
        End Property
        Public Property UOM As String
            Get
                Return _UOM
            End Get
            Set(value As String)
                _UOM = value
            End Set
        End Property
        Public Sub New()

        End Sub
        Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
            Me.IDEta = IDEta
            Me.Data = Data
            Me.Nome = Nome
            Me.Valor = Valor
            Me.UOM = UOM
        End Sub
        Public Function Compare(ByVal x As clsMetal, ByVal y As clsMetal) As Integer _
      Implements System.Collections.Generic.IComparer(Of clsMetal).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function
    End Class
    Public Class clsDosador
        Implements IComparer(Of clsDosador)
        Private Property _IDEta As Guid
        Private Property _Data As DateTime
        Private Property _Nome As String
        Private Property _Valor As Decimal
        Private Property _UOM As String
        Public Property IDEta As Guid
            Get
                Return _IDEta
            End Get
            Set(value As Guid)
                _IDEta = value
            End Set
        End Property
        Public Property Data As DateTime
            Get
                Return _Data
            End Get
            Set(value As DateTime)
                _Data = value
            End Set
        End Property
        Public Property Nome As String
            Get
                Return _Nome
            End Get
            Set(value As String)
                _Nome = value
            End Set
        End Property
        Public Property Valor As Decimal
            Get
                Return _Valor
            End Get
            Set(value As Decimal)
                _Valor = value
            End Set
        End Property
        Public Property UOM As String
            Get
                Return _UOM
            End Get
            Set(value As String)
                _UOM = value
            End Set
        End Property
        Public Sub New()

        End Sub
        Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
            Me.IDEta = IDEta
            Me.Data = Data
            Me.Nome = Nome
            Me.Valor = Valor
            Me.UOM = UOM
        End Sub
        Public Function Compare(ByVal x As clsDosador, ByVal y As clsDosador) As Integer _
     Implements System.Collections.Generic.IComparer(Of clsDosador).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function
    End Class
    Public Class clsConsumo
        Implements IComparer(Of clsConsumo)
        Private Property _IDEta As Guid
        Private Property _Data As DateTime
        Private Property _Nome As String
        Private Property _Valor As Decimal
        Private Property _UOM As String
        Public Property IDEta As Guid
            Get
                Return _IDEta
            End Get
            Set(value As Guid)
                _IDEta = value
            End Set
        End Property
        Public Property Data As DateTime
            Get
                Return _Data
            End Get
            Set(value As DateTime)
                _Data = value
            End Set
        End Property
        Public Property Nome As String
            Get
                Return _Nome
            End Get
            Set(value As String)
                _Nome = value
            End Set
        End Property
        Public Property Valor As Decimal
            Get
                Return _Valor
            End Get
            Set(value As Decimal)
                _Valor = value
            End Set
        End Property
        Public Property UOM As String
            Get
                Return _UOM
            End Get
            Set(value As String)
                _UOM = value
            End Set
        End Property
        Public Sub New()

        End Sub
        Public Sub New(IDEta As Guid, Data As DateTime, Nome As String, Valor As Double, UOM As String)
            Me.IDEta = IDEta
            Me.Data = Data
            Me.Nome = Nome
            Me.Valor = Valor
            Me.UOM = UOM
        End Sub
        Public Function Compare(ByVal x As clsConsumo, ByVal y As clsConsumo) As Integer _
         Implements System.Collections.Generic.IComparer(Of clsConsumo).Compare
            Return String.Compare(x.Nome, y.Nome)
        End Function
    End Class
End Namespace

