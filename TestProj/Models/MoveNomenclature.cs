using System;
using System.Linq;

public class MoveNomenclature
{
   public int Id { get; set; }

   public int NomenclatureId { get; set; }
   
   public int fromId { get; set; }
   public int ToId   { get; set; }

   public DateTime date { get; set; }

    public string getfrom
    {     
    get {

            DatabaseContext db = new DatabaseContext();

            return db.Warehouse.FirstOrDefault(c => c.Id == fromId).Name;
        }
    }


    public string getto
    {
        get
        {

            DatabaseContext db = new DatabaseContext();           
            return db.Warehouse.FirstOrDefault(c => c.Id == ToId).Name;
        }
    }

}