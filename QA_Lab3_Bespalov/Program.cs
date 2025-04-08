using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOAS_Lab3
{
    class Spice
    {
        protected double cost_1g;
        protected int amount_g_on_kg;

        public void Init(double d, int a)
        {
            cost_1g = d;
            amount_g_on_kg = a;
        }
        public void Read()
        {
            string s = "";
            s = Console.ReadLine();
            string[] s1;
            s1 = s.Split(new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
            cost_1g = Convert.ToDouble(s1[0]);
            amount_g_on_kg = Convert.ToInt32(s1[1]);

        }
        public void Display()
        {
            string s = Convert.ToString(cost_1g) + " " + Convert.ToString(amount_g_on_kg) + " ";
            Console.Write(s);
        }
        public double Price()
        {
            return (cost_1g * amount_g_on_kg);
        }
    }

    class Sort : Spice
    {
        private int sort;
        public double Price()
        {
            double price;
            price = cost_1g * amount_g_on_kg;
            if (sort == 1) price = (price + (price * 0.3));
            else if (sort == 2) price = price;
            else if (sort == 3) price = (price - (price * 0.1));
            return price;
        }
        public void Init(double c, int a, int s)
        {
            base.Init(c, a);
            sort = s;
        }
        public void Display()
        {
            base.Display();
            Console.Write(Convert.ToString(sort) + " ");
        }
    }

    class Dish
    {
        private Spice additive = new Spice();
        private Sort sort = new Sort();
        private double weight, cost_1base;
        private string name;

        public void Init(String n, Spice spc, Sort srt, double w, double c1b)
        {
            name = n;
            additive = spc;
            sort = srt;
            weight = w;
            cost_1base = c1b;
        }
        public void Read()
        {
            Console.WriteLine("Введите название блюда:");
            name = Console.ReadLine();
            Console.WriteLine("Введите стоимость и количество первой специи: ");
            additive.Read();
            Console.WriteLine("Введите стоимость и количество второй специи с сортом: ");
            sort.Read();
            Console.WriteLine("Введите вес блюда: ");
            string s = Console.ReadLine();
            weight = Convert.ToDouble(s);
            Console.WriteLine("Введите стоимость базового ингридиента: ");
            s = Console.ReadLine();
            cost_1base = Convert.ToDouble(s);
        }
        public void Display()
        {
            Console.WriteLine(name);
            additive.Display();
            sort.Display();
            Console.WriteLine(Convert.ToString(weight) + " " + Convert.ToString(cost_1base));
        }
        public double AllPrice()
        {
            return ((additive.Price() + sort.Price()) * weight + cost_1base);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Spice additive = new Spice();
            Sort sort = new Sort();
            Dish dish = new Dish();
            double all_price_dish;
            additive.Init(15.25, 3);
            Console.WriteLine("Стоимость 1 гр и целое количество грамм на 1 кг пищевой добавки (специи) №1: ");
            additive.Display();
            Console.WriteLine('\n' + "Стоимость добавки №1: " + additive.Price());
            sort.Init(15.25, 3, 3);
            Console.WriteLine("Стоимость 1 гр и целое количество грамм на 1 кг пищевой добавки (специи) №2: ");
            sort.Display();
            Console.WriteLine('\n' + "Стоимость добавки №2: " + sort.Price());

            String s = "Суп с копченостями";
            dish.Init(s, additive, sort, 8.5, 99);
            Console.WriteLine("Информация о блюде ");
            dish.Display();
            all_price_dish = dish.AllPrice();
            Console.WriteLine("Общая стоимость блюда: " + all_price_dish);
        }
    }
}
