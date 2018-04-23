#region #CustomRecurrenceForm
using System.Windows;
using System.Windows.Controls;
using DevExpress.XtraScheduler;
using DevExpress.Xpf.Scheduler;
using DevExpress.Xpf.Scheduler.UI;

namespace WpfApplication1 {
    public partial class CustomRecurrenceForm : UserControl {
        public CustomRecurrenceForm(AppointmentFormController controller) {
            RecurrenceVisualController = new StandaloneRecurrenceVisualController(controller);
            Controller = controller;
            InitializeComponent();
        }

        public AppointmentFormController Controller { get; private set; }
        public StandaloneRecurrenceVisualController RecurrenceVisualController { get; private set; }
        public TimeZoneHelper TimeZoneHelper { get { return RecurrenceVisualController.Controller.TimeZoneHelper; } }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            SchedulerFormBehavior.SetTitle(this, "Recurrence Range");
        }

        private void OK_Click(object sender, RoutedEventArgs e) {
            RecurrenceVisualController.ApplyRecurrence();
            CloseForm(true);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            CloseForm(false);
        }

        void CloseForm(bool dialogResult) {
            SchedulerFormBehavior.Close(this, dialogResult);
        }
    }
}
#endregion #CustomRecurrenceForm