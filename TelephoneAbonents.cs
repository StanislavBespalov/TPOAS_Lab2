using System;
using System.Text.RegularExpressions;
namespace Coursework
{ 
public class TelephoneAbonents
{
    public String fio, fioDel;
    public String number, numberDel;
    public int year; 
    public TelephoneAbonents() { fio = "Имя Фамилия Отчество"; number = "0"; year = 0; }
    public TelephoneAbonents(String FIO, String Number, int Year) { fio = FIO; number = Number; year = Year; }

    public void getData()
    {
        string pattern = "[+7|8]-[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}";
        Console.Write("Введите Ф.И.О. абонента ");
        fio = Console.ReadLine();
        do {
            Console.Write("Введите № телефона в формате <<+7-000-000-00-00>> ");
            number = Console.ReadLine();
            if (Regex.IsMatch(number, pattern, RegexOptions.IgnoreCase) == false) Console.WriteLine("Номер телефона введен не верно!");
        }while(Regex.IsMatch(number, pattern, RegexOptions.IgnoreCase) == false);
        do
        {
            Console.Write("Введите год установки телефона ");
            year = int.Parse(Console.ReadLine());
            if (year<1876) Console.WriteLine("Неверный год установки телефона (в этот год телефон не был изобретен)");
        } while (year < 1876);
    }

    public void getData2()
    {
        Console.Write("Введите Ф.И.О. абонента ");
        fioDel = Console.ReadLine();
        Console.Write("Введите № телефона в формате <<+7-000-000-00-00>> ");
        numberDel = Console.ReadLine();
    }

    public void showData()
    {
        Console.WriteLine(fio);
        Console.WriteLine(number);
        Console.WriteLine(year);
    }

    public void showData2()
    {
        Console.WriteLine(fioDel);
        Console.WriteLine(numberDel);
    }

    public void dataFind(string FIO_find)
    {
        if (fio == FIO_find)
        {
            Console.WriteLine(fio);
            Console.WriteLine(year);
        }
    }

        /*
    public void diskOut(StreamWriter sw)
    {
        sw.WriteLine(fio);
        sw.WriteLine(number);
        sw.WriteLine(year);
    }
        */

        public void diskIn(TextReader reader)
        {
            fio = reader.ReadLine();
            number = reader.ReadLine();
            year = Convert.ToInt32(reader.ReadLine());
        }

        public void diskOut(TextWriter writer)
        {
            writer.WriteLine(fio);
            writer.WriteLine(number);
            writer.WriteLine(year);
        }

        public void diskOut2(StreamWriter sw)
    {
        sw.WriteLine(fioDel);
        sw.WriteLine(numberDel);
    }

    /*
    public void diskIn(StreamReader sr)
    {
        fio = sr.ReadLine();
        number = sr.ReadLine();
        year = Convert.ToInt32(sr.ReadLine());

    }
    */

    public void diskIn2(StreamReader sr)
    {
        fioDel = sr.ReadLine();
        numberDel = sr.ReadLine();

    }

    public bool fioSkip(ref int K, TelephoneAbonents massive2)
    {
        if (fio != massive2.fioDel) { return true; }
        else
        {
            K = K - 1; return false;
        }
    } 

    public void numberFioRename(TelephoneAbonents massive2)
    {
        if(number == massive2.numberDel)
        {
            Console.Write("Введите Ф.И.О. абонента, которое хотите вставить на место заменяемого: ");
            fio = Console.ReadLine();
        }
    }
}
}