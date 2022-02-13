using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    //[ForeignKey("Nomenclature")]
    public int NomenclatureId { get; set; }
   // public Nomenclature Nomenclature { get; set; }


    public string getnomname
    {

        get
        {
            DatabaseContext db = new DatabaseContext();

            return db.Nomenclature.FirstOrDefault(c => c.Id == NomenclatureId).Name;


        }


    }

}