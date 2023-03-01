using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI;
using static Widgets_Media.MainWindow;

namespace Plataformas
{
    public static class DisneyPlus
    {
        public static void Cargar()
        {
            ObjetosVentana.botonDisneyPlusBuscar.Click += BuscarClick;
            ObjetosVentana.botonDisneyPlusBuscar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonDisneyPlusBuscar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static async void BuscarClick(object sender, RoutedEventArgs e)
        {
            if (ObjetosVentana.tbDisneyPlusBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                ObjetosVentana.prDisneyPlusResultados.Visibility = Visibility.Visible;

                ObjetosVentana.gvDisneyPlusResultados.Items.Clear();

                await Task.Delay(100);
                List<string> resultados = Google.Buscar(ObjetosVentana.tbDisneyPlusBuscar.Text.Trim(), "4131afa3b274f44e2");

                if (resultados.Count > 0)
                {
                    foreach (string resultado in resultados)
                    {
                        if (resultado.Contains("disneyplus.com/series") == true || resultado.Contains("disneyplus.com/movies") == true)
                        {
                            string html = await Decompiladores.CogerHtml(resultado);

                            if (html != null)
                            {
                                if (html.Contains("<title>") == true)
                                {
                                    DisneyPlusClase streaming = new DisneyPlusClase();

                                    int int1 = html.IndexOf("<title>");
                                    string temp1 = html.Remove(0, int1 + 7);

                                    int int2 = temp1.IndexOf("</title>");
                                    string temp2 = temp1.Remove(int2, temp1.Length - int2);

                                    temp2 = temp2.Replace(" | Disney+", null);
                                    temp2 = temp2.Replace("Watch", null);

                                    streaming.nombre = temp2.Trim();

                                    if (streaming.nombre != "All Series and TV Shows")
                                    {
                                        int int3 = html.IndexOf("<meta property=" + Strings.ChrW(34) + "og:image" + Strings.ChrW(34));
                                        string temp3 = html.Remove(0, int3);

                                        int int4 = temp3.IndexOf("content=");
                                        string temp4 = temp3.Remove(0, int4 + 9);

                                        int int5 = temp4.IndexOf(Strings.ChrW(34));
                                        string temp5 = temp4.Remove(int5, temp4.Length - int5);

                                        streaming.imagenPequeña = temp5.Trim();

                                        int int6 = html.IndexOf("<meta name=" + Strings.ChrW(34) + "twitter:image" + Strings.ChrW(34));
                                        string temp6 = html.Remove(0, int6);

                                        int int7 = temp6.IndexOf("content=");
                                        string temp7 = temp6.Remove(0, int7 + 9);

                                        int int8 = temp7.IndexOf(Strings.ChrW(34));
                                        string temp8 = temp7.Remove(int8, temp7.Length - int8);

                                        streaming.imagenMedianayGrande = temp8.Trim();

                                        streaming.enlace = resultado;

                                        ImageEx imagen = new ImageEx
                                        {
                                            IsCacheEnabled = true,
                                            EnableLazyLoading = true,
                                            Stretch = Stretch.UniformToFill,
                                            Source = streaming.imagenPequeña,
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
                                            MaxWidth = 350,
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

                                        ObjetosVentana.gvDisneyPlusResultados.Items.Add(item);
                                    }
                                }
                            }
                        }
                    }
                }

                ActivarDesactivar(true);
                ObjetosVentana.prDisneyPlusResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            DisneyPlusClase streaming = boton.Tag as DisneyPlusClase;

            WidgetPrecarga.PrecargarMedia(streaming.nombre,
                    streaming.enlace, string.Empty,
                    streaming.imagenPequeña,
                    streaming.imagenMedianayGrande);
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.botonDisneyPlusBuscar.IsEnabled = estado;
            ObjetosVentana.tbDisneyPlusBuscar.IsEnabled = estado;
        }
    }

    public class DisneyPlusClase
    {
        public string nombre { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenMedianayGrande { get; set; }
        public string enlace { get; set; }
    }
}
