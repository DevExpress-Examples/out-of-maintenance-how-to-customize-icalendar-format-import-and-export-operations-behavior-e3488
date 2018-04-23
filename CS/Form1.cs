using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using DevExpress.XtraScheduler.iCalendar.Components;

namespace ScheduleriCalendarExchangeCustomization {
    public partial class Form1 : Form {
        private string iCalendarExchangeFilePath = System.IO.Directory.GetCurrentDirectory() + @"\..\..\test.ics";
        
        public Form1() {
            InitializeComponent();
            
            CreateCustomStatus();
            CreateAppointmentWithCustomStatus();
        }

        private void btnExport_Click(object sender, EventArgs e) {
            iCalendarExporter exporter = new iCalendarExporter(schedulerStorage1);

            exporter.AppointmentExporting += new AppointmentExportingEventHandler(exporter_AppointmentExporting);
            exporter.Export(iCalendarExchangeFilePath);
            ShowiCalendarExchangeFile();
        }

        private void btnImport_Click(object sender, EventArgs e) {
            if (!System.IO.File.Exists(iCalendarExchangeFilePath)) {
                MessageBox.Show(string.Format("File '{0}' does not exist.", System.IO.Path.GetFullPath(iCalendarExchangeFilePath)));
                return;
            }
            
            iCalendarImporter importer = new iCalendarImporter(schedulerStorage1);

            importer.AppointmentImported += new AppointmentImportedEventHandler(importer_AppointmentImported);
            importer.Import(iCalendarExchangeFilePath);
        }

        void exporter_AppointmentExporting(object sender, AppointmentExportingEventArgs e) {
            iCalendarAppointmentExportingEventArgs args = e as iCalendarAppointmentExportingEventArgs;

            //((CustomProperty)args.VEvent.CustomProperties["X-MICROSOFT-CDO-BUSYSTATUS"]).Value = e.Appointment.StatusId.ToString();
            ((CustomProperty)args.VEvent.CustomProperties["X-DEVEXPRESS-STATUS"]).Value = e.Appointment.StatusId.ToString();
        }

        void importer_AppointmentImported(object sender, AppointmentImportedEventArgs e) {
            iCalendarAppointmentImportedEventArgs args = e as iCalendarAppointmentImportedEventArgs;

            e.Appointment.StatusId = Convert.ToInt32(((CustomProperty)args.VEvent.CustomProperties["X-DEVEXPRESS-STATUS"]).Value);
        }

        private void CreateCustomStatus() {
            schedulerControl1.Storage.Appointments.Statuses.Add(new HatchAppointmenStatus(101, Color.Red, Color.Yellow, "&Alert"));
        }

        private void CreateAppointmentWithCustomStatus() {
            SchedulerStorage schedulerStorage = schedulerControl1.Storage;
            Appointment apt = schedulerStorage.CreateAppointment(AppointmentType.Normal);
            DateTime baseTime = schedulerControl1.Start;

            apt.Start = baseTime.AddHours(1);
            apt.End = baseTime.AddHours(2);
            apt.Subject = "Test";
            apt.Location = "Office";
            apt.Description = "Test procedure";
            apt.StatusId = 4; // Custom status

            schedulerStorage.Appointments.Add(apt);
        }

        private void ShowiCalendarExchangeFile() {
            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
            processStartInfo.FileName = "notepad.exe";
            processStartInfo.Arguments = iCalendarExchangeFilePath;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(processStartInfo);
            process.WaitForExit();
        }
    }
}