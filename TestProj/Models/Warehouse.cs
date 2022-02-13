
using System.ComponentModel.DataAnnotations;

public class Warehouse
{
    [Key]
    public int Id{ get; set; }
    public string Name{ get; set; }
}