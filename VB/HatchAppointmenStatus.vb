Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Native

Namespace ScheduleriCalendarExchangeCustomization
	Public Class HatchAppointmenStatus
		Inherits AppointmentStatus
		Private foreColor As Color
		Private backColor As Color

		Public Sub New(ByVal id As Integer, ByVal foreColor As Color, ByVal backColor As Color, ByVal caption As String)
			MyBase.New(CType(id, AppointmentStatusType), caption)

			Me.foreColor = foreColor
			Me.backColor = backColor
		End Sub

		Protected Overrides Sub Visit(ByVal visitor As IUserInterfaceObjectVisitor)
			Dim brushAccessor As IBrushAccessor = CType(visitor, IBrushAccessor)
			brushAccessor.Brush = New HatchBrush(HatchStyle.Cross, foreColor, backColor)
		End Sub
	End Class
End Namespace