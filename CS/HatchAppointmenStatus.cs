using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler;

namespace ScheduleriCalendarExchangeCustomization {
    public class HatchAppointmenStatus : AppointmentStatus {
        private Color foreColor;
        private Color backColor;

        public HatchAppointmenStatus(int id, Color foreColor, Color backColor, string caption)
            : base((AppointmentStatusType)id, caption) {

            this.foreColor = foreColor;
            this.backColor = backColor;
            base.UpdateBrush();
        }

        protected override Brush CreateBrush() {
            return new HatchBrush(HatchStyle.Cross, foreColor, backColor);
        }
    }
}
