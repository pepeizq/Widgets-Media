using Newtonsoft.Json;
using System.Collections.Generic;

namespace Plataformas
{
    //primevideo://app/detail?asin=0TAC6MCIDL8VA4EH03DZXN6PYC

    public class PrimeVideoAPI
    {
        [JsonProperty("props")]
        public PrimeVideoAPIProps props { get; set; }
    }

    public class PrimeVideoAPIProps
    {
        [JsonProperty("results")]
        public PrimeVideoAPIResultados resultados { get; set; }
    }

    public class PrimeVideoAPIResultados
    {
        [JsonProperty("items")]
        public List<PrimeVideoAPIItem> items { get; set; }
    }

    public class PrimeVideoAPIItem
    {
        [JsonProperty("title")]
        public PrimeVideoAPIItemTitulo titulo { get; set; }

        [JsonProperty("packshot")]
        public PrimeVideoAPIItemPackshot packshot { get; set; }
    }

    public class PrimeVideoAPIItemTitulo
    {
        [JsonProperty("text")]
        public string texto { get; set; }
    }

    public class PrimeVideoAPIItemPackshot
    {
        [JsonProperty("image")]
        public PrimeVideoAPIItemImagen imagen { get; set; }

        [JsonProperty("url")]
        public string enlace { get; set; }

        [JsonProperty("isPrime")]
        public bool estaenPrime { get; set; }
    }

    public class PrimeVideoAPIItemImagen
    {
        [JsonProperty("src")]
        public string src { get; set; }
    }
}
