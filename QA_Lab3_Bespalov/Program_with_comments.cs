using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOAS_Lab3
{
    /*!
        \brief Класс "Добавка", представляет из себя специю для блюда (Dish).
    */
    class Spice
    {
        protected double cost_1g;
        protected int amount_g_on_kg;

        /*!
            \brief Инициализирует переменные cost_1g и amount_g_on_kg для специи (Spice).
        
            \param d - Идентичен cost_1g, цена за 1 грамм специи;
            \param a - Идентичен amount_g_on_kg, количество грамм специи за килограмм блюда;
        */
        public void Init(double d, int a)
        {
            cost_1g = d;
            amount_g_on_kg = a;
        }

        /*!
            \brief Позволяет ввести с консоли значения для создания специи (Spice).
        
            Позволяет ввести переменные cost_1g (цена за 1 грамм специи) и amount_g_on_kg (количество грамм специи за килограм блюда). 
        */
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

        /*!
            \brief Выводит в консоль информацию о специи (Spice).
        
            Выводит в консоль значения cost_1g (цена за 1 грамм специи) и amount_g_on_kg (количество грамм специи за килограм блюда).
        */
        public void Display()
        {
            string s = Convert.ToString(cost_1g) + " " + Convert.ToString(amount_g_on_kg) + " ";
            Console.Write(s);
        }

        /*!
            \brief Считает общую цену за специю (Spice).

            \return Результат произведения цены специи за один грамм на количество грамм специи.

            Формула:
                \f[
                    P = c * n
                \f]
                , где
                - P - стоимость специи,
                - c - Цена за 1 грамм специи,
                - n - количество грамм специи за килограмм блюда.
        */
        public double Price()
        {
            return (cost_1g * amount_g_on_kg);
        }
    }

    /*!
        \brief Класс "Сорт", частный случай специи (Spice) с учитыванием сорта.
    */
    class Sort : Spice
    {
        private int sort;

        /*!
            \brief Считает общую цену за специю с учётом типа сорта (Sort).

            \image html sort_types_table.png "Таблица типов сортов" width=300px
        */
        public double Price()
        {
            double price;
            price = cost_1g * amount_g_on_kg;
            if (sort == 1) price = (price + (price * 0.3));
            else if (sort == 2) price = price;
            else if (sort == 3) price = (price - (price * 0.1));
            return price;
        }

        /*!
            \brief Инициализирует переменные cost_1g и amount_g_on_kg для специи с учетом сорта (Sort).
        
            \param c - Идентичен cost_1g, цена за 1 грамм специи;
            \param a - Идентичен amount_g_on_kg, количество грамм специи за килограмм блюда;
            \param s - Идентичен sort, принимает значения от 1 до 3, то есть может относиться к одному из трёх типов сортов
        */
        public void Init(double c, int a, int s)
        {
            base.Init(c, a);
            sort = s;
        }

        /*!
            \brief Выводит в консоль информацию о специи с учетом типа сорта (Sort);

            Выводит в консоль значения cost_1g (цена за 1 грамм специи), amount_g_on_kg (количество грамм специи за килограмм блюда) и sort (один из трёх типов сортов).
        */
        public void Display()
        {
            base.Display();
            // Не удаляйте ' + " " ', это нужно для красивого вывода Display в классе Dish.
            Console.Write(Convert.ToString(sort) + " ");
        }
    }

    /*!
        \brief Класс блюда, состоящего из одной специи (Spice) и другой с учитыванием сорта (Sort).
    */
    class Dish
    {
        private Spice additive = new Spice();
        private Sort sort = new Sort();
        private double weight, cost_1base;
        private string name;

        /*!
            \brief Инициализирует создание блюда (Dish).

            \param n - Идентичен name, название блюда;
            \param spc - Идентичен additive, переменная типа Spice, специя для блюда.
            \param srt - Идентичен sort, переменная типа Sort, специя частного случая с учетом сорта для блюда.
            \param w - Идентичен weight, вес блюда без добавок в киллограммах.
            \param c1b - Идентичен cost_1base, стоимость единицы основных компонент блюда (без добавок).
        */
        public void Init(String n, Spice spc, Sort srt, double w, double c1b)
        {
            name = n;
            additive = spc;
            sort = srt;
            weight = w;
            cost_1base = c1b;
        }

        /*!
            \brief Позволяет ввести с консоли значения для создания блюда (Dish).

            Позволяет ввести переменные name (название блюда), инициализировать переменную additive типа Spice запрашивая ввод cost_1g (цена за 1 грамм специи) и amount_g_on_kg (количество грамм специи за килограм блюда), инициализировать переменную sort типа Sort запрашивая ввод cost_1g, amount_g_on_kg и sort (один из трёх типов сорта), ввести переменную weight (вес блюда) и cost_1base (стоимость единицы основных компонент блюда, без добавок).
        */
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

        /*!
            \brief Выводит в консоль информацию о составе блюда.

            Выводит в консоль значения name (название блюда), cost_1g (цена за 1 грамм специи) и amount_g_on_kg (количество грамм специи за килограм блюда) первой специи (Spice), cost_1g, amount_g_on_kg и sort (один из трёх типов сорта) второй специи (Sort) с учитыванием типа сорта, weight (вес блюда) и cost_1base (стоимость единицы основных компонент блюда, без добавок).
        */
        public void Display()
        {
            Console.WriteLine(name);
            additive.Display();
            sort.Display();
            Console.WriteLine(Convert.ToString(weight) + " " + Convert.ToString(cost_1base));
        }

        /*!
            \brief Высчитывает стоимость блюда.

            \return Стоимость одной добавки и второй с учетом типа сорта, умноженных на вес блюда с добавлением стоимости основных компонентов блюда.
            
            Формула:
            \f[
                S = (P1 + P2) * w + c
            \f]
            , где
            - S - стоимость всего блюда,
            - P1 - стоимость первой специи на килограмм блюда,
            - P2 - стоимость второй специи с сортом на килограмм блюда,
            - w - вес блюда в киллограммах,
            - c - стоимость единицы основных компонент блюда без добавок.
        */
        public double AllPrice()
        {
            return ((additive.Price() + sort.Price()) * weight + cost_1base);
        }
    }

    /*!
        \brief Основной класс для запуска программы. 
    */
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
            Console.WriteLine();
        }
    }
}
