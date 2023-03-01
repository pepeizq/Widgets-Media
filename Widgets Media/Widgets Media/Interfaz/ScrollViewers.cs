using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using static Widgets_Media.MainWindow;

namespace Interfaz
{
    public static class ScrollViewers
    {
        public static void Cargar()
        {
            ObjetosVentana.nvItemSubirArriba.PointerPressed += SubirArriba;
            ObjetosVentana.nvItemSubirArriba.PointerEntered += Animaciones.EntraRatonNvItem2;
            ObjetosVentana.nvItemSubirArriba.PointerExited += Animaciones.SaleRatonNvItem2;

            ObjetosVentana.svPresentacion.ViewChanging += svScroll;
            ObjetosVentana.svNetflixResultados.ViewChanging += svScroll;
            ObjetosVentana.svDisneyPlusResultados.ViewChanging += svScroll;
            ObjetosVentana.svPrimeVideoResultados.ViewChanging += svScroll;
            ObjetosVentana.svSpotifyResultados.ViewChanging += svScroll;
            ObjetosVentana.svWidgetPrecarga.ViewChanging += svScroll;
            ObjetosVentana.svOpciones.ViewChanging += svScroll;

            ObjetosVentana.botonOpcionesMoverNetflix.Click += MoverNetflix;
            ObjetosVentana.botonOpcionesMoverNetflix.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesMoverNetflix.PointerExited += Animaciones.SaleRatonBoton2;
            ObjetosVentana.botonOpcionesMoverPrimeVideo.Click += MoverPrimeVideo;
            ObjetosVentana.botonOpcionesMoverPrimeVideo.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesMoverPrimeVideo.PointerExited += Animaciones.SaleRatonBoton2;
            ObjetosVentana.botonOpcionesMoverSpotify.Click += MoverSpotify;
            ObjetosVentana.botonOpcionesMoverSpotify.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesMoverSpotify.PointerExited += Animaciones.SaleRatonBoton2;
            ObjetosVentana.botonOpcionesMoverIdioma.Click += MoverIdioma;
            ObjetosVentana.botonOpcionesMoverIdioma.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesMoverIdioma.PointerExited += Animaciones.SaleRatonBoton2;
            ObjetosVentana.botonOpcionesMoverAplicacion.Click += MoverAplicacion;
            ObjetosVentana.botonOpcionesMoverAplicacion.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesMoverAplicacion.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void svScroll(object sender, ScrollViewerViewChangingEventArgs args)
        {
            ScrollViewer sv = sender as ScrollViewer;

            if (sv.VerticalOffset > 150)
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Visible;
            }
            else
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Collapsed;
            }
        }

        public static void SubirArriba(object sender, RoutedEventArgs e)
        {
            NavigationViewItem nvItem = sender as NavigationViewItem;
            nvItem.Visibility = Visibility.Collapsed;

            Grid grid = nvItem.Content as Grid;
            grid.Background = new SolidColorBrush(Colors.Transparent);

            if (ObjetosVentana.gridNetflix.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svNetflixResultados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridDisneyPlus.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svDisneyPlusResultados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridPrimeVideo.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svPrimeVideoResultados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridSpotify.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svSpotifyResultados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridWidgetPrecarga.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svWidgetPrecarga.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridOpciones.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svOpciones.ChangeView(null, 0, null);
            }
        }

        public static void EnseñarSubir(ScrollViewer sv)
        {
            if (sv.VerticalOffset > 50)
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Visible;
            }
            else
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Collapsed;
            }
        }

        public static void MoverNetflix(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.svOpciones.ChangeView(null, ObjetosVentana.expanderOpcionesNetflix.ActualOffset.Y - 40, null);
        }

        public static void MoverPrimeVideo(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.svOpciones.ChangeView(null, ObjetosVentana.expanderOpcionesPrimeVideo.ActualOffset.Y - 40, null);
        }

        public static void MoverSpotify(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.svOpciones.ChangeView(null, ObjetosVentana.expanderOpcionesSpotify.ActualOffset.Y - 40, null);
        }

        public static void MoverIdioma(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.svOpciones.ChangeView(null, ObjetosVentana.expanderOpcionesIdioma.ActualOffset.Y - 40, null);
        }

        public static void MoverAplicacion(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.svOpciones.ChangeView(null, ObjetosVentana.expanderOpcionesAplicacion.ActualOffset.Y - 40, null);
        }
    }
}
