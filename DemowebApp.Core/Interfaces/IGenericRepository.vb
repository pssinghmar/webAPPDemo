Public Interface IGenericRepository(Of T As Class)

    Function GetItems(Optional ByVal noTracking As Boolean = True) As IQueryable(Of T)

End Interface
