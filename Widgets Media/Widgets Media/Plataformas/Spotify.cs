using CommunityToolkit.WinUI.UI.Controls;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using SpotifyAPI.Web;
using Windows.UI;
using static Widgets_Media.MainWindow;

namespace Plataformas
{
    public static class Spotify
    {
        public static void Cargar()
        {
            ObjetosVentana.botonSpotifyBuscar.Click += BuscarClick;
            ObjetosVentana.botonSpotifyBuscar.PointerEntered += Animaciones.EntraRatonBoton2; 
            ObjetosVentana.botonSpotifyBuscar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static async void BuscarClick(object sender, RoutedEventArgs e)
        {
            if (ObjetosVentana.tbSpotifyBuscar.Text.Trim().Length > 3)
            {
                ObjetosVentana.prSpotifyResultados.Visibility = Visibility.Visible;

                SpotifyClientConfig config = SpotifyClientConfig.CreateDefault();

                ClientCredentialsRequest request = new ClientCredentialsRequest("38765b5a6e7a49bf895afb49feaa217b", "61273877740243bfb0fe08e3d789eab8");
                ClientCredentialsTokenResponse response = await new OAuthClient(config).RequestToken(request);

                SpotifyClient cliente = new SpotifyClient(config.WithToken(response.AccessToken));

                SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Album, ObjetosVentana.tbSpotifyBuscar.Text.Trim())
                {
                    Limit = 50
                };

                SearchResponse resultados = await cliente.Search.Item(busqueda);

                foreach (SimpleAlbum album in resultados.Albums.Items) 
                {
                    ImageEx imagen = new ImageEx
                    {
                        IsCacheEnabled = true,
                        EnableLazyLoading = true,
                        Stretch = Stretch.UniformToFill,
                        Source = album.Images[0].Url,
                        CornerRadius = new CornerRadius(2)
                    };

                    Button2 botonAlbum = new Button2
                    {
                        Content = imagen,
                        Margin = new Thickness(0),
                        Padding = new Thickness(0),
                        BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                        BorderThickness = new Thickness(2),
                        Tag = album,
                        MaxWidth = 300,
                        CornerRadius = new CornerRadius(5)
                    };

                    botonAlbum.Click += ImagenAlbumClick;
                    botonAlbum.PointerEntered += Animaciones.EntraRatonBoton2;
                    botonAlbum.PointerExited += Animaciones.SaleRatonBoton2;

                    GridViewItem item = new GridViewItem
                    {
                        Content = botonAlbum,
                        Margin = new Thickness(5, 0, 5, 10)
                    };

                    ObjetosVentana.gvSpotifyResultados.Items.Add(item);
                }

                ObjetosVentana.prSpotifyResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static void ImagenAlbumClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            SimpleAlbum album = boton.Tag as SimpleAlbum;

            WidgetPrecarga.PrecargarMedia(album.Name,
                    album.Uri, string.Empty,
                    album.Images[0].Url,
                    album.Images[0].Url);
        }
    }
}
