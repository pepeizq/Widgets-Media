﻿using Microsoft.UI;
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

            ObjetosVentana.svPresentacion.ViewChanging += MoverScroll;
            ObjetosVentana.svNetflixResultados.ViewChanging += MoverScroll;
            ObjetosVentana.svDisneyPlusResultados.ViewChanging += MoverScroll;
            ObjetosVentana.svPrimeVideoResultados.ViewChanging += MoverScroll;
            ObjetosVentana.svSpotifyResultados.ViewChanging += MoverScroll;
            ObjetosVentana.svWidgetPrecarga.ViewChanging += MoverScroll;
            ObjetosVentana.svOpciones.ViewChanging += MoverScroll;
        }

        private static void MoverScroll(object sender, ScrollViewerViewChangingEventArgs args)
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
    }
}
