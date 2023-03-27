Imports System.IO
Imports System.Reflection
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Serilog

Public Module Program
    Public Sub Main(args As String())
        Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        Log.Logger = New LoggerConfiguration().WriteTo.File("service.log").CreateLogger()
        Dim host As IHost = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args).
            ConfigureServices(
                Sub(services As IServiceCollection)
                    services.AddHostedService(Of Worker)
                    services.AddSingleton(Of ActionService)
                End Sub).Build()
        host.Run()
    End Sub
End Module
