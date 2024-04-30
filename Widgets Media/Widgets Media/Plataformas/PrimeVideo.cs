using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using static Widgets_Media.MainWindow;

namespace Plataformas
{
    public static class PrimeVideo
    {
        public static void Cargar()
        {
            ObjetosVentana.botonPrimeVideoBuscar.Click += BuscarClick;
            ObjetosVentana.botonPrimeVideoBuscar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonPrimeVideoBuscar.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.tbPrimeVideoBuscar.KeyDown += BuscarPulsar;

            ObjetosVentana.cbOpcionesPrimeVideoModo.SelectionChanged += CambiarModoEjecucion;
            ObjetosVentana.cbOpcionesPrimeVideoModo.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbOpcionesPrimeVideoModo.PointerExited += Animaciones.SaleRatonComboCaja2;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
     
            if (datos.Values["OpcionesPrimeVideoModo"] != null)
            {
                if ((int)datos.Values["OpcionesPrimeVideoModo"] == -1)
                {
                    ObjetosVentana.cbOpcionesPrimeVideoModo.SelectedIndex = 0;
                }
                else
                {
                    ObjetosVentana.cbOpcionesPrimeVideoModo.SelectedIndex = (int)datos.Values["OpcionesPrimeVideoModo"];
                }
            }
            else
            {
                ObjetosVentana.cbOpcionesPrimeVideoModo.SelectedIndex = 0;
            }
        }

        private static void CambiarModoEjecucion(object sender, SelectionChangedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesPrimeVideoModo"] = ObjetosVentana.cbOpcionesPrimeVideoModo.SelectedIndex;
        }

        private static void BuscarClick(object sender, RoutedEventArgs e)
        {
            Buscar();
        }

        private static void BuscarPulsar(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                Buscar();
            }
        }

		private static async void Buscar()
		{
			if (ObjetosVentana.tbPrimeVideoBuscar.Text.Trim().Length > 3)
			{
				ActivarDesactivar(false);
				ObjetosVentana.prPrimeVideoResultados.Visibility = Visibility.Visible;

				ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
				ObjetosVentana.gvPrimeVideoResultados.Items.Clear();

				await Task.Delay(100);

				string html = await Decompiladores.CogerHtml("https://www.primevideo.com/search/ref=atv_nb_sr?phrase=" + ObjetosVentana.tbPrimeVideoBuscar.Text.Trim());

				if (html != null)
				{
					int int2 = html.IndexOf("<script type=" + Strings.ChrW(34) + "text/template" + Strings.ChrW(34) + ">");
					string temp2 = html.Remove(0, int2);

					int int3 = temp2.IndexOf(">");
					string temp3 = temp2.Remove(0, int3 + 1);

					int int4 = temp3.IndexOf("</script>");
					string temp4 = temp3.Remove(int4, temp3.Length - int4);

					int i = 0;
					while (i < 40)
					{
						if (temp4.Contains(Strings.ChrW(34) + "displayTitle" + Strings.ChrW(34)) == true)
						{
							int int5 = temp4.IndexOf(Strings.ChrW(34) + "displayTitle" + Strings.ChrW(34));
							string temp5 = temp4.Remove(0, int5 + 5);

							temp4 = temp5;

							int int6 = temp5.IndexOf(":");
							string temp6 = temp5.Remove(0, int6 + 2);

							int int7 = temp6.IndexOf(Strings.ChrW(34));
							string temp7 = temp6.Remove(int7, temp6.Length - int7);

							string titulo = temp7.Trim();

							int int8 = temp4.IndexOf("{" + Strings.ChrW(34) + "cover" + Strings.ChrW(34) + ":{" + Strings.ChrW(34) + "url" + Strings.ChrW(34));
							string temp8 = temp4.Remove(0, int8 + 2);

							int int9 = temp8.IndexOf("https://");
							string temp9 = temp8.Remove(0, int9);

							int int10 = temp9.IndexOf(Strings.ChrW(34) + "}");
							string temp10 = temp9.Remove(int10, temp9.Length - int10);

							string imagen = temp10.Trim();

							int int11 = temp4.IndexOf(Strings.ChrW(34) + "link" + Strings.ChrW(34) + ":{" + Strings.ChrW(34) + "url" + Strings.ChrW(34));
							string temp11 = temp4.Remove(0, int11 + 2);

							int int12 = temp11.IndexOf("/detail/");
							string temp12 = temp11.Remove(0, int12);

							int int13 = temp12.IndexOf(Strings.ChrW(34) + "}");
							string temp13 = temp12.Remove(int13, temp12.Length - int13);

							string enlace = temp13.Trim();

							if (enlace.Contains("ref=") == true)
							{
								int int14 = enlace.IndexOf("ref=");
								enlace = enlace.Remove(int14, enlace.Length - int14);
							}

							if ((int)datos.Values["OpcionesPrimeVideoModo"] == 0)
							{
								enlace = "https://www.primevideo.com" + enlace;
							}
							else if ((int)datos.Values["OpcionesPrimeVideoModo"] == 1)
							{
								string id = enlace;

								id = id.Replace("/detail/", null);
								id = id.Replace("/", null);

								enlace = "primevideo://app/detail?asin=" + id;
							}

							PrimeVideoClase tag = new PrimeVideoClase
							{
								nombre = titulo,
								imagenPequeña = imagen,
								imagenMedianayGrande = imagen,
								enlace = enlace
							};

							ImageEx imagen2 = new ImageEx
							{
								IsCacheEnabled = true,
								EnableLazyLoading = true,
								Stretch = Stretch.UniformToFill,
								Source = imagen,
								CornerRadius = new CornerRadius(2),
								Tag = tag
							};

							imagen2.ImageExFailed += ImagenFalla;

							Button2 botonItem = new Button2
							{
								Content = imagen2,
								Margin = new Thickness(0),
								Padding = new Thickness(0),
								BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
								BorderThickness = new Thickness(2),
								MaxWidth = 350,
								CornerRadius = new CornerRadius(5),
								Tag = tag
							};

							botonItem.Click += ImagenItemClick;
							botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
							botonItem.PointerExited += Animaciones.SaleRatonBoton2;

							TextBlock tbTt = new TextBlock
							{
								Text = titulo
							};

							ToolTipService.SetToolTip(botonItem, tbTt);
							ToolTipService.SetPlacement(botonItem, PlacementMode.Bottom);

							GridViewItem item = new GridViewItem
							{
								Content = botonItem,
								Margin = new Thickness(5, 0, 5, 10)
							};

							ObjetosVentana.gvPrimeVideoResultados.Items.Add(item);
						}

						i += 1;
					}
				}

				ActivarDesactivar(true);
				ObjetosVentana.prPrimeVideoResultados.Visibility = Visibility.Collapsed;
			}
		}

		private static void ImagenFalla(object sender, ImageExFailedEventArgs e)
        {
            ImageEx imagen = (ImageEx)sender;
            PrimeVideoClase streamingImagen = imagen.Tag as PrimeVideoClase;

            int i = 0;
            foreach (GridViewItem item in ObjetosVentana.gvPrimeVideoResultados.Items)
            {
                Button2 boton = item.Content as Button2;
                PrimeVideoClase streamingBoton = boton.Tag as PrimeVideoClase;

                if (streamingBoton.imagenMedianayGrande == streamingImagen.imagenMedianayGrande)
                {
                    break;
                }

                i += 1;
            }

            ObjetosVentana.gvPrimeVideoResultados.Items.RemoveAt(i);
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            PrimeVideoClase streaming = boton.Tag as PrimeVideoClase;

            WidgetPrecarga.PrecargarMedia(streaming.nombre,
                    streaming.enlace, string.Empty,
                    streaming.imagenPequeña,
                    streaming.imagenMedianayGrande);
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.botonPrimeVideoBuscar.IsEnabled = estado;
            ObjetosVentana.tbPrimeVideoBuscar.IsEnabled = estado;
            ObjetosVentana.cbOpcionesPrimeVideoModo.IsEnabled = estado;
        }
    }

    public class PrimeVideoClase
    {
        public string nombre { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenMedianayGrande { get; set; }
        public string enlace { get; set; }
    }
}
