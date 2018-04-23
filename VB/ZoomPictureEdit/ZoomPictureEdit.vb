Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace nsZoomPictureEdit
	Friend Class ZoomPictureEdit
		Inherits PictureEdit
		Shared Sub New()
			RepositoryItemZoomPictureEdit.Register()
		End Sub
		Public Sub New()
		End Sub

		Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
			If e.Delta > 0 Then
				Properties.ZoomFactor += 10
			End If
			If e.Delta < 0 AndAlso Properties.ZoomFactor > 10 Then
				Properties.ZoomFactor -= 10
			End If

			MyBase.OnMouseWheel(e)
		End Sub

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemZoomPictureEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemZoomPictureEdit)
			End Get
		End Property

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemZoomPictureEdit.EditorName
			End Get
		End Property
	End Class
End Namespace