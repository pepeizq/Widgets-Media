using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using static Widgets_Media.MainWindow;

namespace Plataformas
{
    public static class Netflix
    {
        public static void Cargar()
        {
            ObjetosVentana.botonNetflixBuscar.Click += BuscarClick;
            ObjetosVentana.botonNetflixBuscar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonNetflixBuscar.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.cbOpcionesNetflixModo.SelectionChanged += CambiarModoEjecucion;
            ObjetosVentana.cbOpcionesNetflixModo.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbOpcionesNetflixModo.PointerExited += Animaciones.SaleRatonComboCaja2;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
           
            if ((int)datos.Values["OpcionesNetflixModo"] == -1)
            {
                ObjetosVentana.cbOpcionesNetflixModo.SelectedIndex = 0;
            }
            else
            {
                ObjetosVentana.cbOpcionesNetflixModo.SelectedIndex = (int)datos.Values["OpcionesNetflixModo"];
            }
        }

        private static void CambiarModoEjecucion(object sender, SelectionChangedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesNetflixModo"] = ObjetosVentana.cbOpcionesNetflixModo.SelectedIndex;
        }

        private static async void BuscarClick(object sender, RoutedEventArgs e)
        {
            if (ObjetosVentana.tbNetflixBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                ObjetosVentana.prNetflixResultados.Visibility = Visibility.Visible;

                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                ObjetosVentana.gvNetflixResultados.Items.Clear();

                await Task.Delay(100);
                List<string> resultados = Google.Buscar(ObjetosVentana.tbNetflixBuscar.Text.Trim(), "e6760ff33b21c479a", "netflix");

                if (resultados.Count > 0)
                {
                    foreach (string resultado in resultados)
                    {
                        if (resultado.Contains("netflix.com/title/") == true)
                        {
                            NetflixClase streaming = new NetflixClase();

                            string id = resultado;
                            id = id.Replace("https://www.netflix.com/title/", null);

                            string htmlAPI = await Decompiladores.CogerHtml("https://unogs.com/api/title/detail?netflixid=" + id);

                            if (htmlAPI != null) 
                            {
                                List<NetflixAPIDatos> json = JsonConvert.DeserializeObject<List<NetflixAPIDatos>>(htmlAPI);

                                if (json != null)
                                {
                                    if (json.Count > 0) 
                                    {
                                        streaming.nombre = json[0].titulo;

                                        string htmlAPI2 = await Decompiladores.CogerHtml("https://unogs.com/api/title/bgimages?netflixid=" + id);

                                        NetflixAPIImagenes json2 = JsonConvert.DeserializeObject<NetflixAPIImagenes>(htmlAPI2);

                                        if (json2 != null)
                                        {
                                            if (json2.imagenesAnchas != null && json2.imagenesVerticales != null)
                                            {
                                                streaming.imagenPequeña = json2.imagenesAnchas[0].enlace;
                                                streaming.imagenMedianayGrande = json2.imagenesVerticales[0].enlace;

                                                if ((int)datos.Values["OpcionesNetflixModo"] == 0)
                                                {
                                                    streaming.enlace = resultado;
                                                }
                                                else if ((int)datos.Values["OpcionesNetflixModo"] == 1)
                                                {
                                                    streaming.enlace = "netflix:/app?playVideoId=" + id;
                                                }
 
                                                ImageEx imagen = new ImageEx
                                                {
                                                    IsCacheEnabled = true,
                                                    EnableLazyLoading = true,
                                                    Stretch = Stretch.UniformToFill,
                                                    Source = streaming.imagenMedianayGrande,
                                                    CornerRadius = new CornerRadius(2)
                                                };

                                                Button2 botonItem = new Button2
                                                {
                                                    Content = imagen,
                                                    Margin = new Thickness(0),
                                                    Padding = new Thickness(0),
                                                    BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                                                    BorderThickness = new Thickness(2),
                                                    Tag = streaming,
                                                    MaxWidth = 250,
                                                    CornerRadius = new CornerRadius(5)
                                                };

                                                botonItem.Click += ImagenItemClick;
                                                botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
                                                botonItem.PointerExited += Animaciones.SaleRatonBoton2;

                                                TextBlock tbTt = new TextBlock
                                                {
                                                    Text = streaming.nombre
                                                };

                                                ToolTipService.SetToolTip(botonItem, tbTt);
                                                ToolTipService.SetPlacement(botonItem, PlacementMode.Bottom);

                                                GridViewItem item = new GridViewItem
                                                {
                                                    Content = botonItem,
                                                    Margin = new Thickness(5, 0, 5, 10)
                                                };

                                                ObjetosVentana.gvNetflixResultados.Items.Add(item);
                                            }
                                        }
                                    }
                                }                                
                            }
                        }
                    }
                }

                ActivarDesactivar(true);
                ObjetosVentana.prNetflixResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            NetflixClase streaming = boton.Tag as NetflixClase;

            WidgetPrecarga.PrecargarMedia(streaming.nombre,
                    streaming.enlace, string.Empty,
                    streaming.imagenPequeña,
                    streaming.imagenMedianayGrande);
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.botonNetflixBuscar.IsEnabled = estado;
            ObjetosVentana.tbNetflixBuscar.IsEnabled = estado;
            ObjetosVentana.cbOpcionesNetflixModo.IsEnabled = estado;
        }
    }

    public class NetflixClase
    {
        public string nombre { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenMedianayGrande { get; set; }
        public string enlace { get; set; }
    }
}
