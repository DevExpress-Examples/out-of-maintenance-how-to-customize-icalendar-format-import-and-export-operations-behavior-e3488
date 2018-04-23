Imports Microsoft.VisualBasic
Imports System
Namespace ScheduleriCalendarExchangeCustomization
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim timeRuler3 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler4 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
			Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
			Me.btnImport = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' schedulerControl1
			' 
			Me.schedulerControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.schedulerControl1.Location = New System.Drawing.Point(12, 12)
			Me.schedulerControl1.Name = "schedulerControl1"
			Me.schedulerControl1.Size = New System.Drawing.Size(614, 219)
			Me.schedulerControl1.Start = New System.DateTime(2008, 9, 4, 0, 0, 0, 0)
			Me.schedulerControl1.Storage = Me.schedulerStorage1
			Me.schedulerControl1.TabIndex = 0
			Me.schedulerControl1.Text = "schedulerControl1"
			Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler3)
			Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler4)
			' 
			' btnExport
			' 
			Me.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnExport.Location = New System.Drawing.Point(221, 239)
			Me.btnExport.Name = "btnExport"
			Me.btnExport.Size = New System.Drawing.Size(75, 23)
			Me.btnExport.TabIndex = 1
			Me.btnExport.Text = "Export"
'			Me.btnExport.Click += New System.EventHandler(Me.btnExport_Click);
			' 
			' btnImport
			' 
			Me.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.btnImport.Location = New System.Drawing.Point(342, 239)
			Me.btnImport.Name = "btnImport"
			Me.btnImport.Size = New System.Drawing.Size(75, 23)
			Me.btnImport.TabIndex = 2
			Me.btnImport.Text = "Import"
'			Me.btnImport.Click += New System.EventHandler(Me.btnImport_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(638, 274)
			Me.Controls.Add(Me.btnImport)
			Me.Controls.Add(Me.btnExport)
			Me.Controls.Add(Me.schedulerControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
		Private WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
		Private WithEvents btnImport As DevExpress.XtraEditors.SimpleButton
	End Class
End Namespace

