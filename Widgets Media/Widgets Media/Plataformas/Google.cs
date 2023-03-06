using Google.Apis.CustomSearchAPI.v1.Data;
using Google.Apis.CustomSearchAPI.v1;
using Google.Apis.Services;
using Microsoft.UI.Xaml;
using System.Collections.Generic;
using static Widgets_Media.MainWindow;
using Microsoft.Windows.ApplicationModel.Resources;

namespace Plataformas
{
    public static class Google
    {
        //https://programmablesearchengine.google.com/controlpanel/all

        public static List<string> Buscar(string cosaBuscar, string apiClave, string motorBusquedaID, string plataforma)
        {
            CustomSearchAPIService servicio = new CustomSearchAPIService(new BaseClientService.Initializer { ApiKey = apiClave });
            CseResource.ListRequest peticion = servicio.Cse.List();
            peticion.Cx = motorBusquedaID;
            peticion.Q = cosaBuscar;

            List<string> enlacesResultados = new List<string>();

            IList<Result> resultados = new List<Result>();
            int i = 0;
            while (resultados != null && i < 3)
            {
                peticion.Start = i * 10 + 1;

                try
                {
                    resultados = peticion.Execute().Items;

                    if (resultados != null)
                    {
                        foreach (Result resultado in resultados)
                        {
                            enlacesResultados.Add(resultado.Link);
                        }
                    }
                }
                catch 
                {
                    ResourceLoader recursos = new ResourceLoader();

                    if (plataforma == "netflix")
                    {
                        ObjetosVentana.ttNetflixErrorBuscar.Title = recursos.GetString("NetflixError");
                        ObjetosVentana.ttNetflixErrorBuscar.Subtitle = recursos.GetString("SearchError");
                        ObjetosVentana.ttNetflixErrorBuscar.IsOpen = true;
                    }
                    else if (plataforma == "disney")
                    {
                        ObjetosVentana.ttDisneyPlusErrorBuscar.Title = recursos.GetString("DisneyPlusError");
                        ObjetosVentana.ttDisneyPlusErrorBuscar.Subtitle = recursos.GetString("SearchError");
                        ObjetosVentana.ttDisneyPlusErrorBuscar.IsOpen = true;
                    }

                    break;
                }

                i += 1;
            }

            return enlacesResultados;
        }
    }
}
