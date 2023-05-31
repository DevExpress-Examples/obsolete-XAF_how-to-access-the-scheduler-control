Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Scheduler.Web
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler
Imports DevExpress.Persistent.Base.General

Namespace HowToAccessSchedulerControl.Module.Web

    Public Partial Class SchedulerController
        Inherits ViewController

        Public Sub New()
            InitializeComponent()
            RegisterActions(components)
        End Sub

        Private Sub SchedulerController_Activated(ByVal sender As Object, ByVal e As EventArgs)
            If View.ObjectTypeInfo.[Implements](Of IEvent)() Then AddHandler View.ControlsCreated, New EventHandler(AddressOf Me.View_ControlsCreated)
        End Sub

        Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
            ' Access the current List View
            Dim view As ListView = CType(Me.View, ListView)
            ' Access the View's List Editor as a SchedulerListEditor
            Dim listEditor As ASPxSchedulerListEditor = CType(view.Editor, ASPxSchedulerListEditor)
            '  Access the List Editor's SchedulerControl  
            Dim scheduler As ASPxScheduler = listEditor.SchedulerControl
            ' Set the desired time to be visible
            If scheduler IsNot Nothing Then scheduler.Views.DayView.VisibleTime = New TimeOfDayInterval(New TimeSpan(6, 0, 0), New TimeSpan(11, 0, 0))
        End Sub
    End Class
End Namespace
