using CommunityToolkit.WinUI.UI.Controls;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plataformas;
using Expander = Microsoft.UI.Xaml.Controls.Expander;

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

            Netflix.Cargar();
            DisneyPlus.Cargar();
            PrimeVideo.Cargar();
            Spotify.Cargar();

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
            ObjetosVentana.gridNetflix = gridNetflix;
            ObjetosVentana.gridDisneyPlus = gridDisneyPlus;
            ObjetosVentana.gridPrimeVideo = gridPrimeVideo;
            ObjetosVentana.gridSpotify = gridSpotify;
            ObjetosVentana.gridWidgetPrecarga = gridWidgetPrecarga;
            ObjetosVentana.gridOpciones = gridOpciones;

            //-------------------------------------------------------------------

            ObjetosVentana.svPresentacion = svPresentacion;
            ObjetosVentana.gvPresentacionPlataformas = gvPresentacionPlataformas;
            ObjetosVentana.spPresentacionTrial = spPresentacionTrial;
            ObjetosVentana.botonPresentacionTrialComprar = botonPresentacionTrialComprar;

            //-------------------------------------------------------------------

            ObjetosVentana.botonNetflixBuscar = botonNetflixBuscar;
            ObjetosVentana.tbNetflixBuscar = tbNetflixBuscar;
            ObjetosVentana.svNetflixResultados = svNetflixResultados;
            ObjetosVentana.prNetflixResultados = prNetflixResultados;
            ObjetosVentana.gvNetflixResultados = gvNetflixResultados;
            ObjetosVentana.cbOpcionesNetflixModo = cbOpcionesNetflixModo;

            //-------------------------------------------------------------------
            
            ObjetosVentana.botonDisneyPlusBuscar = botonDisneyPlusBuscar;
            ObjetosVentana.tbDisneyPlusBuscar = tbDisneyPlusBuscar;
            ObjetosVentana.svDisneyPlusResultados = svDisneyPlusResultados;
            ObjetosVentana.prDisneyPlusResultados = prDisneyPlusResultados;
            ObjetosVentana.gvDisneyPlusResultados = gvDisneyPlusResultados;

            //-------------------------------------------------------------------

            ObjetosVentana.botonPrimeVideoBuscar = botonPrimeVideoBuscar;
            ObjetosVentana.tbPrimeVideoBuscar = tbPrimeVideoBuscar;
            ObjetosVentana.svPrimeVideoResultados = svPrimeVideoResultados;
            ObjetosVentana.prPrimeVideoResultados = prPrimeVideoResultados;
            ObjetosVentana.gvPrimeVideoResultados = gvPrimeVideoResultados;
            ObjetosVentana.cbOpcionesPrimeVideoModo = cbOpcionesPrimeVideoModo;

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
            ObjetosVentana.cbOpcionesSpotifyModo = cbOpcionesSpotifyModo;
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
            ObjetosVentana.botonWidgetPrecargaCargarStreaming = botonWidgetPrecargaCargarStreaming;
            ObjetosVentana.tbWidgetCargarStreamingMensaje = tbWidgetCargarStreamingMensaje;

            //-------------------------------------------------------------------

            ObjetosVentana.botonOpcionesMoverNetflix = botonOpcionesMoverNetflix;
            ObjetosVentana.botonOpcionesMoverPrimeVideo = botonOpcionesMoverPrimeVideo;
            ObjetosVentana.botonOpcionesMoverSpotify = botonOpcionesMoverSpotify;
            ObjetosVentana.botonOpcionesMoverIdioma = botonOpcionesMoverIdioma;
            ObjetosVentana.botonOpcionesMoverAplicacion = botonOpcionesMoverAplicacion;
            ObjetosVentana.expanderOpcionesNetflix = expanderOpcionesNetflix;
            ObjetosVentana.expanderOpcionesPrimeVideo = expanderOpcionesPrimeVideo;
            ObjetosVentana.expanderOpcionesSpotify = expanderOpcionesSpotify;
            ObjetosVentana.expanderOpcionesIdioma = expanderOpcionesIdioma;
            ObjetosVentana.expanderOpcionesAplicacion = expanderOpcionesAplicacion;

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
            public static Grid gridNetflix { get; set; }
            public static Grid gridDisneyPlus { get; set; }
            public static Grid gridPrimeVideo { get; set; }
            public static Grid gridSpotify { get; set; }
            public static Grid gridWidgetPrecarga { get; set; }
            public static Grid gridOpciones { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svPresentacion { get; set; }
            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }
            public static StackPanel spPresentacionTrial { get; set; }
            public static Button botonPresentacionTrialComprar { get; set; }

            //-------------------------------------------------------------------

            public static Button botonNetflixBuscar { get; set; }
            public static TextBox tbNetflixBuscar { get; set; }
            public static ScrollViewer svNetflixResultados { get; set; }
            public static ProgressRing prNetflixResultados { get; set; }
            public static AdaptiveGridView gvNetflixResultados { get; set; }
            public static ComboBox cbOpcionesNetflixModo { get; set; }

            //-------------------------------------------------------------------
            public static Button botonDisneyPlusBuscar { get; set; }
            public static TextBox tbDisneyPlusBuscar { get; set; }
            public static ScrollViewer svDisneyPlusResultados { get; set; }
            public static ProgressRing prDisneyPlusResultados { get; set; }
            public static AdaptiveGridView gvDisneyPlusResultados { get; set; }

            //-------------------------------------------------------------------

            public static Button botonPrimeVideoBuscar { get; set; }
            public static TextBox tbPrimeVideoBuscar { get; set; }
            public static ScrollViewer svPrimeVideoResultados { get; set; }
            public static ProgressRing prPrimeVideoResultados { get; set; }
            public static AdaptiveGridView gvPrimeVideoResultados { get; set; }
            public static ComboBox cbOpcionesPrimeVideoModo { get; set; }

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
            public static ComboBox cbOpcionesSpotifyModo { get; set; }
            public static Button botonOpcionesSpotifyAbrirAyuda { get; set; }
            public static TextBox tbOpcionesSpotifyClienteID { get; set; }
            public static TextBox tbOpcionesSpotifyClienteSecreto { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svWidgetPrecarga { get; set; }
            public static TextBlock tbWidgetPrecargaTitulo { get; set; }
            public static Expander expanderWidgetPrecargaDatos { get; set; }
            public static TextBox tbWidgetPrecargaEjecutable { get; set; }
            public static TextBox tbWidgetPrecargaArgumentos { get; set; }
            public static TextBox tbWidgetPrecargaImagenPequeña { get; set; }
            public static TextBox tbWidgetPrecargaImagenGrande { get; set; }
            public static Expander expanderWidgetPrecargaPersonalizacion { get; set; }
            public static ComboBox cbWidgetPrecargaImagen { get; set; }
            public static TextBlock tbWidgetPrecargaMensajeImagen { get; set; }
            public static ImageEx imagenWidgetPrecargaElegida { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionHorizontal { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionVertical { get; set; }
            public static Button botonWidgetPrecargaCargarStreaming { get; set; }
            public static TextBlock tbWidgetCargarStreamingMensaje { get; set; }

            //-------------------------------------------------------------------

            public static Button botonOpcionesMoverNetflix { get; set; }
            public static Button botonOpcionesMoverPrimeVideo { get; set; }
            public static Button botonOpcionesMoverSpotify { get; set; }
            public static Button botonOpcionesMoverIdioma { get; set; }
            public static Button botonOpcionesMoverAplicacion { get; set; }
            public static Expander expanderOpcionesNetflix { get; set; }
            public static Expander expanderOpcionesPrimeVideo { get; set; }
            public static Expander expanderOpcionesSpotify { get; set; }
            public static Expander expanderOpcionesIdioma { get; set; }
            public static Expander expanderOpcionesAplicacion { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svOpciones { get; set; }
            public static ComboBox cbOpcionesIdioma { get; set; }
            public static ComboBox cbOpcionesPantalla { get; set; }
            public static Button botonOpcionesLimpiar { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pestañas.CreadorItems("/Assets/Plataformas/logo_cualquierstreaming.png", recursos.GetString("AnyMedia"));
            Pestañas.CreadorItems("/Assets/Plataformas/logo_spotify.png", "Spotify");
            Pestañas.CreadorItems("/Assets/Plataformas/logo_primevideo.png", "Prime Video");
            Pestañas.CreadorItems("/Assets/Plataformas/logo_disneyplus.png", "Disney Plus");
            Pestañas.CreadorItems("/Assets/Plataformas/logo_netflix.png", "Netflix");

            //----------------------------------------------------------

            GridViewItem itemNetflix = Presentacion.CreadorBotones("/Assets/Plataformas/logo_netflix_completo.png", "Netflix", false, 25);
            Button2 botonNetflix = itemNetflix.Content as Button2;
            botonNetflix.Click += AbrirNetflixClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemNetflix);

            GridViewItem itemDisneyPlus = Presentacion.CreadorBotones("/Assets/Plataformas/logo_disneyplus.png", "Disney Plus", false, 10);
            Button2 botonDisneyPlus = itemDisneyPlus.Content as Button2;
            botonDisneyPlus.Click += AbrirDisneyPlusClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemDisneyPlus);

            GridViewItem itemPrimeVideo = Presentacion.CreadorBotones("/Assets/Plataformas/logo_primevideo_completo.png", "Prime Video", false, 20);
            Button2 botonPrimeVideo = itemPrimeVideo.Content as Button2;
            botonPrimeVideo.Click += AbrirPrimeVideoClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemPrimeVideo);

            GridViewItem itemSpotify = Presentacion.CreadorBotones("/Assets/Plataformas/logo_spotify_completo.png", "Spotify", false, 20);
            Button2 botonSpotify = itemSpotify.Content as Button2;
            botonSpotify.Click += AbrirSpotifyClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemSpotify);

            GridViewItem itemCualquierStreaming = Presentacion.CreadorBotones("/Assets/Plataformas/logo_cualquierstreaming.png", recursos.GetString("AnyMedia"), true, 20);
            Button2 botonCualquierStreaming = itemCualquierStreaming.Content as Button2;
            botonCualquierStreaming.Click += AbrirCualquierStreamingClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemCualquierStreaming);
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

                            if (tb.Text == "Netflix")
                            {
                                Pestañas.Visibilidad(gridNetflix, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svNetflixResultados);
                            }
                            else if (tb.Text == "Disney Plus")
                            {
                                Pestañas.Visibilidad(gridDisneyPlus, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svDisneyPlusResultados);
                            }
                            else if (tb.Text == "Prime Video")
                            {
                                Pestañas.Visibilidad(gridPrimeVideo, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svPrimeVideoResultados);
                            }
                            else if (tb.Text == "Spotify")
                            {
                                Pestañas.Visibilidad(gridSpotify, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svSpotifyResultados);
                            }
                            else if (tb.Text == recursos.GetString("AnyMedia"))
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

        private void AbrirNetflixClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[1];
            Pestañas.Visibilidad(gridNetflix, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svNetflixResultados);
        }

        private void AbrirDisneyPlusClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[2];
            Pestañas.Visibilidad(gridDisneyPlus, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svDisneyPlusResultados);
        }

        private void AbrirPrimeVideoClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[3];
            Pestañas.Visibilidad(gridPrimeVideo, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svPrimeVideoResultados);
        }

        private void AbrirSpotifyClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[4];
            Pestañas.Visibilidad(gridSpotify, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svSpotifyResultados);       
        }

        private void AbrirCualquierStreamingClick(object sender, RoutedEventArgs e)
        {
            Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);
            WidgetPrecarga.PrecargarMedia(null, null, null, null, null);
        }
    }
}
