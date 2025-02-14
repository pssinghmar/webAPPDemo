Public Interface IUnitOfWork

    ReadOnly Property DomainReferrer As IDomainReferrerRepository
    Function Save() As Task(Of Int32)


End Interface
