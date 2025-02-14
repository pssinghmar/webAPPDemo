Imports DemowebApp.Common

Public Interface IDomainReferrerService
    Function GetAllAsync(query As GridQueryReceiverModel) As Task(Of GenricSenderResponseModel(Of DomainReferrerDTO))
End Interface
