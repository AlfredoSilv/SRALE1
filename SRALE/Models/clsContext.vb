Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports SRALE.SRALE.Models
Namespace EF
    'Cria uma classe herdada de DBContext
    Public Class clsContext
        Inherits DbContext
        'Cria as propriedade privadas tipo DBSet para as classes CPR e ETAs
        Private Property _CPR() As DbSet(Of clsCoord)
        Private _ETAs As DbSet(Of clsETAs)
        'Cria as propriedade públicas tipo DBSet para as classes CPR e ETAs
        Public Property CPR() As DbSet(Of clsCoord)
            Get
                Return _CPR
            End Get
            Set(value As DbSet(Of clsCoord))
                _CPR = value
            End Set
        End Property
        Public Property ETAs() As DbSet(Of clsETAs)
            Get
                Return _ETAs
            End Get
            Set(value As DbSet(Of clsETAs))
                _ETAs = value
            End Set
        End Property
        'Remove a pluralização na criação dos modelos das tabelas
        Protected Overrides Sub OnModelCreating(dbModelBuilder As DbModelBuilder)
            dbModelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        End Sub
    End Class
End Namespace
