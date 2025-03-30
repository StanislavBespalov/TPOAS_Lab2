using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
namespace Coursework
{
    class Coursework
    {
        static void Main()
        {
            bool ff = true;
            int p, N;
            String FIO_find;

            TelephoneAbonents[] massive = null;
            TelephoneAbonents massive2 = null;
            StreamWriter sw;
            StreamReader sr;
            StreamReader sr2;
            try {
                sr = new StreamReader("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона.txt", System.Text.Encoding.Default);
                int count = 0;
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    count++;
                }
                N = count / 3;
                sr.Close();
                if (N == 0)
                {
                    Console.WriteLine("Введите количество объектов: ");
                    N = int.Parse(Console.ReadLine());
                }
                    do { 
                    Console.WriteLine("Введите: ");
                    Console.WriteLine("1 - Создание файла и ввод данных");
                    Console.WriteLine("2 - Вывод данных из файла");
                    Console.WriteLine("3 - Вывод ФИО и года установки телефона по вводу ФИО");
                    Console.WriteLine("4 - Создание и вывод отдельного файла с ФИО и номером телефона, запись данных в исходный файл");
                    Console.WriteLine("5 - Удаление из исходного файла указанного ФИО и замена ФИО с введенным номером телефона");
                    Console.Write(">");
                    p = int.Parse(Console.ReadLine());

                    if (p == 1)
                    {
                        ff = false;
                        massive = new TelephoneAbonents[N];
                        for (int i = 0; i < N; i++) { massive[i] = new TelephoneAbonents(); massive[i].getData(); }
                        sw = new StreamWriter("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона.txt", false, System.Text.Encoding.Default);
                        for (int i = 0; i < N; i++) { massive[i].diskOut(sw); }
                        sw.Close();
                    }

                    if (p == 2)
                    {
                        ff = false;
                        sr = new StreamReader("     Абоненты телефона.txt", System.Text.Encoding.Default);
                        massive = new TelephoneAbonents[N];
                        Console.WriteLine("Вывод из файла: ");
                        for (int i = 0; i < N; i++)
                        {
                            massive[i] = new TelephoneAbonents();
                            massive[i].diskIn(sr);
                            massive[i].showData();
                        }
                        sr.Close();
                    }

                    if (p == 3)
                    {
                        ff = false;
                        Console.Write("Сколько фамилий вы хотите запросить? ");
                        int N1 = int.Parse(Console.ReadLine());
                        for (int j = 0; j < N1; j++)
                        {
                            Console.Write("Введите Ф.И.О. ");
                            FIO_find = Console.ReadLine();
                            sr = new StreamReader("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона.txt", System.Text.Encoding.Default);
                            Console.WriteLine("Информация из файла: ");
                            massive = new TelephoneAbonents[N];
                            for (int i = 0; i < N; i++)
                            {
                                massive[i] = new TelephoneAbonents();
                                massive[i].diskIn(sr);
                                massive[i].dataFind(FIO_find);
                            }
                            sr.Close();
                        }
                    }

                    if (p == 4)
                    {
                        ff = false;
                        massive2 = new TelephoneAbonents();
                        massive2.getData2();
                        Console.WriteLine("Вывод из нового файла: ");
                        StreamWriter sw2 = new StreamWriter("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона 2.txt", false, System.Text.Encoding.Default);
                        massive2.diskOut2(sw2);
                        sw2.Close();
                        sr2 = new StreamReader("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона 2.txt", System.Text.Encoding.Default);
                        massive2 = new TelephoneAbonents();
                        massive2.diskIn2(sr2);
                        massive2.showData2();
                        sr2.Close();
                        sr2 = new StreamReader("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона 2.txt", System.Text.Encoding.Default);
                        sw = new StreamWriter("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона.txt", true, System.Text.Encoding.Default);
                        massive2 = new TelephoneAbonents();
                        massive2.diskIn2(sr2);
                        massive2.diskOut2(sw);
                        sr2.Close();
                        sw.Close();
                    }

                    if (p == 5)
                    {
                        ff = false;
                        int K = N;
                        sr = new StreamReader("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона.txt", System.Text.Encoding.Default);
                        massive = new TelephoneAbonents[N];
                        for (int i = 0; i < N; i++)
                        {
                            massive[i] = new TelephoneAbonents();
                            massive[i].diskIn(sr);
                        }
                       
                        massive2 = new TelephoneAbonents();
                        massive2.diskIn2(sr);
                        sr.Close();
                        TelephoneAbonents[] massiveNew = null;
                        massiveNew = new TelephoneAbonents[K];
                        for (int i = 0, j = 0; i < N; i++)
                        {
                            massive[i].numberFioRename(massive2);
                            if (massive[i].fioSkip(ref K, massive2)) { massiveNew[j] = massive[i]; j++; }
                        }
                        sw = new StreamWriter("C:\\Users\\User\\OneDrive\\Рабочий стол\\Учёба\\Курсач по ПП\\Курсовая C#\\Абоненты телефона.txt", false, System.Text.Encoding.Default);
                        for (int i = 0; i < K; i++)
                        {
                            massiveNew[i].diskOut(sw);
                        }
                        sw.Close();
                    }
                } while (ff);
            } catch(Exception ex) { };
        }
    }
}