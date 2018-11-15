<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to customize iCalendar format import and export operations behavior


<p>This example illustrates how to persist custom <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument1754"><u>Statuses</u></a> when appointments are exported/imported to /from *.ics file. To do this, handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerExchangeAppointmentExporter_AppointmentExportingtopic"><u>AppointmentExporter.AppointmentExporting Event</u></a> / <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerExchangeAppointmentImporter_AppointmentImportedtopic"><u>AppointmentImporter.AppointmentImported Event</u></a> of the iCalendarExporter/iCalendarImporter objects and override/utilize <strong>X-DEVEXPRESS-STATUS</strong> custom property value according to the <strong>e.Appointment.StatusId</strong> parameter.</p><p><strong>See </strong><strong>A</strong><strong>lso:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2437">How to extend text properties of appointments exported to iCalendar format (to add meeting requests with attendees)</a></p>

<br/>


