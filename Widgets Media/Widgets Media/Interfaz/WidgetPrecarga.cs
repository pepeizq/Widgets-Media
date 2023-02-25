using Herramientas;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plantillas;
using System.Text.Json;
using static Widgets_Media.MainWindow;

namespace Interfaz
{
    public class WidgetPrecarga
    {
        public static void Cargar()
        {
            ObjetosVentana.tbWidgetPrecargaEjecutable.TextChanged += ActivarBotonCargaStreaming;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.TextChanged += ActualizarImagenPequeña;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.TextChanged += ActualizarImagenGrande;

            ObjetosVentana.cbWidgetPrecargaImagen.SelectionChanged += CambiarImagenElegida;
            ObjetosVentana.cbWidgetPrecargaImagen.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagen.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.botonWidgetPrecargaCargarStreaming.Click += CargarMedia;
            ObjetosVentana.botonWidgetPrecargaCargarStreaming.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonWidgetPrecargaCargarStreaming.PointerExited += Animaciones.SaleRatonBoton2;
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

            if (ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled == true)
            {
                if (await Trial.Detectar() == true)
                {
                    if (await Ficheros.LeerCantidadFicheros() < 1)
                    {
                        ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = true;
                    }
                    else
                    {
                        ObjetosVentana.botonWidgetPrecargaCargarStreaming.IsEnabled = false;
                    }
                }
            }
        }

        private static void CambiarImagenElegida(object sender, SelectionChangedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                ObjetosVentana.tbWidgetPrecargaMensajeImagen.Text = recursos.GetString("ChooseImageSmall");
                
                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
                }
                catch { }
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                ObjetosVentana.tbWidgetPrecargaMensajeImagen.Text = recursos.GetString("ChooseImageBig");

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
                ObjetosVentana.expanderWidgetPrecargaDatos.IsExpanded = false;
                ObjetosVentana.tbWidgetPrecargaTitulo.Text = nombre;
                ObjetosVentana.tbWidgetPrecargaTitulo.Visibility = Visibility.Visible;
            }
            else
            {
                ObjetosVentana.expanderWidgetPrecargaDatos.IsExpanded = true;
                ObjetosVentana.tbWidgetPrecargaTitulo.Visibility = Visibility.Collapsed;
            }

            ObjetosVentana.tbWidgetPrecargaEjecutable.Text = ejecutable;
            ObjetosVentana.tbWidgetPrecargaArgumentos.Text = argumentos;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text = imagenPequeña;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.Text = imagenMedianaGrande;

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

            if (ObjetosVentana.tbWidgetPrecargaArgumentos.Text.Trim().Length > 0)
            {
                json.argumentos = ObjetosVentana.tbWidgetPrecargaArgumentos.Text.Trim();
            }
            
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

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.tbWidgetPrecargaEjecutable.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaArgumentos.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.IsEnabled = estado;

            ObjetosVentana.cbWidgetPrecargaImagen.IsEnabled = estado;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.IsEnabled = estado;
        }
    }
}
