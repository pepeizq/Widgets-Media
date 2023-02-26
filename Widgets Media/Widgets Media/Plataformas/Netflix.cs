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
    public static class Netflix
    {
        public static void Cargar()
        {
            ObjetosVentana.botonNetflixBuscar.Click += BuscarClick;
            ObjetosVentana.botonNetflixBuscar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonNetflixBuscar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static async void BuscarClick(object sender, RoutedEventArgs e)
        {
            if (ObjetosVentana.tbNetflixBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                ObjetosVentana.prNetflixResultados.Visibility = Visibility.Visible;

                await Task.Delay(100);
                List<string> resultados = Google.Buscar(ObjetosVentana.tbNetflixBuscar.Text.Trim());

                if (resultados.Count > 0)
                {
                    foreach (string resultado in resultados)
                    {
                        if (resultado.Contains("netflix.com/title/") == true)
                        {
                            string html = await Decompiladores.CogerHtml(resultado);

                            if (html != null)
                            {
                                if (html.Contains("application/ld+json") == true)
                                {
                                    int int1 = html.IndexOf(Strings.ChrW(34) + "name" + Strings.ChrW(34));
                                    string temp1 = html.Remove(0, int1 + 6);

                                    int int2 = temp1.IndexOf(Strings.ChrW(34));
                                    string temp2 = temp1.Remove(0, int2 + 1);

                                    int int3 = temp2.IndexOf(Strings.ChrW(34));
                                    temp2 = temp2.Remove(int3, temp2.Length - int3);

                                    int int4 = html.IndexOf(Strings.ChrW(34) + "image" + Strings.ChrW(34));
                                    string temp4 = html.Remove(0, int4 + 7);

                                    int int5 = temp4.IndexOf(Strings.ChrW(34));
                                    string temp5 = temp4.Remove(0, int5 + 1);

                                    int int6 = temp5.IndexOf(Strings.ChrW(34));
                                    temp5 = temp5.Remove(int6, temp5.Length - int6);

                                    ImageEx imagen = new ImageEx
                                    {
                                        IsCacheEnabled = true,
                                        EnableLazyLoading = true,
                                        Stretch = Stretch.UniformToFill,
                                        Source = temp5.Trim(),
                                        CornerRadius = new CornerRadius(2)
                                    };

                                    Button2 botonItem = new Button2
                                    {
                                        Content = imagen,
                                        Margin = new Thickness(0),
                                        Padding = new Thickness(0),
                                        BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                                        BorderThickness = new Thickness(2),
                                        MaxWidth = 300,
                                        CornerRadius = new CornerRadius(5)
                                    };

                                    //botonItem.Click += ImagenItemClick;
                                    botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
                                    botonItem.PointerExited += Animaciones.SaleRatonBoton2;

                                    TextBlock tbTt = new TextBlock
                                    {
                                        Text = temp2.Trim()
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

                ActivarDesactivar(true);
                ObjetosVentana.prNetflixResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.botonNetflixBuscar.IsEnabled = estado;
            ObjetosVentana.tbNetflixBuscar.IsEnabled = estado;
        }
    }
}
