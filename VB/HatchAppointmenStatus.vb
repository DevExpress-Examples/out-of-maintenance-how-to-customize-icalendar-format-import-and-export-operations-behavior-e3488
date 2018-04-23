Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraScheduler

Namespace ScheduleriCalendarExchangeCustomization
	Public Class HatchAppointmenStatus
		Inherits AppointmentStatus
		Private foreColor As Color
		Private backColor As Color

		Public Sub New(ByVal id As Integer, ByVal foreColor As Color, ByVal backColor As Color, ByVal caption As String)
			MyBase.New(CType(id, AppointmentStatusType), caption)

			Me.foreColor = foreColor
			Me.backColor = backColor
			MyBase.UpdateBrush()
		End Sub

		Protected Overrides Function CreateBrush() As Brush
			Return New HatchBrush(HatchStyle.Cross, foreColor, backColor)
		End Function
	End Class
End Namespace
