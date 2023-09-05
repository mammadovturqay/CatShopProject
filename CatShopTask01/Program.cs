
namespace CatShopTask01
{
    public class Program
    {
        public class Cat
        {
            public string? name { get; set; } = string.Empty;
            public double calori { get; set; } = 0;
            public double weight { get; set; } = 0;
            public decimal energy { get; set; } = 0;
            public double consume { get; set; } = 0;

            public void Eat()
            {
                if (calori == 0 || energy == 0)
                {


                    calori += 35;
                    weight += 25;
                    energy += 35;
                    consume += 1;

                }

            }
            public void Sleep()
            {
                if (energy > 0)
                {

                    int count = 0;
                   
                    energy += 35;
                    weight += 5;
                    count++;
                    if (count == 2 )
                    {

                        return;

                    }


                    
                }

            }
            public void Play()
            {
                if (calori > 0 && energy > 0)
                {
                    if (calori > 0 )
                    {
                    calori -= 5;

                    }
                    if (energy > 0)
                    {
                        energy -= 5;
                    }
                    if (weight > 0)
                    {
                    weight -= 5;
                    }

                }
                else
                {
                    calori = 0;
                    weight = 0;

                    energy = 0;
                    return;

                }
            }
        public void Start()
            {
                if (calori > 0 && energy >0 )
                {
                    Play();

                }
                else if(calori == 0 || energy == 0)
                {
                    Eat();
                }
                else if(energy == 0)
                {
                    Sleep();
                }
            }

            public Cat()
            {
                name = string.Empty;
                calori = 0;
                weight = 0;
                energy = 0;
                consume = 0;

            }
            public Cat(string? name, double calori, double weight, decimal energy, double consume)
            {
                this.name = name;
                this.calori = calori;
                this.weight = weight;
                this.energy = energy;
                this.consume = consume;
            }

            public void PrintCats()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cat Name:{name} \nCat Calori: {calori} \nCat weight: {weight} \n Cat Energy: {energy}\n" +
                    $"Cat Consume {consume}\n\n");
                Console.ResetColor();
            }



        }
        public class CatHouse
        {
            public Cat[] Cats { get; set; }
            public int CatCount { get; private set; }
            public CatHouse(int capacity)
            {
                Cats = new Cat[capacity];
                CatCount = 0;


            }

            public double GetTotalMass()
            {
                double totalMass = 0;
                foreach (Cat cat in Cats)
                {
                    if (cat != null)
                    {
                        totalMass += cat.weight;
                    }
                }
                return totalMass;
            }


            public double GetTotalConsume()
            {
                double totalConsume = 0;
                foreach (Cat cat in Cats)
                {
                    if (cat != null)
                    {
                        totalConsume += cat.consume;
                    }
                }
                return totalConsume;
            }

            public void AddCat(Cat cat)
            {
                if (CatCount < Cats.Length)
                {
                    Cats[CatCount] = cat;
                    CatCount++;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cat house is full ");
                    Console.ResetColor();

                }
            }
            public void AddHouse(CatHouse house)
            {
                foreach (Cat cat in house.Cats)
                {
                    if (cat != null)
                    {
                        AddCat(cat);
                    }
                }
            }


        }
        public class CatShop
        {
            public CatHouse House { get; set; }

            public CatShop(int houseCapacity)
            {
                House = new CatHouse(houseCapacity);

            }



        }

        static void Main(string[] args)
        {
            CatHouse House1 = new CatHouse(2);
            CatHouse House2 = new CatHouse(2);


            Cat cat1 = new Cat("Tom ", 0, 0, 0, 0);

            House1.AddCat(cat1);
            Cat cat2 = new Cat("Jerry ", 0, 0, 0, 0);
            House2.AddCat(cat2);

            CatShop shop = new CatShop(2);
            shop.House.AddCat(cat1);
            shop.House.AddCat(cat2);

            House1.AddHouse(House2);
            

            foreach (Cat cat in shop.House.Cats)
            {
                if (cat != null)
                {

                    cat.PrintCats();
                }

            }
            do
            {
         



                cat2.Eat();
                cat1.Eat();
                cat2.Play();
                cat1.Play();
                cat2.Sleep();
                cat1.Sleep();
                cat1.PrintCats();
                cat2.PrintCats();
                Thread.Sleep(50);
                Console.Clear();
               


            } while (cat1.consume != 4 || cat2.consume != 4 );
            Console.ForegroundColor = ConsoleColor.Green;
            double totalMass = shop.House.GetTotalMass();
            Console.WriteLine($"Cat GetTotalMass : {totalMass} kg");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;

            double totalConsume = shop.House.GetTotalConsume();
            Console.WriteLine($"Cat GetTotalMass : {totalConsume} kg");
            Console.ResetColor();


            foreach (Cat cat in shop.House.Cats)
            {
                if (cat != null)
                {

                    cat.PrintCats();
                }

            }



        }
    }
}