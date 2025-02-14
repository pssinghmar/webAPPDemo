Imports Unity
Imports Unity.Mvc5
Imports Unity.Lifetime
Imports System.Web.Mvc
Imports System.Web.Http
Imports Unity.WebApi
Imports DemowebApp.Servcies
Imports DemowebApp.DataBase
Imports DemowebApp.Core


Public Module UnityConfig
    Private container As IUnityContainer

    Public Sub RegisterComponents()
        container = New UnityContainer()

        ' Register UnitOfWork
        container.RegisterType(Of IUnitOfWork, UnitOfWork)()

        ' Register Repository
        container.RegisterType(Of IDomainReferrerRepository, DomainReferrerRepository)()

        ' Register Service
        container.RegisterType(Of IDomainReferrerService, DomainReferrerService)(New HierarchicalLifetimeManager())


        ' Set dependency resolver for MVC
        GlobalConfiguration.Configuration.DependencyResolver = New Unity.WebApi.UnityDependencyResolver(container)
    End Sub
End Module


