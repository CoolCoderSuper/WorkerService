Imports System.IO
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Serilog

Public Module Program
    Public Sub Main(args As String())
        Dim logFile As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "WorkerServiceVB", "log.txt")
        Log.Logger = New LoggerConfiguration().WriteTo.File(logFile).CreateLogger()
        Dim host As IHost = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args).
            ConfigureServices(
                Sub(services As IServiceCollection)
                    services.AddHostedService(Of Worker)
                    services.AddSingleton(Of ActionService)
                End Sub).UseWindowsService.Build()
        host.Run()
    End Sub
End Module
