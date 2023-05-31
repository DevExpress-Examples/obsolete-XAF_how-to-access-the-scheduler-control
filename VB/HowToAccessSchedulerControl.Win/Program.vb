Imports System
Imports System.Configuration
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security

Namespace HowToAccessSchedulerControl.Win

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Windows.Forms.Application.EnableVisualStyles()
            Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim application As HowToAccessSchedulerControlWindowsFormsApplication = New HowToAccessSchedulerControlWindowsFormsApplication()
            If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
                application.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            End If

            Try
                Xpo.InMemoryDataStoreProvider.Register()
                application.ConnectionString = Xpo.InMemoryDataStoreProvider.ConnectionString
                application.Setup()
                application.Start()
            Catch e As Exception
                application.HandleException(e)
            End Try
        End Sub
    End Module
End Namespace
