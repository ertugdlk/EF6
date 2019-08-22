using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            //InsertNinja();
            //InsertMultipleNinjas();
            //SimpleNinjaQueries();
            //QueryAndUpdateNinja();
            //DeleteNinja();
            //RetrieveDataWithFind();
            //RetrieveDataWithStoredProc();
            //DeleteNinjaWithKeyValue();
            //DeleteNinjaViaStoredProcedure();
            //QueryAndUpdateNinjaDisconnected();
            //CloneFirstNinja();
            //DeleteSampsonSan();
            //InsertNinjaWithEquipment();
            //SimpleNinjaGraphQuery();
            //ProjectionQuery();
            //QueryAndUpdateNinjaDisconnected();

            //ReseedDatabase();
            Console.ReadKey();
        }

        private static void InsertNinja()
        {

            var ninja = new Ninja
            {
                Name = "SampsonSan",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(2008, 1, 28),
                ClanId = 1

            };
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine; //logging ef6 feature 
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        private static void CloneFirstNinja()
        {
            Ninja ninja2 = new Ninja();
            using (var context = new NinjaContext())
            {
                //var ninja2 = new Ninja();
                context.Database.Log = Console.WriteLine;

                context.Ninjas.Attach(ninja2);
                var ninja = context.Ninjas.AsNoTracking().FirstOrDefault();

                ninja2.Name = ninja.Name;
                ninja2.ServedInOniwaban = ninja.ServedInOniwaban;
                ninja2.DateOfBirth = new DateTime(2008, 1, 28);
                ninja2.ClanId = 1;


                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Add(ninja2);
                context.Entry(ninja2).State = EntityState.Added;
                context.SaveChanges();

            }




            //          using (var context = new NinjaContext())
            //{
            //    context.Database.Log = Console.WriteLine;
            //    var ninja = context.Ninjas.FirstOrDefault();
            //    ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);
            //    context.SaveChanges();
            //}


        }

        private static void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1984, 1, 1),
                ClanId = 1
            };
            var ninja2 = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1985, 1, 1),
                ClanId = 1
            };
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2 });
                context.SaveChanges();
            }
        }

        private static void SimpleNinjaQueries()
        {
            using (var context = new NinjaContext())
            {
                var ninjas = context.Ninjas
                    .Where(n => n.DateOfBirth >= new DateTime(1984, 1, 1))
                    .OrderBy(n => n.Name)
                    .Skip(1);





                //var query = context.Ninjas;
                // var someninjas = query.ToList();
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }
        }

        private static void QueryAndUpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);
                context.SaveChanges();
            }
        }


        private static void QueryAndUpdateNinjaDisconnected()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Attach(ninja);
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        //video 6 find()
        private static void RetrieveDataWithFind()
        {
            var keyval = 4;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.Find(keyval);
                Console.WriteLine("After Find#1:" + ninja.Name);

                var someNinja = context.Ninjas.Find(keyval);
                Console.WriteLine("After Find#2:" + someNinja.Name);
                ninja = null;
            }
        }
        //video 6 find()

        private static void RetrieveDataWithStoredProc()
        {

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas.SqlQuery("exec GetOldNinjas").ToList();
                //foreach (var ninja in ninjas)
                //{
                //    Console.WriteLine(ninja.Name);
                //}
            }
        }
        //video7 delete() ninjas with sampsonsan name
        private static void DeleteSampsonSan()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas.SqlQuery("exec SampsonSan").ToList();

                context.Ninjas.RemoveRange(ninjas);
                context.SaveChanges();
            }
        }


        //video7 delete()
        private static void DeleteNinja()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
                //context.Ninjas.Remove(ninja);
                //context.SaveChanges();
            }
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Attach(ninja);
                //context.Ninjas.Remove(ninja);
                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //video7 delete()
        private static void DeleteNinjaWithKeyValue()
        {
            var keyval = 1;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = context.Ninjas.Find(keyval);
                context.Ninjas.Remove(ninja);
                context.SaveChanges();
            }
        }

    }
}
