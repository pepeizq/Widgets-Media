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

            if (json.enlace.Contains("steam://rungameid/") == true || json.enlace.Contains("uplay://launch/") == true || 
                json.enlace.Contains("amazon-games://play/") == true || json.enlace.Contains("com.epicgames.launcher://apps/") == true)
            {
                await Launcher.LaunchUriAsync(new Uri(json.enlace));
            }
            else
            {
                string ejecutable = json.enlace.Trim();
                string argumentos = json.argumentos.Trim();
               
                Process proceso = new Process();
                proceso.StartInfo.FileName = ejecutable;
                
                if (argumentos.Length > 0)
                {
                    proceso.StartInfo.Arguments = argumentos;
                    proceso.StartInfo.RedirectStandardInput = true;
                    proceso.StartInfo.UseShellExecute = false;
                    proceso.StartInfo.CreateNoWindow = true;
                }
                
                proceso.Start();
            }           
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