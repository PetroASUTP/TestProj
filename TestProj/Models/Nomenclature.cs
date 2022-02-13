using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Nomenclature
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    [ForeignKey("Warehouse")]
    public int WarehouseId { get; set; }
    public Nomenclature Warehouse { get; set; }

}