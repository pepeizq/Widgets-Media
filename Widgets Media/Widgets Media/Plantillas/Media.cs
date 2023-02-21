using System.Text.Json.Serialization;

namespace Plantillas
{
    public class Media
    {
        [JsonPropertyName("type")]
        public string tipo { get; set; }

        [JsonPropertyName("$schema")]
        public string schema { get; set; }

        [JsonPropertyName("version")]
        public string version { get; set; }

        [JsonPropertyName("enlace")]
        public string enlace { get; set; }

        [JsonPropertyName("argumentos")]
        public string argumentos { get; set; }

        [JsonPropertyName("backgroundImage")]
        public MediaFondo fondo { get; set; }

        [JsonPropertyName("selectAction")]
        public MediaAccion accion { get; set; }
    }

    public class MediaFondo
    {
        [JsonPropertyName("url")]
        public string url { get; set; }
        [JsonPropertyName("horizontalAlignment")]
        public string horizontal { get; set; }
        [JsonPropertyName("verticalAlignment")]
        public string vertical { get; set; }
    }

    public class MediaAccion
    {
        [JsonPropertyName("type")]
        public string tipo { get; set; }

        [JsonPropertyName("verb")]
        public string verb { get; set; }
    }
}
