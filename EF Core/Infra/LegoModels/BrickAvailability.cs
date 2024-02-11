using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.LegoModels;

public class BrickAvailability
{
    public int  Id { get; set; }
    public int AvailableAmount { get; set; }

    public int BrickId { get; set; }
    public Brick Brick { get; set; }

    // One side of the relation
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }

    [Column(TypeName = "decimal(8 , 2)")]
    public decimal Price { get; set; }
}