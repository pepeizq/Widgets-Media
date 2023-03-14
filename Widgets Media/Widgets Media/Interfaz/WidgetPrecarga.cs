using Herramientas;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using Plantillas;
using System;
using System.Text.Json;
using System.Threading;
using Windows.ApplicationModel.DataTransfer;
using Windows.System;
using Windows.UI;
using static Widgets_Media.MainWindow;

namespace Interfaz
{
    public class WidgetPrecarga
    {
        public static void Cargar()
        {
            int i = 0;
            foreach (object boton in ObjetosVentana.spWidgetPrecargaBotones.Children)
            {
                if (boton.GetType() == typeof(Button2))
                {
                    Button2 boton2 = (Button2)boton;

                    boton2.Tag = i;
                    boton2.Click += CambiarPestaña;
                    boton2.PointerEntered += Animaciones.EntraRatonBoton2;
                    boton2.PointerExited += Animaciones.SaleRatonBoton2;

                    i += 1;
                }
            }

            //---------------------------------

            ObjetosVentana.tbWidgetPrecargaEjecutable.TextChanged += ActivarBotonCargaStreaming;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.TextChanged += ActualizarImagenPequeña;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.TextChanged += ActualizarImagenGrande;

            //---------------------------------

            ObjetosVentana.cbWidgetPrecargaImagen.SelectionChanged += CambiarImagenElegida;
            ObjetosVentana.cbWidgetPrecargaImagen.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagen.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;

            //---------------------------------

            ObjetosVentana.botonWidgetPrecargaCargarStreaming.Click += CargarMedia;
            ObjetosVentana.botonWidgetPrecargaCargarStreaming.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonWidgetPrecargaCargarStreaming.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.Click += AbrirAyuda;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void CambiarPestaña(object sender, RoutedEventArgs e)
        {
            Button2 botonPulsado = sender as Button2;
            int pestañaMostrar = (int)botonPulsado.Tag;
            CambiarPestaña(pestañaMostrar);
        }

        private static void CambiarPestaña(int botonPulsado)
        {
            SolidColorBrush colorPulsado = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]);
            colorPulsado.Opacity = 0.6;

            int i = 0;
            foreach (object boton in ObjetosVentana.spWidgetPrecargaBotones.Children)
            {
                if (boton.GetType() == typeof(Button2))
                {
                    Button2 boton2 = (Button2)boton;

                    if (i == botonPulsado)
                    {
                        boton2.Background = colorPulsado;
                    }
                    else
                    {
                        boton2.Background = new SolidColorBrush(Colors.Transparent);
                    }

                    i += 1;
                }                  
            }

            foreach (StackPanel sp in ObjetosVentana.spWidgetPrecargaPestañas.Children)
            {
                sp.Visibility = Visibility.Collapsed;
            }

            StackPanel spMostrar = ObjetosVentana.spWidgetPrecargaPestañas.Children[botonPulsado] as StackPanel;
            spMostrar.Visibility = Visibility.Visible;
        }

        private static void ActivarBotonCargaStreaming(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaStreaming();
        }

        private static void ActualizarImagenPequeña(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaStreaming();

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
            }
        }

        private static void ActualizarImagenGrande(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaStreaming();

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text;
            }
        }

        private static async void ActivarBotonCargaStreaming()
        {
            bool activar1 = false;
            bool activar2 = false;
            bool activar3 = false;

            if (ObjetosVentana.tbWidgetPrecargaEjecutable.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim().Length > 0)
                {
                    activar1 = true;
                }
            }

            if (ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text.Trim().Length > 0)
                {
                    activar2 = true;
                }
                else
                {
                    activar2 = false;
                }
            }
            else
            {
                activar2 = false;
            }

            if (ObjetosVentana.tbWidgetPrecargaImagenGrande.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaImagenGrande.Text.Trim().Length > 0)
                {
                    activar3 = true;
                }
                else
                {
                    activar3 = false;
                }
            }
            else
            {
                activar3 = false;
            }


            if (activar1 == true)
            {
                if (activar2 == true || activar3 == true)
                {
                    ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = true;
                }
                else
                {
                    ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = false;
                }               
            }
            else
            {
                ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = false;
            }

            //-----------------------------------------------------

            //if (ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled == true)
            //{
            //    if (await Trial.Detectar() == true)
            //    {
            //        if (await Ficheros.LeerCantidadFicheros() < 1)
            //        {
            //            ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = true;
            //        }
            //        else
            //        {
            //            ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = false;
            //        }
            //    }
            //}
        }

        private static void CambiarImagenElegida(object sender, SelectionChangedEventArgs e)
        {           
            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {               
                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
                }
                catch { }
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text;
                }
                catch { }
            }
        }

        public static void PrecargarMedia(string nombre, string ejecutable, string argumentos, string imagenPequeña, string imagenMedianaGrande)
        {
            Pestañas.Visibilidad(ObjetosVentana.gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            if (nombre != null)
            {
                CambiarPestaña(1);
                ObjetosVentana.tbWidgetPrecargaTitulo.Text = nombre;
                ObjetosVentana.tbWidgetPrecargaTitulo.Visibility = Visibility.Visible;
            }
            else
            {
                CambiarPestaña(0);
                ObjetosVentana.tbWidgetPrecargaTitulo.Visibility = Visibility.Collapsed;
            }

            ObjetosVentana.tbWidgetPrecargaEjecutable.Text = ejecutable;

            if (imagenPequeña != null) 
            {
                ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text = imagenPequeña.Trim();
            }
            else
            {
                ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text = null;
            }

            if (imagenMedianaGrande != null)
            {
                ObjetosVentana.tbWidgetPrecargaImagenGrande.Text = imagenMedianaGrande.Trim();
            }
            else
            {
                ObjetosVentana.tbWidgetPrecargaImagenGrande.Text = null;
            }

            ActivarBotonCargaStreaming();

            if (imagenPequeña == string.Empty && imagenMedianaGrande != string.Empty)
            {
                ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex = 1;
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text;
            }
            else
            {
                ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex = 0;
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
            }           

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex = 1;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex = 1;

            ObjetosVentana.tbWidgetCargarStreamingMensaje.Visibility = Visibility.Collapsed;
        }

        public static void CargarMedia(object sender, RoutedEventArgs e)
        {
            ActivarDesactivar(false);

            string plantilla = Ficheros.LeerFicheroDentroAplicacion("ms-appx:///Plantillas/Media.json");

            Media json = JsonSerializer.Deserialize<Media>(plantilla);
            json.enlace = ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim();
            
            //------------------------------------------------

            string imagen = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                imagen = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text.Trim();
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                imagen = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text.Trim();
            }

            json.fondo.url = imagen;

            //------------------------------------------------

            string horizontal = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex == 0) 
            {
                horizontal = "Left";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex == 1)
            {
                horizontal = "Center";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex == 2)
            {
                horizontal = "Right";
            }

            json.fondo.horizontal = horizontal;

            //------------------------------------------------

            string vertical = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex == 0)
            {
                vertical = "Top";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex == 1)
            {
                vertical = "Center";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex == 2)
            {
                vertical = "Bottom";
            }

            json.fondo.vertical = vertical;

            //------------------------------------------------

            Ficheros.EscribirFichero("Media.json", JsonSerializer.Serialize(json));

            ObjetosVentana.tbWidgetCargarStreamingMensaje.Visibility = Visibility.Visible;
            ResourceLoader recursos = new ResourceLoader();
            ObjetosVentana.tbWidgetCargarStreamingMensaje.Text = recursos.GetString("WidgetLoadStreamingMessage");

            ActivarBotonCargaStreaming();

            ActivarDesactivar(true);
        }

        private static async void AbrirAyuda(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/app/widgets-for-streaming/#guide"));
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.tbWidgetPrecargaEjecutable.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.IsEnabled = estado;

            ObjetosVentana.cbWidgetPrecargaImagen.IsEnabled = estado;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.IsEnabled = estado;

            ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = estado;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.IsEnabled = estado;
        }
    }
}
