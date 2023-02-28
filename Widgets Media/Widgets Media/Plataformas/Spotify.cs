using CommunityToolkit.WinUI.UI.Controls;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using SpotifyAPI.Web;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using static Widgets_Media.MainWindow;

namespace Plataformas
{
    public static class Spotify
    {
        public static void Cargar()
        {
            ObjetosVentana.cbSpotifyTipoBuscar.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbSpotifyTipoBuscar.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.botonSpotifyBuscar.Click += BuscarClick;
            ObjetosVentana.botonSpotifyBuscar.PointerEntered += Animaciones.EntraRatonBoton2; 
            ObjetosVentana.botonSpotifyBuscar.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.cbOpcionesSpotifyModo.SelectionChanged += CambiarModoEjecucion;
            ObjetosVentana.cbOpcionesSpotifyModo.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbOpcionesSpotifyModo.PointerExited += Animaciones.SaleRatonComboCaja2;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;

            if ((int)datos.Values["OpcionesSpotifyModo"] == -1)
            {
                ObjetosVentana.cbOpcionesSpotifyModo.SelectedIndex = 0;
            }
            else
            {
                ObjetosVentana.cbOpcionesSpotifyModo.SelectedIndex = (int)datos.Values["OpcionesSpotifyModo"];
            }

            ObjetosVentana.botonOpcionesSpotifyAbrirAyuda.Click += AbrirAyudaClick;
            ObjetosVentana.botonOpcionesSpotifyAbrirAyuda.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesSpotifyAbrirAyuda.PointerExited += Animaciones.SaleRatonBoton2;

            if (datos.Values["OpcionesSpotifyClienteID"] == null)
            {
                ObjetosVentana.tbOpcionesSpotifyClienteID.Text = null;
            }
            else
            {
                ObjetosVentana.tbOpcionesSpotifyClienteID.Text = datos.Values["OpcionesSpotifyClienteID"].ToString();
            }
            
            ObjetosVentana.tbOpcionesSpotifyClienteID.TextChanged += DetectarClienteID;

            if (datos.Values["OpcionesSpotifyClienteSecreto"] == null)
            {
                ObjetosVentana.tbOpcionesSpotifyClienteSecreto.Text = null;
            }
            else
            {
                ObjetosVentana.tbOpcionesSpotifyClienteSecreto.Text = datos.Values["OpcionesSpotifyClienteSecreto"].ToString();
            }

            ObjetosVentana.tbOpcionesSpotifyClienteSecreto.TextChanged += DetectarClienteSecreto;

            ObjetosVentana.botonSpotifyIrOpciones.Click += AbrirOpcionesClick;
            ObjetosVentana.botonSpotifyIrOpciones.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonSpotifyIrOpciones.PointerExited += Animaciones.SaleRatonBoton2;

            ComprobarConexionOpciones();
        }

        private static void CambiarModoEjecucion(object sender, SelectionChangedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesSpotifyModo"] = ObjetosVentana.cbOpcionesSpotifyModo.SelectedIndex;
        }

        private static async void AbrirAyudaClick(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            ImageEx imagen = new ImageEx
            {
                Source = "Assets\\Ayuda\\spotify.png",
                IsCacheEnabled = true,
                EnableLazyLoading = true,
                CornerRadius = new CornerRadius(5),
                Width = 880,
                Height = 573
            };

            ContentDialog ventana = new ContentDialog
            {
                RequestedTheme = ElementTheme.Dark,
                SecondaryButtonText = recursos.GetString("SpotifyOptionsOpenLink"),
                CloseButtonText = recursos.GetString("Close"),
                Content = imagen,
                XamlRoot = ObjetosVentana.ventana.Content.XamlRoot
            };

            ventana.SecondaryButtonClick += AbrirEnlace;

            await ventana.ShowAsync();
        }

        private static async void AbrirEnlace(ContentDialog ventana, ContentDialogButtonClickEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://developer.spotify.com/dashboard/applications"));
        }

        private static void AbrirOpcionesClick(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pestañas.Visibilidad(ObjetosVentana.gridOpciones, true, null, false);
            BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
            ScrollViewers.EnseñarSubir(ObjetosVentana.svOpciones);
        }

        private static void DetectarClienteID(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0) 
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesSpotifyClienteID"] = tb.Text;
                ComprobarConexionOpciones();
            }
        }

        private static void DetectarClienteSecreto(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0)
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesSpotifyClienteSecreto"] = tb.Text;
                ComprobarConexionOpciones();
            }
        }

        private static async void ComprobarConexionOpciones()
        {
            if (ObjetosVentana.tbOpcionesSpotifyClienteID.Text.Trim().Length > 0 && ObjetosVentana.tbOpcionesSpotifyClienteSecreto.Text.Trim().Length > 0)
            {
                ActivarDesactivar(false);

                SpotifyClient cliente = await ComprobarConexion();

                if (cliente != null) 
                {
                    ObjetosVentana.gridSpotifyBuscador.Visibility = Visibility.Visible;
                    ObjetosVentana.gridSpotifyMensajeOpciones.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ObjetosVentana.gridSpotifyBuscador.Visibility = Visibility.Collapsed;
                    ObjetosVentana.gridSpotifyMensajeOpciones.Visibility = Visibility.Visible;
                }

                ActivarDesactivar(true);
            }
        }

        private static async Task<SpotifyClient> ComprobarConexion()
        {
            try
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                SpotifyClientConfig config = SpotifyClientConfig.CreateDefault();

                ClientCredentialsRequest request = new ClientCredentialsRequest(datos.Values["OpcionesSpotifyClienteID"].ToString(), datos.Values["OpcionesSpotifyClienteSecreto"].ToString());
                ClientCredentialsTokenResponse response = await new OAuthClient(config).RequestToken(request);

                SpotifyClient cliente = new SpotifyClient(config.WithToken(response.AccessToken));
                return cliente;
            }
            catch { }

            return null;
        }

        private static async void BuscarClick(object sender, RoutedEventArgs e)
        {
            if (ObjetosVentana.tbSpotifyBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                ObjetosVentana.prSpotifyResultados.Visibility = Visibility.Visible;

                SpotifyClient cliente = await ComprobarConexion();

                if (cliente != null) 
                {
                    if (ObjetosVentana.cbSpotifyTipoBuscar.SelectedIndex == 0)
                    {
                        SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Album, ObjetosVentana.tbSpotifyBuscar.Text.Trim())
                        {
                            Limit = 50
                        };

                        SearchResponse resultados = await cliente.Search.Item(busqueda);

                        ObjetosVentana.gvSpotifyResultados.Items.Clear();

                        foreach (SimpleAlbum album in resultados.Albums.Items)
                        {
                            ObjetosVentana.gvSpotifyResultados.Items.Add(GenerarItem(album.Images[0].Url, album.Name, album));
                        }
                    }
                    else if (ObjetosVentana.cbSpotifyTipoBuscar.SelectedIndex == 1)
                    {
                        SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Playlist, ObjetosVentana.tbSpotifyBuscar.Text.Trim())
                        {
                            Limit = 50
                        };

                        SearchResponse resultados = await cliente.Search.Item(busqueda);

                        ObjetosVentana.gvSpotifyResultados.Items.Clear();

                        foreach (SimplePlaylist plist in resultados.Playlists.Items)
                        {
                            ObjetosVentana.gvSpotifyResultados.Items.Add(GenerarItem(plist.Images[0].Url, plist.Name, plist));
                        }
                    }
                    else if (ObjetosVentana.cbSpotifyTipoBuscar.SelectedIndex == 2)
                    {
                        SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Artist, ObjetosVentana.tbSpotifyBuscar.Text.Trim())
                        {
                            Limit = 50
                        };

                        SearchResponse resultados = await cliente.Search.Item(busqueda);

                        ObjetosVentana.gvSpotifyResultados.Items.Clear();

                        foreach (FullArtist pista in resultados.Artists.Items)
                        {
                            ObjetosVentana.gvSpotifyResultados.Items.Add(GenerarItem(pista.Images[0].Url, pista.Name, pista));
                        }
                    }
                }

                ActivarDesactivar(true);
                ObjetosVentana.prSpotifyResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static GridViewItem GenerarItem(string imagenEnlace, string nombre, object tag)
        {
            ImageEx imagen = new ImageEx
            {
                IsCacheEnabled = true,
                EnableLazyLoading = true,
                Stretch = Stretch.UniformToFill,
                Source = imagenEnlace,
                CornerRadius = new CornerRadius(2)
            };

            Button2 botonItem = new Button2
            {
                Content = imagen,
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                BorderThickness = new Thickness(2),
                Tag = tag,
                MaxWidth = 300,
                CornerRadius = new CornerRadius(5)
            };

            botonItem.Click += ImagenItemClick;
            botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
            botonItem.PointerExited += Animaciones.SaleRatonBoton2;

            TextBlock tbTt = new TextBlock
            {
                Text = nombre
            };

            ToolTipService.SetToolTip(botonItem, tbTt);
            ToolTipService.SetPlacement(botonItem, PlacementMode.Bottom);

            GridViewItem item = new GridViewItem
            {
                Content = botonItem,
                Margin = new Thickness(5, 0, 5, 10)
            };

            return item;
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            Button boton = sender as Button;

            if (boton.Tag.GetType() == typeof(SimpleAlbum))
            {
                SimpleAlbum album = boton.Tag as SimpleAlbum;

                string enlace = album.Uri;

                if ((int)datos.Values["OpcionesSpotifyModo"] == 0)
                {
                    enlace = enlace.Replace("spotify:album:", "https://open.spotify.com/album/");
                }

                WidgetPrecarga.PrecargarMedia(album.Name,
                        enlace, string.Empty,
                        album.Images[0].Url,
                        album.Images[1].Url);
            }
            else if (boton.Tag.GetType() == typeof(SimplePlaylist))
            {
                SimplePlaylist plist = boton.Tag as SimplePlaylist;

                string enlace = plist.Uri;

                if ((int)datos.Values["OpcionesSpotifyModo"] == 0)
                {
                    enlace = enlace.Replace("spotify:playlist:", "https://open.spotify.com/playlist/");
                }

                WidgetPrecarga.PrecargarMedia(plist.Name,
                        enlace, string.Empty,
                        plist.Images[0].Url,
                        plist.Images[1].Url);
            }
            else if (boton.Tag.GetType() == typeof(FullArtist))
            {
                FullArtist artista = boton.Tag as FullArtist;

                string enlace = artista.Uri;

                if ((int)datos.Values["OpcionesSpotifyModo"] == 0)
                {
                    enlace = enlace.Replace("spotify:artist:", "https://open.spotify.com/artist/");
                }

                WidgetPrecarga.PrecargarMedia(artista.Name,
                        enlace, string.Empty,
                        artista.Images[0].Url,
                        artista.Images[1].Url);
            }
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.cbSpotifyTipoBuscar.IsEnabled = estado;
            ObjetosVentana.botonSpotifyBuscar.IsEnabled = estado;
            ObjetosVentana.cbOpcionesSpotifyModo.IsEnabled = estado;
            ObjetosVentana.tbSpotifyBuscar.IsEnabled = estado;
            ObjetosVentana.tbOpcionesSpotifyClienteID.IsEnabled = estado;
            ObjetosVentana.tbOpcionesSpotifyClienteSecreto.IsEnabled = estado;
        }
    }
}
