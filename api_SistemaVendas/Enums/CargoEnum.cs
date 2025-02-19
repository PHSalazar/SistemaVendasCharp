using System.Text.Json.Serialization;

namespace api_SistemaVendas.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CargoEnum
    {
        Supervisor,
        Vendedor
    }
}
