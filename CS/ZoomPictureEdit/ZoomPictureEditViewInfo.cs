using System;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace nsZoomPictureEdit
{
    public class ZoomPictureEditViewInfo : PictureEditViewInfo
    {
        public ZoomPictureEditViewInfo(DevExpress.XtraEditors.Repository.RepositoryItem item)
            : base(item)
        {
        }

        protected override void CalcImageRect(Rectangle bounds)
        {
            float zoomFactor = ((RepositoryItemZoomPictureEdit)Item).fZoomFactor;

            Rectangle originRect = bounds;
            bounds.Width = (int)Math.Round(bounds.Width * zoomFactor);
            int horizIndent = (originRect.Width - bounds.Width) / 2;
            bounds.X += horizIndent;

            bounds.Height = (int)Math.Round(bounds.Height * zoomFactor);
            int vertIndent = (originRect.Height - bounds.Height) / 2;
            bounds.Y += vertIndent;

            base.CalcImageRect(bounds);
        }
    }
}
