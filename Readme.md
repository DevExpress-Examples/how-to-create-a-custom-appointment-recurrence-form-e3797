<!-- default file list -->
*Files to look at*:

* [CustomRecurrenceForm.xaml](./CS/WpfApplication1/CustomRecurrenceForm.xaml) (VB: [CustomRecurrenceForm.xaml](./VB/WpfApplication1/CustomRecurrenceForm.xaml))
* [CustomRecurrenceForm.xaml.cs](./CS/WpfApplication1/CustomRecurrenceForm.xaml.cs) (VB: [CustomRecurrenceForm.xaml.vb](./VB/WpfApplication1/CustomRecurrenceForm.xaml.vb))
* [MainWindow.xaml](./CS/WpfApplication1/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication1/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication1/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication1/MainWindow.xaml.vb))
<!-- default file list end -->
# How to create a custom Appointment Recurrence form


<p>This example demonstrates how to substitute your own custom <strong>Appointment Recurrence</strong> form for the default one.</p>


<h3>Description</h3>

<p>To replace the standard appointment recurrence editing form with a custom one, do the following:</p><p>1. Create a custom <strong>Appointment Recurrence</strong> form.</p><p>2. Handle the <strong>SchedulerControl1.RecurrenceFormShowing</strong> event and set the <strong>FormShowingEventArgs.Form</strong> property to a class instance specifying the custom recurrence form with the passed <strong>AppointmentFormController</strong> controller of the <strong>Edit Appointment</strong> form accessed via <strong>RecurrenceFormEventArgs.ParentForm</strong>.</p>

<br/>


