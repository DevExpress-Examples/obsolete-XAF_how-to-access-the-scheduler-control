Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Scheduler.Win
Imports DevExpress.Persistent.Base.General
Imports DevExpress.XtraScheduler

Namespace HowToAccessSchedulerControl.Module.Win

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
            Dim listEditor As SchedulerListEditor = CType(view.Editor, SchedulerListEditor)
            '  Access the List Editor's SchedulerControl  
            Dim scheduler As SchedulerControl = listEditor.SchedulerControl
            ' Set the desired time to be visible
            If scheduler IsNot Nothing Then scheduler.Views.DayView.VisibleTime = New TimeOfDayInterval(New TimeSpan(6, 0, 0), New TimeSpan(11, 0, 0))
        End Sub
    End Class
End Namespace
