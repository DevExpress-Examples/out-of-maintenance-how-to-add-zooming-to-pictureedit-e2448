using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace nsZoomPictureEdit
{
    class ZoomPictureEdit : PictureEdit
    {
        static ZoomPictureEdit()
        {
            RepositoryItemZoomPictureEdit.Register();
        }
        public ZoomPictureEdit()
        {
		}

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
                Properties.ZoomFactor += 10;
            if ( e.Delta < 0 && Properties.ZoomFactor > 10)
                Properties.ZoomFactor -= 10;

            base.OnMouseWheel(e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemZoomPictureEdit Properties
        {
            get { return base.Properties as RepositoryItemZoomPictureEdit; }
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemZoomPictureEdit.EditorName; }
        }
    }
}