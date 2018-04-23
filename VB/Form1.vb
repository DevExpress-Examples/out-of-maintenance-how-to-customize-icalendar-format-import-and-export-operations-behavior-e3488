Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.iCalendar
Imports DevExpress.XtraScheduler.iCalendar.Components

Namespace ScheduleriCalendarExchangeCustomization
	Partial Public Class Form1
		Inherits Form
		Private iCalendarExchangeFilePath As String = System.IO.Directory.GetCurrentDirectory() & "\..\..\test.ics"

		Public Sub New()
			InitializeComponent()

			CreateCustomStatus()
			CreateAppointmentWithCustomStatus()
		End Sub

		Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
			Dim exporter As New iCalendarExporter(schedulerStorage1)

			AddHandler exporter.AppointmentExporting, AddressOf exporter_AppointmentExporting
			exporter.Export(iCalendarExchangeFilePath)
			ShowiCalendarExchangeFile()
		End Sub

		Private Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImport.Click
			If (Not System.IO.File.Exists(iCalendarExchangeFilePath)) Then
				MessageBox.Show(String.Format("File '{0}' does not exist.", System.IO.Path.GetFullPath(iCalendarExchangeFilePath)))
				Return
			End If

			Dim importer As New iCalendarImporter(schedulerStorage1)

			AddHandler importer.AppointmentImported, AddressOf importer_AppointmentImported
			importer.Import(iCalendarExchangeFilePath)
		End Sub

		Private Sub exporter_AppointmentExporting(ByVal sender As Object, ByVal e As AppointmentExportingEventArgs)
			Dim args As iCalendarAppointmentExportingEventArgs = TryCast(e, iCalendarAppointmentExportingEventArgs)

			'((CustomProperty)args.VEvent.CustomProperties["X-MICROSOFT-CDO-BUSYSTATUS"]).Value = e.Appointment.StatusId.ToString();
			CType(args.VEvent.CustomProperties("X-DEVEXPRESS-STATUS"), CustomProperty).Value = e.Appointment.StatusKey.ToString()
		End Sub

		Private Sub importer_AppointmentImported(ByVal sender As Object, ByVal e As AppointmentImportedEventArgs)
			Dim args As iCalendarAppointmentImportedEventArgs = TryCast(e, iCalendarAppointmentImportedEventArgs)
			e.Appointment.StatusKey = Convert.ToInt32((CType(args.VEvent.CustomProperties("X-DEVEXPRESS-STATUS"), CustomProperty)).Value)
		End Sub

		Private Sub CreateCustomStatus()
			Dim newCustomStatus As AppointmentStatus = schedulerControl1.Storage.Appointments.Statuses.CreateNewStatus(40, "Alert", "Alert")
			newCustomStatus.Brush = New HatchBrush(HatchStyle.DottedDiamond, Color.Red, Color.Yellow)
			schedulerControl1.Storage.Appointments.Statuses.Add(newCustomStatus)
		End Sub

		Private Sub CreateAppointmentWithCustomStatus()
			Dim schedulerStorage As SchedulerStorage = schedulerControl1.Storage
			Dim apt As Appointment = schedulerStorage.CreateAppointment(AppointmentType.Normal)
			Dim baseTime As DateTime = schedulerControl1.Start

			apt.Start = baseTime.AddHours(1)
			apt.End = baseTime.AddHours(2)
			apt.Subject = "Test"
			apt.Location = "Office"
			apt.Description = "Test procedure"
			apt.StatusKey = 40 ' Custom status

			schedulerStorage.Appointments.Add(apt)
		End Sub

		Private Sub ShowiCalendarExchangeFile()
			Dim processStartInfo As New System.Diagnostics.ProcessStartInfo()
			processStartInfo.FileName = "notepad.exe"
			processStartInfo.Arguments = iCalendarExchangeFilePath
			Dim process As System.Diagnostics.Process = System.Diagnostics.Process.Start(processStartInfo)
			process.WaitForExit()
		End Sub
	End Class
End Namespace