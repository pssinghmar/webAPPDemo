Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports DemowebApp.Core

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of DemowebAppDBContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As DemowebAppDBContext)
            ' Add default domain referrer if it does not exist
            If Not context.DomainReferrers.Any(Function(d) d.DomainName = "https://defaultsite.com") Then
                context.DomainReferrers.AddOrUpdate(
                New DomainReferrer With {
                    .DomainName = "https://defaultsite.com",
                    .IsActive = True,
                    .CreatedAt = DateTime.Now
                })
            End If

            context.SaveChanges()
        End Sub

    End Class

End Namespace
