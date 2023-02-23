using CommunityToolkit.WinUI.UI.Controls;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;

namespace Widgets_Media
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            CargarObjetosVentana();

            BarraTitulo.Generar(this);
            BarraTitulo.CambiarTitulo(null);
            Pestañas.Cargar();
            ScrollViewers.Cargar();
            Interfaz.Menu.Cargar();
            Trial.Cargar();
            Plataformas.Spotify.Cargar();
            WidgetPrecarga.Cargar();
            Opciones.CargarDatos();

            Pestañas.Visibilidad(gridPresentacion, true, null, false);
        }

        public void CargarObjetosVentana()
        {
            ObjetosVentana.ventana = ventana;
            ObjetosVentana.gridTitulo = gridTitulo;
            ObjetosVentana.tbTitulo = tbTitulo;
            ObjetosVentana.nvPrincipal = nvPrincipal;
            ObjetosVentana.nvItemMenu = nvItemMenu;
            ObjetosVentana.menuItemMenu = menuItemMenu;
            ObjetosVentana.nvItemOpciones = nvItemOpciones;
            ObjetosVentana.nvItemSubirArriba = nvItemSubirArriba;

            //-------------------------------------------------------------------

            ObjetosVentana.gridPresentacion = gridPresentacion;
            ObjetosVentana.gridSpotify = gridSpotify;
            ObjetosVentana.gridWidgetPrecarga = gridWidgetPrecarga;
            ObjetosVentana.gridOpciones = gridOpciones;

            //-------------------------------------------------------------------

            ObjetosVentana.svPresentacion = svPresentacion;
            ObjetosVentana.gvPresentacionPlataformas = gvPresentacionPlataformas;
            ObjetosVentana.spPresentacionTrial = spPresentacionTrial;
            ObjetosVentana.botonPresentacionTrialComprar = botonPresentacionTrialComprar;

            //-------------------------------------------------------------------

            ObjetosVentana.gridSpotifyBuscador = gridSpotifyBuscador;
            ObjetosVentana.cbSpotifyTipoBuscar = cbSpotifyTipoBuscar;
            ObjetosVentana.botonSpotifyBuscar = botonSpotifyBuscar;
            ObjetosVentana.tbSpotifyBuscar = tbSpotifyBuscar;
            ObjetosVentana.svSpotifyResultados = svSpotifyResultados;
            ObjetosVentana.prSpotifyResultados = prSpotifyResultados;
            ObjetosVentana.gvSpotifyResultados = gvSpotifyResultados;
            ObjetosVentana.gridSpotifyMensajeOpciones = gridSpotifyMensajeOpciones;
            ObjetosVentana.botonSpotifyIrOpciones = botonSpotifyIrOpciones;
            ObjetosVentana.botonOpcionesSpotifyAbrirAyuda = botonOpcionesSpotifyAbrirAyuda;
            ObjetosVentana.tbOpcionesSpotifyClienteID = tbOpcionesSpotifyClienteID;
            ObjetosVentana.tbOpcionesSpotifyClienteSecreto = tbOpcionesSpotifyClienteSecreto;

            //-------------------------------------------------------------------

            ObjetosVentana.svWidgetPrecarga = svWidgetPrecarga;
            ObjetosVentana.tbWidgetPrecargaTitulo = tbWidgetPrecargaTitulo;
            ObjetosVentana.expanderWidgetPrecargaDatos = expanderWidgetPrecargaDatos;
            ObjetosVentana.tbWidgetPrecargaEjecutable = tbWidgetPrecargaEjecutable;
            ObjetosVentana.tbWidgetPrecargaArgumentos = tbWidgetPrecargaArgumentos;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña = tbWidgetPrecargaPequena;
            ObjetosVentana.tbWidgetPrecargaImagenGrande = tbWidgetPrecargaGrande;
            ObjetosVentana.expanderWidgetPrecargaPersonalizacion = expanderWidgetPrecargaPersonalizacion;
            ObjetosVentana.cbWidgetPrecargaImagen = cbWidgetPrecargaImagen;
            ObjetosVentana.tbWidgetPrecargaMensajeImagen = tbWidgetPrecargaMensajeImagen;
            ObjetosVentana.imagenWidgetPrecargaElegida = imagenWidgetPrecargaElegida;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal = cbWidgetPrecargaImagenOrientacionHorizontal;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical = cbWidgetPrecargaImagenOrientacionVertical;
            ObjetosVentana.botonWidgetPrecargaCargarJuego = botonWidgetPrecargaCargarJuego;
            ObjetosVentana.tbWidgetCargarJuegoMensaje = tbWidgetCargarJuegoMensaje;

            //-------------------------------------------------------------------

            ObjetosVentana.svOpciones = svOpciones;
            ObjetosVentana.cbOpcionesIdioma = cbOpcionesIdioma;
            ObjetosVentana.cbOpcionesPantalla = cbOpcionesPantalla;
            ObjetosVentana.botonOpcionesLimpiar = botonOpcionesLimpiar;
        }

        public static class ObjetosVentana
        {
            public static Window ventana { get; set; }
            public static Grid gridTitulo { get; set; }
            public static TextBlock tbTitulo { get; set; }
            public static NavigationView nvPrincipal { get; set; }
            public static NavigationViewItem nvItemMenu { get; set; }
            public static MenuFlyout menuItemMenu { get; set; }
            public static NavigationViewItem nvItemOpciones { get; set; }
            public static NavigationViewItem nvItemSubirArriba { get; set; }

            //-------------------------------------------------------------------

            public static Grid gridPresentacion { get; set; }
            public static Grid gridSpotify { get; set; }
            public static Grid gridWidgetPrecarga { get; set; }
            public static Grid gridOpciones { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svPresentacion { get; set; }
            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }
            public static StackPanel spPresentacionTrial { get; set; }
            public static Button botonPresentacionTrialComprar { get; set; }

            //-------------------------------------------------------------------

            public static Grid gridSpotifyBuscador { get; set; }
            public static ComboBox cbSpotifyTipoBuscar { get; set; }
            public static Button botonSpotifyBuscar { get; set; }
            public static TextBox tbSpotifyBuscar { get; set; }
            public static ScrollViewer svSpotifyResultados { get; set; }
            public static ProgressRing prSpotifyResultados { get; set; }
            public static AdaptiveGridView gvSpotifyResultados { get; set; }
            public static Grid gridSpotifyMensajeOpciones { get; set; }
            public static Button botonSpotifyIrOpciones { get; set; }
            public static Button botonOpcionesSpotifyAbrirAyuda { get; set; }
            public static TextBox tbOpcionesSpotifyClienteID { get; set; }
            public static TextBox tbOpcionesSpotifyClienteSecreto { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svWidgetPrecarga { get; set; }
            public static TextBlock tbWidgetPrecargaTitulo { get; set; }
            public static Microsoft.UI.Xaml.Controls.Expander expanderWidgetPrecargaDatos { get; set; }
            public static TextBox tbWidgetPrecargaEjecutable { get; set; }
            public static TextBox tbWidgetPrecargaArgumentos { get; set; }
            public static TextBox tbWidgetPrecargaImagenPequeña { get; set; }
            public static TextBox tbWidgetPrecargaImagenGrande { get; set; }
            public static Microsoft.UI.Xaml.Controls.Expander expanderWidgetPrecargaPersonalizacion { get; set; }
            public static ComboBox cbWidgetPrecargaImagen { get; set; }
            public static TextBlock tbWidgetPrecargaMensajeImagen { get; set; }
            public static ImageEx imagenWidgetPrecargaElegida { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionHorizontal { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionVertical { get; set; }
            public static Button botonWidgetPrecargaCargarJuego { get; set; }
            public static TextBlock tbWidgetCargarJuegoMensaje { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svOpciones { get; set; }
            public static ComboBox cbOpcionesIdioma { get; set; }
            public static ComboBox cbOpcionesPantalla { get; set; }
            public static Button botonOpcionesLimpiar { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pestañas.CreadorItems("/Assets/Plataformas/logo_cualquierjuego.png", recursos.GetString("AnyMedia"));
            Pestañas.CreadorItems("/Assets/Plataformas/logo_spotify.png", "Spotify");

            //----------------------------------------------------------

            GridViewItem itemSpotify = Presentacion.CreadorBotones("/Assets/Plataformas/logo_spotify_completo.png", "Spotify", false);
            Button2 botonSpotify = itemSpotify.Content as Button2;
            botonSpotify.Click += AbrirSpotifyClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemSpotify);

            GridViewItem itemCualquierJuego = Presentacion.CreadorBotones("/Assets/Plataformas/logo_cualquierjuego.png", recursos.GetString("AnyMedia"), true);
            Button2 botonCualquierJuego = itemCualquierJuego.Content as Button2;
            botonCualquierJuego.Click += AbrirCualquierJuegoClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemCualquierJuego);
        }

        private void nvPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (args.InvokedItemContainer != null)
            {
                if (args.InvokedItemContainer.GetType() == typeof(NavigationViewItem2))
                {
                    NavigationViewItem2 item = args.InvokedItemContainer as NavigationViewItem2;

                    if (item.Name == "nvItemMenu")
                    {

                    }
                    else if (item.Name == "nvItemOpciones")
                    {
                        Pestañas.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        ScrollViewers.EnseñarSubir(svOpciones);
                    }
                }
            }

            if (args.InvokedItem != null)
            {
                if (args.InvokedItem.GetType() == typeof(StackPanel2))
                {
                    StackPanel2 sp = (StackPanel2)args.InvokedItem;

                    if (sp.Children[1] != null)
                    {
                        if (sp.Children[1].GetType() == typeof(TextBlock))
                        {
                            TextBlock tb = sp.Children[1] as TextBlock;

                            if (tb.Text == "Spotify")
                            {
                                Pestañas.Visibilidad(gridSpotify, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svSpotifyResultados);
                            }
                            else if (tb.Text == recursos.GetString("AnyGame"))
                            {
                                Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
                                BarraTitulo.CambiarTitulo(null);
                                WidgetPrecarga.PrecargarMedia(null, null, null, null, null);
                            }
                        }
                    }
                }
            }
        }

        private void AbrirSpotifyClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[1];
            Pestañas.Visibilidad(gridSpotify, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svSpotifyResultados);       
        }

        private void AbrirCualquierJuegoClick(object sender, RoutedEventArgs e)
        {
            Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);
            WidgetPrecarga.PrecargarMedia(null, null, null, null, null);
        }
    }
}
