using System;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;

namespace nsZoomPictureEdit
{
    class RepositoryItemZoomPictureEdit : RepositoryItemPictureEdit
    {
        internal const string EditorName = "ZoomPictureEdit";
        private float zoomFactor = 1;

        static RepositoryItemZoomPictureEdit()
        {
            Register();
        }
        public RepositoryItemZoomPictureEdit()
        {
			SizeMode = PictureSizeMode.Zoom;
		}

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(ZoomPictureEdit),
                typeof(RepositoryItemZoomPictureEdit), typeof(ZoomPictureEditViewInfo),
                    new PictureEditPainter(), true, null));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                this.ZoomFactor = ((RepositoryItemZoomPictureEdit)item).ZoomFactor;
            }
            finally
            {
                EndUpdate();
            }
        }
		[Browsable(false)]
		public new PictureSizeMode SizeMode
		{
			get
			{
				return base.SizeMode;
			}
			set
            {
            	base.SizeMode = value;
            }
		}

        public override string EditorTypeName
        {
            get { return EditorName; }
        }
        public int ZoomFactor
        {
            get { return (int)Math.Round(zoomFactor * 100); }
            set
            {
                zoomFactor = value / 100.0f;
                this.OnPropertiesChanged();
            }
        }
        protected internal float fZoomFactor
        {
            get { return zoomFactor; }
        }
    }
}
