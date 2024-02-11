using System.Text.Json.Serialization;

namespace Infra.LegoModels;

public class Vendor
{
    public int Id { get; set; }
    public string VendorName { get; set; } = string.Empty;

    // This is the n part of the relation
    [JsonIgnore]
    public List<BrickAvailability> Availabilities { get; set; } = new List<BrickAvailability>();


}