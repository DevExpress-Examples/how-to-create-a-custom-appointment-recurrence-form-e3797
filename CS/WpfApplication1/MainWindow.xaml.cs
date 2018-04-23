﻿using System.Windows;
using System.Data;
using System.Data.OleDb;
using DevExpress.XtraScheduler;
using DevExpress.Xpf.Scheduler;
using DevExpress.Xpf.Scheduler.UI;

namespace WpfApplication1 {
    public partial class MainWindow : Window {

        CarsDBDataSet dataSet;
        CarsDBDataSetTableAdapters.CarSchedulingTableAdapter adapter;

        public MainWindow() {
            InitializeComponent();

            schedulerControl1.Start = new System.DateTime(2010, 7, 15, 0, 0, 0, 0);

            this.dataSet = new CarsDBDataSet();

            // Bind Scheduler storage to appointment data
            this.schedulerControl1.Storage.AppointmentStorage.DataSource = dataSet.CarScheduling;

            // Load data into the 'CarsDBDataSet.CarScheduling' table. 
            this.adapter = new CarsDBDataSetTableAdapters.CarSchedulingTableAdapter();
            this.adapter.Fill(dataSet.CarScheduling);

            // Bind Scheduler storage to resource data
            this.schedulerControl1.Storage.ResourceStorage.DataSource = dataSet.Cars;

            // Load data into the 'CarsDBDataSet.Cars' table.
            CarsDBDataSetTableAdapters.CarsTableAdapter carsAdapter = 
                new CarsDBDataSetTableAdapters.CarsTableAdapter();
            carsAdapter.Fill(dataSet.Cars);

            this.schedulerControl1.Storage.AppointmentsInserted += 
                new PersistentObjectsEventHandler(Storage_AppointmentsModified);
            this.schedulerControl1.Storage.AppointmentsChanged += 
                new PersistentObjectsEventHandler(Storage_AppointmentsModified);
            this.schedulerControl1.Storage.AppointmentsDeleted += 
                new PersistentObjectsEventHandler(Storage_AppointmentsModified);

            this.adapter.Adapter.RowUpdated += 
                new System.Data.OleDb.OleDbRowUpdatedEventHandler(adapter_RowUpdated);
        }

        void Storage_AppointmentsModified(object sender, PersistentObjectsEventArgs e) {
            this.adapter.Adapter.Update(this.dataSet);
            this.dataSet.AcceptChanges();

        }

        private void adapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e) {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert) {
                int id = 0;
                using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", adapter.Connection)) {
                    id = (int)cmd.ExecuteScalar();
                }
                e.Row["ID"] = id;
            }
        }

        #region #RecurrenceFormShowingEvent
        private void schedulerControl1_RecurrenceFormShowing(object sender, RecurrenceFormEventArgs e) {
            AppointmentForm appointmentForm = e.ParentForm as AppointmentForm;
            e.Form = new CustomRecurrenceForm(appointmentForm.Controller);
        }
        #endregion #RecurrenceFormShowingEvent
    }
}
