using Google.Apis.CustomSearchAPI.v1.Data;
using Google.Apis.CustomSearchAPI.v1;
using Google.Apis.Services;
using System.Collections.Generic;

namespace Plataformas
{
    public static class Google
    {
        //https://programmablesearchengine.google.com/controlpanel/all

        public static List<string> Buscar(string cosaBuscar)
        {
            string apiClave = "AIzaSyC2mAim7jYXCR8ePfx59BdwU8zCTTNaURs";
            string motorBusquedaID = "e6760ff33b21c479a";

            CustomSearchAPIService servicio = new CustomSearchAPIService(new BaseClientService.Initializer { ApiKey = apiClave });
            CseResource.ListRequest peticion = servicio.Cse.List();
            peticion.Cx = motorBusquedaID;
            peticion.Q = cosaBuscar;

            List<string> enlacesResultados = new List<string>();

            IList<Result> resultados = new List<Result>();
            int i = 0;
            while (resultados != null && enlacesResultados.Count < 50)
            {
                peticion.Start = i * 10 + 1;
                resultados = peticion.Execute().Items;

                if (resultados != null)
                {
                    foreach (Result resultado in resultados)
                    {
                        enlacesResultados.Add(resultado.Link);
                    }
                }

                i += 1;
            }

            return enlacesResultados;
        }
    }
}
