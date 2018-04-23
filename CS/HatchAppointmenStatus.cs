using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;

namespace ScheduleriCalendarExchangeCustomization {
    public class HatchAppointmenStatus : AppointmentStatus {
        private Color foreColor;
        private Color backColor;

        public HatchAppointmenStatus(int id, Color foreColor, Color backColor, string caption)
            : base((AppointmentStatusType)id, caption) {

            this.foreColor = foreColor;
            this.backColor = backColor;
        }

        protected override void Visit(IUserInterfaceObjectVisitor visitor) {
            IBrushAccessor brushAccessor = (IBrushAccessor)visitor;
            brushAccessor.Brush = new HatchBrush(HatchStyle.Cross, foreColor, backColor);
        }
    }
}