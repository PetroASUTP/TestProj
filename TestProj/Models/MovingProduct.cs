using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class MovingProduct{

    [Key]
    public int Id { get; set; }

    public int productId { get; set; }
    public int fromid { get; set; }

    //[ForeignKey("Nomenclature")]
    public int toid { get; set; }
    //public Nomenclature Nomenclature { get; set; }


    public DateTime date { get; set; }




    public string getfrom
    {
        get
        {

            DatabaseContext db = new DatabaseContext();

            return db.Nomenclature.FirstOrDefault(c => c.Id == fromid).Name;
        }
    }


    public string getto
    {
        get
        {

            DatabaseContext db = new DatabaseContext();
            return db.Nomenclature.FirstOrDefault(c => c.Id == toid).Name;
        }
    }









}