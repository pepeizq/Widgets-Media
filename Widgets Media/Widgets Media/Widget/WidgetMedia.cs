using Herramientas;
using Microsoft.Windows.Widgets.Providers;
using Plantillas;
using System;
using System.Diagnostics;
using System.Text.Json;
using Windows.Storage;
using Windows.System;

internal class WidgetMedia : WidgetBase
{
    public override async void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        string verb = actionInvokedArgs.Verb;

        if (verb == "AbrirMedia")
        {
            string plantilla = Ficheros.LeerFicheroFueraAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Media" + ID + ".json");
            Media json = JsonSerializer.Deserialize<Media>(plantilla);
            await Launcher.LaunchUriAsync(new Uri(json.enlace));
        }
    }

    public override string CogerPlantilla(string id)
    {
        if (Ficheros.ExisteFichero(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Media" + ID + ".json") == true)
        {
            return Ficheros.LeerFicheroDentroAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Media" + ID + ".json");
        }
        else
        {
            string plantilla = Ficheros.LeerFicheroFueraAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Media.json");
            Ficheros.EscribirFichero("Media" + id + ".json", plantilla);
            return plantilla;
        }
    }
}