Imports Microsoft.AspNet.Identity.EntityFramework

Public Class ApplicationUser
    Inherits IdentityUser

    Public Property FullName As String

    Public Property CreatedBy As String
    Public Property CreatedAt As DateTime
    Public Property ModifiedBy As String
    Public Property ModifiedAt As DateTime?

    Public Property IsTemporaryPassword As Boolean
    Public Property TempPasModifiedAt As DateTime?

End Class
