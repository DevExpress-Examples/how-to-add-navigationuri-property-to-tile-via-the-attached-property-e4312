Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports DevExpress.Xpf.LayoutControl

Namespace DXSilverlightApplication1
	Public Class NavigateUri
		Public Shared ReadOnly NavigateUriProperty As DependencyProperty = DependencyProperty.RegisterAttached("NavigateUri", GetType(Uri), GetType(NavigateUri), New PropertyMetadata(Nothing, New PropertyChangedCallback(AddressOf OnNavigateUriChanged)))

		Public Shared Function GetNavigateUri(ByVal target As Tile) As Uri
			Return CType(target.GetValue(NavigateUriProperty), Uri)
		End Function

		Public Shared Sub SetNavigateUri(ByVal target As Tile, ByVal value As Uri)
			target.SetValue(NavigateUriProperty, value)
		End Sub

		Private Shared Sub OnNavigateUriChanged(ByVal o As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim tile As Tile = CType(o, Tile)
			RemoveHandler tile.Click, AddressOf o_Click
			AddHandler tile.Click, AddressOf o_Click
		End Sub
		Private Shared Sub o_Click(ByVal sender As Object, ByVal e As EventArgs)
			System.Windows.Browser.HtmlPage.Window.Navigate(CType((TryCast(sender, DependencyObject)).GetValue(NavigateUriProperty), Uri))
		End Sub
	End Class
End Namespace
