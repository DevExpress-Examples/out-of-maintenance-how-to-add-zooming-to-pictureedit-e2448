Imports System
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports Microsoft.VisualBasic

Namespace nsZoomPictureEdit
	Public Class ZoomPictureEditViewInfo
		Inherits PictureEditViewInfo
		Public Sub New(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
			MyBase.New(item)
		End Sub

		Protected Overrides Sub CalcImageRect(ByVal bounds As Rectangle)
			Dim zoomFactor As Single = (CType(Item, RepositoryItemZoomPictureEdit)).fZoomFactor

			Dim originRect As Rectangle = bounds
			bounds.Width = CInt(Fix(Math.Round(bounds.Width * zoomFactor)))
            Dim horizIndent As Integer = (originRect.Width - bounds.Width) / 2
			bounds.X += horizIndent

			bounds.Height = CInt(Fix(Math.Round(bounds.Height * zoomFactor)))
            Dim vertIndent As Integer = (originRect.Height - bounds.Height) / 2
			bounds.Y += vertIndent

			MyBase.CalcImageRect(bounds)
		End Sub
	End Class
End Namespace
