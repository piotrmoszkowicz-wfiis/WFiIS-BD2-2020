using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    class Marka
    {
        public int ID { get; set; }
        public String Nazwa { get; set; }
    }

    class ModelParam
    {
        public int Id { get; set; }
        public String fuelType { get; set; }
        public Int32 enginePower { get; set; }
        public Int32 engineTorque { get; set; }
    }

    class Model
    {
        public int Id
        {
            get { return rId; }
            set { rId = value; }
        }

        public String name { get; set; }
        public Int32 refMarka { get; set; }
        public List<ModelParam> prop { get; set; }
        private int rId;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Marka> marki = new List<Marka>
            {
                new Marka {ID = 1, Nazwa = "Fiat"},
                new Marka {ID = 2, Nazwa = "BMW"},
                new Marka {ID = 3, Nazwa = "Peugeot"},
                new Marka {ID = 4, Nazwa = "Volkswagen"},
                new Marka {ID = 5, Nazwa = "Toyota"},
                new Marka {ID = 6, Nazwa = "Mazda"},
                new Marka {ID = 7, Nazwa = "Seat"}
            };

            ModelParam par1 = new ModelParam()
            {
                Id = 1,
                fuelType = "Petrol",
                enginePower = 110,
                engineTorque = 130
            };

            ModelParam par2 = new ModelParam()
            {
                Id = 2,
                fuelType = "Petrol",
                enginePower = 170,
                engineTorque = 290
            };

            ModelParam par3 = new ModelParam()
            {
                Id = 3,
                fuelType = "Diesel",
                enginePower = 140,
                engineTorque = 280
            };

            ModelParam par4 = new ModelParam()
            {
                Id = 4,
                fuelType = "Diesel",
                enginePower = 190,
                engineTorque = 320
            };

            List<Model> models = new List<Model>
            {
                new Model
                {
                    Id = 1, name = "CX5", refMarka = 6, prop = new
                        List<ModelParam> {par1, par3}
                },
                new Model
                {
                    Id = 2, name = "Corolla", refMarka = 5, prop = new
                        List<ModelParam> {par2, par3}
                },
                new Model
                {
                    Id = 3, name = "Leon", refMarka = 7, prop = new
                        List<ModelParam> {par2, par4}
                }
            };
            
            Console.WriteLine("--------[1]----------");

            var query1 = marki.Join(models, m => m.ID, mdl => mdl.refMarka, (m, mdl) => new
            {
                marka = m.Nazwa,
                props = mdl.prop
            });

            foreach (var joined in query1)
            {
                foreach (var props in joined.props)
                {
                    Console.WriteLine($"{ joined.marka } : { props.engineTorque } : {props.fuelType}");
                }
            }
            
            Console.WriteLine("\n\n\n\n--------[2]----------");
            
            var query2 = marki.Join(models, m => m.ID, mdl => mdl.refMarka, (m, mdl) => new
            {
                marka = m.Nazwa,
                model = mdl.name,
                props = mdl.prop
            }).OrderBy(q2 => q2.marka).ThenBy(q2 => q2.model);

            foreach (var joined in query2)
            {
                foreach (var props in joined.props)
                {
                    Console.WriteLine($"{ joined.marka } : {joined.model} : {props.fuelType} : {props.enginePower}");
                }
            }
            
            Console.WriteLine("\n\n\n\n--------[3]----------");

            var query3 = marki.Join(models, m => m.ID, mdl => mdl.refMarka, (m, mdl) => new
            {
                marka = m.Nazwa,
                props = mdl.prop,
            }).GroupBy(q3 => q3.marka, q3Grouped => new
            {
                Key = q3Grouped.marka,
                Count = q3Grouped.props.Count(prop => prop.fuelType.Equals("Petrol"))
            });

            foreach (var joined in query3)
            {
                Console.WriteLine($"{ joined.Key } {joined.Count()}");
            }
        }
    }
}