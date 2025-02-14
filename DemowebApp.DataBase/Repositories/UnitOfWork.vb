Imports DemowebApp.Core

Public Class UnitOfWork
    Implements IUnitOfWork

    Private ReadOnly _dbContext As DemowebAppDBContext
    Private _domainReferrer As IDomainReferrerRepository


    Public Sub New(dbContext As DemowebAppDBContext)
        _dbContext = dbContext
    End Sub


    Public ReadOnly Property DomainReferrer As IDomainReferrerRepository Implements IUnitOfWork.DomainReferrer
        Get
            If _domainReferrer Is Nothing Then
                _domainReferrer = New DomainReferrerRepository(_dbContext)
            End If
            Return _domainReferrer
        End Get
    End Property

    Public Function Save() As Task(Of Integer) Implements IUnitOfWork.Save
        _dbContext.SaveChanges()

    End Function
End Class
