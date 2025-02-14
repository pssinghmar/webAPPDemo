Imports System.Data.Entity
Imports System.Runtime
Imports DemowebApp.Core
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class DemowebAppDBContext
    Inherits IdentityDbContext(Of ApplicationUser)

    Public Sub New()
        MyBase.New("Data Source=PAWAN\SQLEXPRESS;Initial Catalog=demowebapp;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30",
                   throwIfV1Schema:=False)
    End Sub

    ' Define your DbSets
    Public Property DomainReferrers As DbSet(Of DomainReferrer)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

    End Sub


End Class
