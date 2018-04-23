#Region "#CustomRecurrenceForm"
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.XtraScheduler
Imports DevExpress.Xpf.Scheduler
Imports DevExpress.Xpf.Scheduler.UI

Public Class CustomRecurrenceForm

    Public Sub New(ByVal controller As AppointmentFormController)
        RecurrenceVisualController = New StandaloneRecurrenceVisualController(controller)
        controller = controller
        InitializeComponent()
    End Sub

    Private privateController As AppointmentFormController
    Public Property Controller() As AppointmentFormController
        Get
            Return privateController
        End Get
        Private Set(ByVal value As AppointmentFormController)
            privateController = value
        End Set
    End Property
    Private privateRecurrenceVisualController As StandaloneRecurrenceVisualController
    Public Property RecurrenceVisualController() As StandaloneRecurrenceVisualController
        Get
            Return privateRecurrenceVisualController
        End Get
        Private Set(ByVal value As StandaloneRecurrenceVisualController)
            privateRecurrenceVisualController = value
        End Set
    End Property
    Public ReadOnly Property TimeZoneHelper() As TimeZoneHelper
        Get
            Return RecurrenceVisualController.Controller.TimeZoneHelper
        End Get
    End Property

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        SchedulerFormBehavior.SetTitle(Me, "Recurrence Range")
    End Sub

    Private Sub OK_Click(sender As Object, e As RoutedEventArgs)
        RecurrenceVisualController.ApplyRecurrence()
        CloseForm(True)
    End Sub

    Private Sub Cancel_Click(sender As Object, e As RoutedEventArgs)
        CloseForm(False)
    End Sub

    Private Sub CloseForm(ByVal dialogResult As Boolean)
        SchedulerFormBehavior.Close(Me, dialogResult)
    End Sub
End Class
#End Region