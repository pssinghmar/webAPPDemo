Imports System.Data.Entity
Imports DemowebApp.Core

Public Class DomainReferrerRepository
    Inherits GenericRepository(Of Core.DomainReferrer)
    Implements IDomainReferrerRepository

    Protected ReadOnly _entities As DbSet(Of Core.DomainReferrer)

    Public Sub New(dbContext As DemowebAppDBContext)
        MyBase.New(dbContext)
        _entities = _dbContext.Set(Of Core.DomainReferrer)()
    End Sub



    ' Implements GetItems correctly
    Public Function GetItems(Optional noTracking As Boolean = True) As IQueryable(Of Core.DomainReferrer) Implements IGenericRepository(Of Core.DomainReferrer).GetItems
        If noTracking Then
            Return _entities.AsNoTracking()
        End If
        Return _entities
    End Function
End Class
