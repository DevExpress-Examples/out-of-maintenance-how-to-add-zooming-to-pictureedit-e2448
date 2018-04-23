Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Namespace nsZoomPictureEdit
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			gridControl1.DataSource = CreateTable(3)
			gridView1.RowHeight = 100

			gridView1.Columns("Image").ColumnEdit = New RepositoryItemZoomPictureEdit()
		End Sub

		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("Image", GetType(Image))

			For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() {String.Format("Name{0}", i), My.Resources.Image})
			Next i

			Return tbl
		End Function

	End Class
End Namespace
