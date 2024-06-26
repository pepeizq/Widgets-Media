using CommunityToolkit.WinUI.UI.Controls;
using FontAwesome6.Fonts;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plataformas;

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
            Cerrar.Cargar();
            Pesta�as.Cargar();
            ScrollViewers.Cargar();
            Interfaz.Menu.Cargar();

            Netflix.Cargar();
            DisneyPlus.Cargar();
            PrimeVideo.Cargar();
            Spotify.Cargar();

            WidgetPrecarga.Cargar();
            Opciones.CargarDatos();

            Pesta�as.Visibilidad(gridPresentacion, true, null, false);
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
            ObjetosVentana.gridCierre = gridCierre;

            //-------------------------------------------------------------------

            ObjetosVentana.botonCerrarAppSi = botonCerrarAppSi;
            ObjetosVentana.botonCerrarAppNo = botonCerrarAppNo;
            ObjetosVentana.iconoCerrarAppAzar = iconoCerrarAppAzar;
            ObjetosVentana.tbCerrarAppAzar = tbCerrarAppAzar;
            ObjetosVentana.botonCerrarAppAzar = botonCerrarAppAzar;

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

            //-------------------------------------------------------------------

            ObjetosVentana.botonNetflixBuscar = botonNetflixBuscar;
            ObjetosVentana.tbNetflixBuscar = tbNetflixBuscar;
            ObjetosVentana.svNetflixResultados = svNetflixResultados;
            ObjetosVentana.prNetflixResultados = prNetflixResultados;
            ObjetosVentana.gvNetflixResultados = gvNetflixResultados;
            ObjetosVentana.ttNetflixErrorBuscar = ttNetflixErrorBuscar;
            ObjetosVentana.cbOpcionesNetflixModo = cbOpcionesNetflixModo;
            ObjetosVentana.botonOpcionesNetflixAPIAyuda = botonOpcionesNetflixAPIAyuda;
            ObjetosVentana.tbOpcionesNetflixAPIID = tbOpcionesNetflixAPIID;
            ObjetosVentana.tbOpcionesNetflixSearchID = tbOpcionesNetflixSearchID;

            //-------------------------------------------------------------------

            ObjetosVentana.botonDisneyPlusBuscar = botonDisneyPlusBuscar;
            ObjetosVentana.tbDisneyPlusBuscar = tbDisneyPlusBuscar;
            ObjetosVentana.svDisneyPlusResultados = svDisneyPlusResultados;
            ObjetosVentana.prDisneyPlusResultados = prDisneyPlusResultados;
            ObjetosVentana.gvDisneyPlusResultados = gvDisneyPlusResultados;
            ObjetosVentana.ttDisneyPlusErrorBuscar = ttDisneyPlusErrorBuscar;
            ObjetosVentana.botonOpcionesDisneyPlusAPIAyuda = botonOpcionesDisneyPlusAPIAyuda;
            ObjetosVentana.tbOpcionesDisneyPlusAPIID = tbOpcionesDisneyPlusAPIID;
            ObjetosVentana.tbOpcionesDisneyPlusSearchID = tbOpcionesDisneyPlusSearchID;

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

            ObjetosVentana.spWidgetPrecargaBotones = spWidgetPrecargaBotones;
            ObjetosVentana.svWidgetPrecarga = svWidgetPrecarga;
            ObjetosVentana.spWidgetPrecargaPesta�as = spWidgetPrecargaPestanas;
            ObjetosVentana.tbWidgetPrecargaTitulo = tbWidgetPrecargaTitulo;
            ObjetosVentana.tbWidgetPrecargaEjecutable = tbWidgetPrecargaEjecutable;
            ObjetosVentana.tbWidgetPrecargaImagenPeque�a = tbWidgetPrecargaImagenPequena;
            ObjetosVentana.tbWidgetPrecargaImagenGrande = tbWidgetPrecargaImagenGrande;
            ObjetosVentana.cbWidgetPrecargaImagen = cbWidgetPrecargaImagen;
            ObjetosVentana.imagenWidgetPrecargaElegida = imagenWidgetPrecargaElegida;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal = cbWidgetPrecargaImagenOrientacionHorizontal;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical = cbWidgetPrecargaImagenOrientacionVertical;
            ObjetosVentana.botonWidgetPrecargaCargarStreaming = botonWidgetPrecargaCargarStreaming;
            ObjetosVentana.tbWidgetCargarStreamingMensaje = tbWidgetCargarStreamingMensaje;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda = botonWidgetPrecargaAbrirAyuda;

            //-------------------------------------------------------------------

            ObjetosVentana.spOpcionesBotones = spOpcionesBotones;
            ObjetosVentana.svOpciones = svOpciones;
            ObjetosVentana.spOpcionesPesta�as = spOpcionesPestanas;
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
            public static Grid gridCierre { get; set; }

            //-------------------------------------------------------------------

            public static Button botonCerrarAppSi { get; set; }
            public static Button botonCerrarAppNo { get; set; }
            public static FontAwesome iconoCerrarAppAzar { get; set; }
            public static TextBlock tbCerrarAppAzar { get; set; }
            public static Button botonCerrarAppAzar { get; set; }

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

            //-------------------------------------------------------------------

            public static Button botonNetflixBuscar { get; set; }
            public static TextBox tbNetflixBuscar { get; set; }
            public static ScrollViewer svNetflixResultados { get; set; }
            public static ProgressRing prNetflixResultados { get; set; }
            public static AdaptiveGridView gvNetflixResultados { get; set; }
            public static TeachingTip ttNetflixErrorBuscar { get; set; }
            public static ComboBox cbOpcionesNetflixModo { get; set; }
            public static Button botonOpcionesNetflixAPIAyuda { get; set; }
            public static TextBox tbOpcionesNetflixAPIID { get; set; }
            public static TextBox tbOpcionesNetflixSearchID { get; set; }

            //-------------------------------------------------------------------
            public static Button botonDisneyPlusBuscar { get; set; }
            public static TextBox tbDisneyPlusBuscar { get; set; }
            public static ScrollViewer svDisneyPlusResultados { get; set; }
            public static ProgressRing prDisneyPlusResultados { get; set; }
            public static AdaptiveGridView gvDisneyPlusResultados { get; set; }
            public static TeachingTip ttDisneyPlusErrorBuscar { get; set; }
            public static Button botonOpcionesDisneyPlusAPIAyuda { get; set; }
            public static TextBox tbOpcionesDisneyPlusAPIID { get; set; }
            public static TextBox tbOpcionesDisneyPlusSearchID { get; set; }

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

            public static StackPanel spWidgetPrecargaBotones { get; set; }
            public static ScrollViewer svWidgetPrecarga { get; set; }
            public static StackPanel spWidgetPrecargaPesta�as { get; set; }
            public static TextBlock tbWidgetPrecargaTitulo { get; set; }
            public static TextBox tbWidgetPrecargaEjecutable { get; set; }
            public static TextBox tbWidgetPrecargaImagenPeque�a { get; set; }
            public static TextBox tbWidgetPrecargaImagenGrande { get; set; }
            public static ComboBox cbWidgetPrecargaImagen { get; set; }
            public static ImageEx imagenWidgetPrecargaElegida { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionHorizontal { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionVertical { get; set; }
            public static Button botonWidgetPrecargaCargarStreaming { get; set; }
            public static TextBlock tbWidgetCargarStreamingMensaje { get; set; }
            public static Button botonWidgetPrecargaAbrirAyuda { get; set; }

            //-------------------------------------------------------------------

            public static StackPanel spOpcionesBotones { get; set; }
            public static ScrollViewer svOpciones { get; set; }
            public static StackPanel spOpcionesPesta�as { get; set; }
            public static ComboBox cbOpcionesIdioma { get; set; }
            public static ComboBox cbOpcionesPantalla { get; set; }
            public static Button botonOpcionesLimpiar { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pesta�as.CreadorItems("/Assets/Plataformas/logo_cualquierstreaming.png", recursos.GetString("AnyMedia"));
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_spotify.png", "Spotify");
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_primevideo.png", "Prime Video");
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_disneyplus.png", "Disney Plus");
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_netflix.png", "Netflix");

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
                        Pesta�as.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        ScrollViewers.Ense�arSubir(svOpciones);
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
                                Pesta�as.Visibilidad(gridNetflix, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svNetflixResultados);
                            }
                            else if (tb.Text == "Disney Plus")
                            {
                                Pesta�as.Visibilidad(gridDisneyPlus, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svDisneyPlusResultados);
                            }
                            else if (tb.Text == "Prime Video")
                            {
                                Pesta�as.Visibilidad(gridPrimeVideo, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svPrimeVideoResultados);
                            }
                            else if (tb.Text == "Spotify")
                            {
                                Pesta�as.Visibilidad(gridSpotify, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svSpotifyResultados);
                            }
                            else if (tb.Text == recursos.GetString("AnyMedia"))
                            {
                                Pesta�as.Visibilidad(gridWidgetPrecarga, true, null, false);
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
            Pesta�as.Visibilidad(gridNetflix, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svNetflixResultados);
        }

        private void AbrirDisneyPlusClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[2];
            Pesta�as.Visibilidad(gridDisneyPlus, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svDisneyPlusResultados);
        }

        private void AbrirPrimeVideoClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[3];
            Pesta�as.Visibilidad(gridPrimeVideo, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svPrimeVideoResultados);
        }

        private void AbrirSpotifyClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[4];
            Pesta�as.Visibilidad(gridSpotify, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svSpotifyResultados);       
        }

        private void AbrirCualquierStreamingClick(object sender, RoutedEventArgs e)
        {
            Pesta�as.Visibilidad(gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);
            WidgetPrecarga.PrecargarMedia(null, null, null, null, null);
        }
    }
}
