Imports Serilog

Public Class ActionService
    Private _lastRun As Date = Date.Now

    Public Sub Run(action As String, Optional delay As Integer = 5)
        If Date.Now.Subtract(_lastRun).TotalSeconds > delay Then
            _lastRun = Date.Now
            Log.Information($"{action} called at {_lastRun}")
        End If
    End Sub
End Class