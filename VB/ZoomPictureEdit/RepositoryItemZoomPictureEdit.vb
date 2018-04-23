Imports System
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports Microsoft.VisualBasic

Namespace nsZoomPictureEdit
	Friend Class RepositoryItemZoomPictureEdit
		Inherits RepositoryItemPictureEdit
		Friend Const EditorName As String = "ZoomPictureEdit"
		Private zoomFactor_Renamed As Single = 1

		Shared Sub New()
			Register()
		End Sub
		Public Sub New()
			SizeMode = PictureSizeMode.Zoom
		End Sub

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(ZoomPictureEdit), GetType(RepositoryItemZoomPictureEdit), GetType(ZoomPictureEditViewInfo), New PictureEditPainter(), True))
		End Sub

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			Try
				MyBase.Assign(item)
				Me.ZoomFactor = (CType(item, RepositoryItemZoomPictureEdit)).ZoomFactor
			Finally
				EndUpdate()
			End Try
		End Sub
		<Browsable(False)> _
		Public Shadows Property SizeMode() As PictureSizeMode
			Get
				Return MyBase.SizeMode
			End Get
			Set(ByVal value As PictureSizeMode)
				MyBase.SizeMode = value
			End Set
		End Property

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property
		Public Property ZoomFactor() As Integer
			Get
				Return CInt(Fix(Math.Round(zoomFactor_Renamed * 100)))
			End Get
			Set(ByVal value As Integer)
				zoomFactor_Renamed = value / 100.0f
				Me.OnPropertiesChanged()
			End Set
		End Property
		Protected Friend ReadOnly Property fZoomFactor() As Single
			Get
				Return zoomFactor_Renamed
			End Get
		End Property
	End Class
End Namespace
