Imports DemowebApp.Common
Imports DemowebApp.Core

Public Class DomainReferrerService
    Implements IDomainReferrerService

    Private ReadOnly _unitOfWork As IUnitOfWork

    Public Sub New(unitOfWork As IUnitOfWork)
        _unitOfWork = unitOfWork
    End Sub

    Public Async Function GetAllAsync(Query As GridQueryReceiverModel) As Task(Of GenricSenderResponseModel(Of DomainReferrerDTO)) Implements IDomainReferrerService.GetAllAsync
        Dim result = _unitOfWork.DomainReferrer.GetItems()

        Dim totalCount As Integer = result.Count()

        Dim ReferrerList As List(Of DomainReferrerDTO) = result.
    OrderBy(Function(u) u.Id). ' Add an OrderBy clause
    Skip((Query.Page - 1) * Query.PageSize).
    Take(Query.PageSize).
    Select(Function(u) New DomainReferrerDTO With {
        .DomainName = u.DomainName,
        .IsActive = u.IsActive,
        .CreatedAt = u.CreatedAt,
        .Id = u.Id,
        .UpdatedAt = u.UpdatedAt
    }).ToList()


        Dim ReferrerResponse As New GenricSenderResponseModel(Of DomainReferrerDTO) With {
            .Resources = ReferrerList,
            .Count = totalCount
        }

        Return Await Task.FromResult(ReferrerResponse)
    End Function

End Class
