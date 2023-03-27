Imports Microsoft.Extensions.Hosting
Imports System.Threading

Public Class Worker
    Inherits BackgroundService
    Private ReadOnly _service As ActionService

    Public Sub New(service As ActionService)
        _service = service
    End Sub

    Protected Overrides Async Function ExecuteAsync(stoppingToken As CancellationToken) As Task
        While Not stoppingToken.IsCancellationRequested
            Await Task.Run(Sub() _service.Run("Worker"), stoppingToken)
        End While
    End Function
End Class