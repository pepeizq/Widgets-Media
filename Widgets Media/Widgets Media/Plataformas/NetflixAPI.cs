using Newtonsoft.Json;
using System.Collections.Generic;

namespace Plataformas
{
    //https://unogs.com/title/80018294
    //https://unogs.com/api/title/detail?netflixid=80018294
    //https://unogs.com/api/title/bgimages?netflixid=80018294

    //netflix:/app?playVideoId=80002566

    //browseVideoId
    //playVideoId
    //searchTerm

    public class NetflixAPIDatos
    {
        [JsonProperty("title")]
        public string titulo { get; set; }
    }

    public class NetflixAPIImagenes
    {
        [JsonProperty("bo342x684")]
        public List<NetflixAPIImagenDatos> imagenesVerticales { get; set; }

        [JsonProperty("bo342x192")]
        public List<NetflixAPIImagenDatos> imagenesAnchas { get; set; }
    }

    public class NetflixAPIImagenDatos
    {
        [JsonProperty("url")]
        public string enlace { get; set; }

        [JsonProperty("width")]
        public string ancho { get; set; }
    }
}