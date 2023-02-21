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
            ObjetosVentana.gridSteam = gridSteam;
            ObjetosVentana.gridGOG = gridGOG;
            ObjetosVentana.gridEAPlay = gridEAPlay;
            ObjetosVentana.gridUbisoft = gridUbisoft;
            ObjetosVentana.gridBattlenet = gridBattlenet;
            ObjetosVentana.gridAmazon = gridAmazon;
            ObjetosVentana.gridEpicGames = gridEpicGames;
            ObjetosVentana.gridWidgetPrecarga = gridWidgetPrecarga;
            ObjetosVentana.gridOpciones = gridOpciones;

            //-------------------------------------------------------------------

            ObjetosVentana.svPresentacion = svPresentacion;
            ObjetosVentana.gvPresentacionPlataformas = gvPresentacionPlataformas;
            ObjetosVentana.spPresentacionTrial = spPresentacionTrial;
            ObjetosVentana.botonPresentacionTrialComprar = botonPresentacionTrialComprar;

            //-------------------------------------------------------------------

            ObjetosVentana.expanderEpicGamesJuegosNoBBDD = expanderEpicGamesJuegosNoBBDD;
            ObjetosVentana.tbEpicGamesJuegosNoBBDDIds = tbEpicGamesJuegosNoBBDDIds;
            ObjetosVentana.botonEpicGamesJuegosNoBBDDContactar = botonEpicGamesJuegosNoBBDDContactar;
            ObjetosVentana.svEpicGamesJuegosInstalados = svEpicGamesJuegosInstalados;
            ObjetosVentana.prEpicGamesJuegosInstalados = prEpicGamesJuegosInstalados;
            ObjetosVentana.gvEpicGamesJuegosInstalados = gvEpicGamesJuegosInstalados;
            ObjetosVentana.tbEpicGamesMensajeNoJuegos = tbEpicGamesMensajeNoJuegos;

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
            public static Grid gridSteam { get; set; }
            public static Grid gridGOG { get; set; }
            public static Grid gridEAPlay { get; set; }
            public static Grid gridUbisoft { get; set; }
            public static Grid gridBattlenet { get; set; }
            public static Grid gridAmazon { get; set; }
            public static Grid gridEpicGames { get; set; }
            public static Grid gridWidgetPrecarga { get; set; }
            public static Grid gridOpciones { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svPresentacion { get; set; }
            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }
            public static StackPanel spPresentacionTrial { get; set; }
            public static Button botonPresentacionTrialComprar { get; set; }

            //-------------------------------------------------------------------

            public static Button botonSteamJuegosInstalados { get; set; }
            public static Button botonSteamCualquierJuego { get; set; }
            public static Grid gridSteamJuegosInstalados { get; set; }
            public static ScrollViewer svSteamJuegosInstalados { get; set; }
            public static ProgressRing prSteamJuegosInstalados { get; set; }
            public static AdaptiveGridView gvSteamJuegosInstalados { get; set; }
            public static Grid gridSteamCualquierJuego { get; set; }
            public static TextBox tbSteamCualquierJuego { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svGOGJuegosInstalados { get; set; }
            public static ProgressRing prGOGJuegosInstalados { get; set; }
            public static AdaptiveGridView gvGOGJuegosInstalados { get; set; }
            public static TextBlock tbGOGMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static Button botonEAPlayBuscarJuegosInstalados { get; set; }
            public static TextBlock tbEAPlayCarpetaJuegosInstalados { get; set; }
            public static ScrollViewer svEAPlayJuegosInstalados { get; set; }
            public static ProgressRing prEAPlayJuegosInstalados { get; set; }
            public static AdaptiveGridView gvEAPlayJuegosInstalados { get; set; }
            public static TextBlock tbEAPlayMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static Microsoft.UI.Xaml.Controls.Expander expanderUbisoftJuegosNoBBDD { get; set; }
            public static TextBox tbUbisoftJuegosNoBBDDIds { get; set; }
            public static Button botonUbisoftJuegosNoBBDDContactar { get; set; }
            public static ScrollViewer svUbisoftJuegosInstalados { get; set; }
            public static ProgressRing prUbisoftJuegosInstalados { get; set; }
            public static AdaptiveGridView gvUbisoftJuegosInstalados { get; set; }
            public static TextBlock tbUbisoftMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static StackPanel spBattlenetJuegosInstaladosMensaje { get; set; }
            public static ScrollViewer svBattlenetJuegosInstalados { get; set; }
            public static ProgressRing prBattlenetJuegosInstalados { get; set; }
            public static AdaptiveGridView gvBattlenetJuegosInstalados { get; set; }
            public static TextBlock tbBattlenetMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svAmazonJuegosInstalados { get; set; }
            public static ProgressRing prAmazonJuegosInstalados { get; set; }
            public static AdaptiveGridView gvAmazonJuegosInstalados { get; set; }
            public static TextBlock tbAmazonMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static Microsoft.UI.Xaml.Controls.Expander expanderEpicGamesJuegosNoBBDD { get; set; }
            public static TextBox tbEpicGamesJuegosNoBBDDIds { get; set; }
            public static Button botonEpicGamesJuegosNoBBDDContactar { get; set; }
            public static ScrollViewer svEpicGamesJuegosInstalados { get; set; }
            public static ProgressRing prEpicGamesJuegosInstalados { get; set; }
            public static AdaptiveGridView gvEpicGamesJuegosInstalados { get; set; }
            public static TextBlock tbEpicGamesMensajeNoJuegos { get; set; }

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

            Pestañas.CreadorItems("/Assets/Plataformas/logo_cualquierjuego.png", recursos.GetString("AnyGame"));
            Pestañas.CreadorItems("/Assets/Plataformas/logo_epicgames.png", "Epic Games");

            //----------------------------------------------------------

            GridViewItem itemEpicGames = Presentacion.CreadorBotones("/Assets/Plataformas/logo_epicgames.png", "Epic Games", false);
            Button2 botonEpicGames = itemEpicGames.Content as Button2;
            botonEpicGames.Click += AbrirEpicGamesClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(itemEpicGames);

            GridViewItem itemCualquierJuego = Presentacion.CreadorBotones("/Assets/Plataformas/logo_cualquierjuego.png", recursos.GetString("AnyGame"), true);
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

                            if (tb.Text == "Epic Games")
                            {
                                Pestañas.Visibilidad(gridEpicGames, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svEpicGamesJuegosInstalados);
                                //EpicGames.CargarJuegosInstalados();
                            }
                            else if (tb.Text == recursos.GetString("AnyGame"))
                            {
                                Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
                                BarraTitulo.CambiarTitulo(null);
                                WidgetPrecarga.PrecargarJuego(null, null, null, null, null);
                            }
                        }
                    }
                }
            }
        }

        private void AbrirEpicGamesClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[7];
            Pestañas.Visibilidad(gridEpicGames, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svEpicGamesJuegosInstalados);
            
        }

        private void AbrirCualquierJuegoClick(object sender, RoutedEventArgs e)
        {
            Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);
            WidgetPrecarga.PrecargarJuego(null, null, null, null, null);
        }
    }
}
