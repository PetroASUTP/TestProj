using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

public class DatabaseContext : DbContext
{

    public DbSet<Warehouse> Warehouse { get; set; }
    public DbSet<Nomenclature> Nomenclature { get; set; }
    public DbSet<Product> Product { get; set; }

    public DbSet<MoveNomenclature> MoveNomenclature { get; set; }
    public DbSet<MovingProduct> MovingProduct { get; set; }


    public DatabaseContext() : base("StrConnection") { }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {




    }



    public void datacreate()
    {

        Random random = new Random();
        if (Warehouse.Count() < 1)
        {

            Warehouse.Add(new Warehouse() { Name = "Склад 1" });
            Warehouse.Add(new Warehouse() { Name = "Склад 2" });
            Warehouse.Add(new Warehouse() { Name = "Склад 3" });
            Warehouse.Add(new Warehouse() { Name = "Склад 4" });
            Warehouse.Add(new Warehouse() { Name = "Склад 5" });

            SaveChanges();

            foreach(var w in Warehouse.ToList())
            {
               
                for(int i=0; i< (5+random.Next(5)); i++)
                try { Nomenclature.Add(new Nomenclature() { WarehouseId = w.Id, Name = "Группа"+Path.GetRandomFileName() }); SaveChanges(); }
                catch (Exception) { }
                
            }

            foreach (var n in Nomenclature.ToList())
            {

                    for (int i = 0; i < (20 + random.Next(30)); i++)
                    try { Product.Add(new Product() { NomenclatureId = n.Id, Name = "Товар"+Path.GetRandomFileName() }); SaveChanges(); }
                    catch (Exception) { }

            }

        }


    }



}
    
