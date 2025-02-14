Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http
Imports DemowebApp.Common
Imports DemowebApp.Servcies

Public Class ValuesController
    Inherits ApiController




    ' POST api/values
    <HttpPost>
    Public Async Function PostDataAsync(<FromBody()> ByVal requestData As Dictionary(Of String, String)) As Task(Of HttpResponseMessage)
        Dim validReferrer As String = "https://localhost:44395/" ' Replace with the actual allowed referrer

        ' Get the referring URL
        Dim referrer As String = If(Request.Headers.Referrer IsNot Nothing, Request.Headers.Referrer.ToString(), "")

        If referrer <> validReferrer Then
            Return Request.CreateResponse(HttpStatusCode.Forbidden, New With {.error = "Invalid Referrer"})
        End If

        Dim receivedData As New Dictionary(Of String, String)

        For Each key In requestData.Keys
            receivedData(key) = requestData(key) ' Store each key-value pair
        Next


        Dim responseData = New With {
        .message = "Success",
        .receivedData = receivedData
    }

        Return Request.CreateResponse(HttpStatusCode.OK, responseData)
    End Function

End Class
