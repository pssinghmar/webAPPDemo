
Imports System.Data.Entity
Imports DemowebApp.Core

Public MustInherit Class GenericRepository(Of T As Class)
    Implements IGenericRepository(Of T)

    Protected ReadOnly _dbContext As DemowebAppDBContext
    Protected ReadOnly _entities As DbSet(Of T)

    Protected Sub New(context As DemowebAppDBContext)
        _dbContext = context
        _entities = _dbContext.Set(Of T)()
    End Sub


    Public Function GetItems(Optional noTracking As Boolean = True) As IQueryable(Of T) Implements IGenericRepository(Of T).GetItems
        Dim query As IQueryable(Of T) = _dbContext.Set(Of T)()

        If noTracking Then
            Return query.AsNoTracking()
        End If

        Return query
    End Function


End Class