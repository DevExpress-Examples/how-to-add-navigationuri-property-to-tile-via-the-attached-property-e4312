using System;
using System.Windows;
using DevExpress.Xpf.LayoutControl;

namespace DXSilverlightApplication1
{
    public class NavigateUri
    {
        public static readonly DependencyProperty NavigateUriProperty = DependencyProperty.RegisterAttached("NavigateUri", typeof(Uri), typeof(NavigateUri), new PropertyMetadata(null, new PropertyChangedCallback(OnNavigateUriChanged)));

        public static Uri GetNavigateUri(Tile target)
        {
            return (Uri)target.GetValue(NavigateUriProperty);
        }

        public static void SetNavigateUri(Tile target, Uri value)
        {
            target.SetValue(NavigateUriProperty, value);
        }

        private static void OnNavigateUriChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Tile tile = (Tile)o;
            tile.Click -= o_Click;
            tile.Click += o_Click;
        }
        private static void o_Click(object sender, EventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Navigate((Uri)(sender as DependencyObject).GetValue(NavigateUriProperty));
        }    
    }
}
