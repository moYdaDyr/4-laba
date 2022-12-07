using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static char forBorder = '#',forStrelka='@';
        static int MaxLength(string[] menuStrings)
        {
            int maxLength = 0;
            for (int i=0;i<menuStrings.Length;i++){
                if (menuStrings[i].Length > maxLength)
                    maxLength = menuStrings[i].Length;
            }
            return maxLength;
        }
        static int[] AddToArray(int[] array, int[] supArray, int number)
        {
            int[] resArray = new int[array.Length + supArray.Length];

            for (int i = 0; i < number; i++)
            {
                resArray[i] = array[i];
            }
            for (int i = number, i1 = 0; i1 < supArray.Length; i++, i1++)
            {
                resArray[i] = supArray[i1];
            }
            for (int i = number + supArray.Length, i1 = number; i1 < array.Length; i++, i1++)
            {
                resArray[i] = array[i1];
            }
            return resArray;
        }
        static int[] AddToEnd(int[] array, int[] supArray)
        {
            int[] resArray = new int[array.Length + supArray.Length];
            for (int i = 0; i < array.Length; i++)
            {
                resArray[i] = array[i];
            }
            for(int i= array.Length,i1=0; i< resArray.Length; i++,i1++)
            {
                resArray[i] = supArray[i1];
            }
            return resArray;
        }
        static int[] DeleteFromArray(int[] array, int choosed)
        {
            int[] resArray = new int[array.Length - 1];
            for (int i = 0, i1 = 0; i < resArray.Length; i++, i1++)
            {
                if (i1 == choosed)
                {
                    i--; continue;
                }
                resArray[i] = array[i1];
            }
            return resArray;
        }
        static int[] UdalitNechyotnie(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    count++;
                }
            }
            int[] resArray = new int[count];
            for (int i = 0, i1 = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    resArray[i1] = array[i]; i1++;
                }
            }
            return resArray;
        }
        static int[] Perestanovka(int[] array)
        {
            int[] resArray = new int[array.Length];
            for (int i = 0, i1 = 0, i2 = array.Length - 1; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    resArray[i1] = array[i]; i1++;
                }
                else
                {
                    resArray[i2] = array[i]; i2--;
                }
            }
            return resArray;
        }
        static int[] Sortirovka(int[] array, int first, int last)
        {
            int i = first;
            int i1 = last;
            int mid = array[first];
            while (i <= i1)
            {
                while (array[i] < mid)
                {
                    i++;
                }
                while (array[i1] > mid)
                {
                    i1--;
                }
                if (i <= i1)
                {
                    int a = array[i];
                    array[i] = array[i1];
                    array[i1] = a;
                    i++;
                    i1--;
                }
            }
            if (first < i1)
            {
                Sortirovka(array, first, i1);
            }
            if (last > i)
            {
                Sortirovka(array, i, last);
            }
            return array;
        }
        static bool SortCheck(int[] array)
        {
            for (int i=0;i<array.Length-1; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }
            return true;
        }
        static int[] Creation(int min, int max, int number)
        {
            int[] sArray = new int[number];
            for (int i = 0; i < number; i++)
            {
                sArray[i] = new Random().Next(min, max);
            }
            return sArray;
        }
        static int Poisk(int[] array, int toFind, out int count)
        {
            int position = -1; count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count++;
                if (array[i] == toFind)
                {
                    position = i; break;
                }
            }
            return position;
        }
        static int BinPoisk(int[] array, int toFind, out int count)
        {
            count = 0;
            int first = 0, last = array.Length - 1, mid = (first + last) / 2;
            while (first < last - 1)
            {
                count++;
                mid = (first + last) / 2;
                if (array[mid] == toFind)
                    return mid;
                if (array[mid] < toFind)
                    first = mid;
                else
                    last = mid;
            }
            if (array[mid] != toFind)
            {
                if (array[first] == toFind)
                    mid = first;
                else if (array[last] == toFind)
                    mid = last;
                else mid = -1;
            }
            return mid;
        }
        static void ShowButton(int otstup, int shirina, string nadpis, bool choosed = false)
        {
            int otstupVnutri = (shirina - 2 - nadpis.Length) / 2;
            if (choosed)
            {
                Console.WriteLine(Otstup(otstup - 3) + forStrelka + "   " + Otstup(shirina, forBorder) + ' ');
                Console.WriteLine(Otstup(otstup - 2) + forStrelka + "  " + forBorder + Otstup(shirina - 2, ' ') + forBorder + ' ');
                Console.WriteLine(Otstup(otstup - 1) + forStrelka + " " + forBorder + Otstup(otstupVnutri, ' ') + nadpis + Otstup(shirina - 2 - nadpis.Length - otstupVnutri, ' ') + forBorder + ' ');
                Console.WriteLine(Otstup(otstup - 2) + forStrelka + "  " + forBorder + Otstup(shirina - 2, ' ') + forBorder + ' ');
                Console.WriteLine(Otstup(otstup - 3) + forStrelka + "   " + Otstup(shirina, forBorder) + ' ');
                Console.WriteLine();
                return;
            }
            Console.WriteLine(Otstup(otstup) + Otstup(shirina, forBorder) + ' ');
            Console.WriteLine(Otstup(otstup) + forBorder + Otstup(shirina - 2, ' ') + forBorder + ' ');
            Console.WriteLine(Otstup(otstup) + forBorder + Otstup(otstupVnutri, ' ') + nadpis + Otstup(shirina - 2 - nadpis.Length - otstupVnutri, ' ') + forBorder + ' ');
            Console.WriteLine(Otstup(otstup) + forBorder + Otstup(shirina - 2, ' ') + forBorder + ' ');
            Console.WriteLine(Otstup(otstup) + Otstup(shirina, forBorder) + ' ');
            Console.WriteLine();
        }
        static void ShowNote(int otstup, int shirina, string[] notes)
        {
            if (notes[0] == ""){
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Otstup(otstup) + Otstup(shirina, forBorder) + ' ');
            Console.WriteLine(Otstup(otstup) + forBorder + Otstup(shirina - 2, ' ') + forBorder + ' ');
            for (int i = 0; i < notes.Length; i++)
            {
                int otstupVnutri = (shirina - 2 - notes[i].Length) / 2;
                Console.WriteLine(Otstup(otstup) + forBorder + Otstup(otstupVnutri, ' ') + notes[i] + Otstup(shirina - 2 - notes[i].Length - otstupVnutri, ' ') + forBorder + ' ');
                Console.WriteLine(Otstup(otstup) + forBorder + Otstup(shirina - 2, ' ') + forBorder + ' ');
            }
            Console.WriteLine(Otstup(otstup) + Otstup(shirina, forBorder) + ' ');
            Console.WriteLine();
            Console.ResetColor();
        }
        static int GetMaxShir(string[] logo, int maxMenuString, string signature)
        {
            int maxLength = 0;
            if (logo[0].Length > maxLength)
            {
                maxLength = logo[0].Length;
            }
            if (maxMenuString > maxLength)
            {
                maxLength = maxMenuString;
            }
            if (signature.Length > maxLength)
            {
                maxLength = signature.Length;
            }
            return maxLength;
        }
        static string Otstup(int number, char c=' ')
        {
            string s = new String(c,number);
            return s;
        }
        static int ShowMenu(string[] logo, string[] menuStrings, string signature,  string[] notes)
        {
            Console.Clear();
            int shirina, vysota, maxMenuString, choosedButton=0;
            maxMenuString = Math.Max(MaxLength(menuStrings), MaxLength(notes));
            int minShir, minVys;
            minShir = GetMaxShir(logo, maxMenuString, signature);
            minVys = logo.Length + menuStrings.Length * 6 + 2 + 2;
            if (notes[0]!="") minVys += 4+notes.Length*2;
            Console.CursorVisible = false;
            while (true){
                shirina = Console.WindowWidth; vysota = Console.WindowHeight;
                int otstupForLogo, otstupForMenu, otstupForSign, buttonShirina, otstupVertical;
                
                if(shirina<minShir)
                {
                    shirina = minShir;
                }
                if (vysota < minVys) 
                {
                    vysota = minVys;
                }
                Console.SetBufferSize(shirina, vysota);
                Console.SetWindowSize(shirina, vysota);
                Console.CursorVisible = false;

                otstupForLogo = (shirina - logo[0].Length) / 2;
                otstupForSign = (shirina - signature.Length) / 2;

                otstupVertical = vysota - minVys+4;
                
                buttonShirina = Math.Max(maxMenuString + 4, (signature.Length + logo[0].Length) / 2);

                otstupForMenu = (shirina - buttonShirina) / 2;

                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.WriteLine( Otstup(otstupForLogo) + logo[i]);
                }
                Console.ResetColor();

                for (int i = 0; i < otstupVertical/2; i++)
                {
                    Console.WriteLine();
                }

                ShowNote(otstupForMenu, buttonShirina, notes);

                for ( int i = 0; i < menuStrings.Length; i++)
                {
                    if (i != choosedButton)
                    {
                        ShowButton(otstupForMenu, buttonShirina, menuStrings[i]);
                    }
                    else
                    {
                        if (i!= menuStrings.Length - 1)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else 
                            Console.ForegroundColor = ConsoleColor.Red;
                        ShowButton(otstupForMenu, buttonShirina, menuStrings[i],true);
                        Console.ResetColor();
                    }
                }

                for (int i = 0; i < otstupVertical - (otstupVertical / 2)-1; i++)
                {
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Otstup(otstupForSign)+signature);
                Console.ResetColor();

                while (true)
                {
                    if (shirina != Console.WindowWidth || vysota != Console.WindowHeight)
                    {
                        Console.Clear(); break;
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo knopka;
                        knopka= Console.ReadKey(true);
                        if (knopka.Key == ConsoleKey.Enter)
                        {
                            return choosedButton;
                        }      
                        else if (knopka.Key == ConsoleKey.UpArrow) {
                            choosedButton--; 
                            choosedButton = choosedButton < 0 ? menuStrings.Length - 1 : choosedButton; 
                            choosedButton %= menuStrings.Length;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.DownArrow) {
                            choosedButton++; 
                            choosedButton %= menuStrings.Length;
                            break;
                        } 
                        else if (knopka.Key == ConsoleKey.Spacebar) {
                            choosedButton++; 
                            choosedButton %= menuStrings.Length;
                            break;
                        }
                    }
                }
                Console.SetCursorPosition(0,0);
            }
        }
        static void ShowArrayInit(string[] logo, string signature, out int[] array)
        {
            int shirina, vysota, maxMenuString, choosedButton = 0;
            Console.Clear();
            string[] notes = { "ЗДЕСЬ МОЖНО НАСТРОИТЬ СОЗДАВАЕМЫЙ МАССИВ", "МАССИВ ГЕНЕРИРУЕТСЯ ИЗ СЛУЧАЙНЫХ ЧИСЕЛ", "ЧТОБЫ НАЧАТЬ / ЗАКОНЧИТЬ ВВОД НАЖМИТЕ ENTER" };

            string onMinPolzunok = "МИНИМАЛЬНЫЙ ВОЗМОЖНЫЙ ЭЛЕМЕНТ:", 
                onMaxPolzunok = "МАКСИМАЛЬНЫЙ ВОЗМОЖНЫЙ ЭЛЕМЕНТ:", 
                onLength = "КОЛИЧЕСТВО ЭЛЕМЕНТОВ В МАССИВЕ:";

            maxMenuString = Math.Max(Math.Max(onMinPolzunok.Length, onMaxPolzunok.Length), MaxLength(notes));
            int minShir, minVys;

            minShir = GetMaxShir(logo, maxMenuString, signature);

            minVys = logo.Length + 2 + 6*3 + 2*5 + 2 + 1 +2*notes.Length;

            int maxElem = Int32.MaxValue, minElem = Int32.MinValue+1;

            int number = 1;

            minVys += 8;
            Console.CursorVisible = false;

            bool rezhimVvoda = false;

            while (true)
            {
                shirina = Console.WindowWidth; vysota = Console.WindowHeight;
                int otstupForLogo, otstupForMenu, otstupForSign, buttonShirina, otstupVertical;

                if (shirina < minShir)
                {
                    shirina = minShir;
                }
                if (vysota < minVys)
                {
                    vysota = minVys;
                }
                Console.SetBufferSize(shirina, vysota);
                Console.SetWindowSize(shirina, vysota);
                Console.CursorVisible = false;

                otstupForLogo = (shirina - logo[0].Length) / 2;
                otstupForSign = (shirina - signature.Length) / 2;

                otstupVertical = vysota - minVys+4;

                buttonShirina = Math.Max(maxMenuString, (signature.Length + logo[0].Length) / 2);

                otstupForMenu = (shirina - buttonShirina) / 2;

                int otstupForSpisok = (shirina - minShir + 2) / 2;

                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.WriteLine(Otstup(otstupForLogo) + logo[i]);
                }
                Console.ResetColor();

                for (int i = 0; i < otstupVertical / 2; i++)
                {
                    Console.WriteLine();
                }

                ShowNote(otstupForMenu, buttonShirina, notes);

                int otstupVnutri = (minShir - 6 - onMaxPolzunok.Length - 1) / 2;

                if (choosedButton == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + onMaxPolzunok + Otstup(minShir - 4 - onMaxPolzunok.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - maxElem.ToString().Length - 1) / 2;
                    if (rezhimVvoda)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                    else
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + maxElem + Otstup(minShir - 4 - maxElem.ToString().Length - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + onMaxPolzunok + Otstup(minShir - 4 - onMaxPolzunok.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - maxElem.ToString().Length - 1) / 2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + maxElem + Otstup(minShir - 4 - maxElem.ToString().Length - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }

                otstupVnutri = (minShir - 6 - onMinPolzunok.Length - 1) / 2;

                if (choosedButton == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + onMinPolzunok + Otstup(minShir - 4 - onMinPolzunok.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - minElem.ToString().Length - 1) / 2;
                    if (rezhimVvoda)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                    else
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + minElem + Otstup(minShir - 4 - minElem.ToString().Length - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + onMinPolzunok + Otstup(minShir - 4 - onMinPolzunok.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - minElem.ToString().Length - 1) / 2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + minElem + Otstup(minShir - 4 - minElem.ToString().Length - otstupVnutri) + forBorder+' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }

                otstupVnutri = (minShir - 6 - onLength.Length - 1) / 2;

                if (choosedButton == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + onLength + Otstup(minShir - 4 - onLength.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - number.ToString().Length - 1) / 2;
                    if (rezhimVvoda)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                    else
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + number + Otstup(minShir - 4 - number.ToString().Length - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir-2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + onLength + Otstup(minShir - 4 - onLength.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - number.ToString().Length - 1) / 2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + number + Otstup(minShir - 4 - number.ToString().Length - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir-2, forBorder));
                    Console.WriteLine();
                }

                if (choosedButton == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ShowButton(otstupForMenu, buttonShirina, "СГЕНЕРИРОВАТЬ МАССИВ", true);
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    ShowButton(otstupForMenu, buttonShirina, "СГЕНЕРИРОВАТЬ МАССИВ");
                }

                if (choosedButton == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ShowButton(otstupForMenu, buttonShirina, "ВЫЙТИ В МЕНЮ", true);
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    ShowButton(otstupForMenu, buttonShirina, "ВЫЙТИ В МЕНЮ");
                }

                for (int i = 0; i < otstupVertical - (otstupVertical / 2) - 1; i++)
                {
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Otstup(otstupForSign) + signature);
                Console.ResetColor();

                if (rezhimVvoda)
                {
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(otstupForMenu,logo.Length+otstupVertical/2 + 3+notes.Length*2+4 + choosedButton*7);
                    Console.ForegroundColor = ConsoleColor.Green;
                    string s;
                    s=Console.ReadLine();
                    int o; bool b = Int32.TryParse(s,out o);
                    if (!b)
                    {
                        Console.CursorVisible = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (choosedButton == 0 && o < minElem)
                    {
                        int a = minElem;
                        minElem = o;
                        maxElem = a;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (choosedButton == 1 && o > maxElem)
                    {
                        int a = maxElem;
                        maxElem = o;
                        minElem = a;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (choosedButton == 2 && o < 1)
                    {
                        number = 1;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        switch (choosedButton)
                        {
                            case 0: maxElem = o; break;
                            case 1: minElem = o; break;
                            case 2: number = o; break;
                        }
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                }

                while (true)
                {
                    if (shirina != Console.WindowWidth || vysota != Console.WindowHeight)
                    {
                        Console.Clear(); break;
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo knopka;
                        knopka = Console.ReadKey(true);

                        if (knopka.Key == ConsoleKey.Enter)
                        {
                            if (choosedButton==0 || choosedButton == 1 || choosedButton == 2)
                            {
                                rezhimVvoda = true; break;
                            }
                            else if (choosedButton == 3)
                            {
                                array = Creation(minElem, maxElem, number); return;
                            }
                            else
                            {
                                array = new int[0]; return;
                            }
                        }
                        else if (knopka.Key == ConsoleKey.UpArrow)
                        {
                            choosedButton--;
                            choosedButton = choosedButton < 0 ? 5 - 1 : choosedButton;
                            choosedButton %= 5;
                            rezhimVvoda = false;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.DownArrow)
                        {
                            choosedButton++;
                            choosedButton %= 5;
                            rezhimVvoda = false;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.Spacebar)
                        {
                            choosedButton++;
                            choosedButton %= 5;
                            rezhimVvoda = false;
                            break;
                        }
                        

                    }
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        static void ShowList(int otstupForSpisok, int minShir, int number, int[] array, int lastShown, int choosedElem = -1)
        {
            int otstupVnutri;
            int freeSpace=minShir-3;
            for(int i = number; i <= lastShown; i++)
            {
                //Console.WriteLine(i);
                freeSpace -= Math.Max(array[i].ToString().Length+5, (i + 1).ToString().Length + 3);
                
            }
            int otstupSpace = freeSpace/2;
            
            Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
            Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);

            if (choosedElem != -1)
            {
                Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
                for (int i = number; i <= lastShown; i++)
                {
                    int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                    if (i == choosedElem)
                    {
                        otstupVnutri = (dlina - 3) / 2;
                        Console.Write(Otstup(otstupVnutri) + "\\ /" + Otstup(dlina - 3 - otstupVnutri));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Otstup(dlina));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(Otstup(freeSpace - otstupSpace - 1) + forBorder);

                Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
                for (int i = number; i <= lastShown; i++)
                {
                    int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                    if (i == choosedElem)
                    {
                        otstupVnutri = (dlina - 3) / 2;
                        Console.Write(Otstup(otstupVnutri) + " V " + Otstup(dlina - 3 - otstupVnutri));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Otstup(dlina));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(Otstup(freeSpace - otstupSpace - 1) + forBorder);
                Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
            }

            Console.Write(Otstup(otstupForSpisok) + forBorder+ Otstup(otstupSpace));
            for (int i = number; i <= lastShown; i++)
            {
                int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                Console.Write(Otstup(dlina, forBorder));
                Console.Write(" ");
            }
            Console.WriteLine(Otstup(freeSpace-otstupSpace-1) + forBorder);

            Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
            for (int i = number; i <= lastShown; i++)
            {
                int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                Console.Write(forBorder + Otstup(dlina-2) + forBorder);
                Console.Write(" ");
            }
            Console.WriteLine(Otstup(freeSpace - otstupSpace-1) + forBorder);

            Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
            for (int i = number; i <= lastShown; i++)
            {
                int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                otstupVnutri = ( dlina - array[i].ToString().Length - 2) / 2;
                Console.Write(forBorder + Otstup(otstupVnutri) + array[i] + Otstup(dlina - array[i].ToString().Length - 2 - otstupVnutri) + forBorder);
                Console.Write(" ");
            }
            Console.WriteLine(Otstup(freeSpace - otstupSpace-1) + forBorder);

            Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
            for (int i = number; i <= lastShown; i++)
            {
                int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                Console.Write(forBorder + Otstup(dlina-2) + forBorder);
                Console.Write(" ");
            }
            Console.WriteLine(Otstup(freeSpace - otstupSpace - 1) + forBorder);

            Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
            for (int i = number; i <= lastShown; i++)
            {
                int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                Console.Write(Otstup(dlina, forBorder));
                Console.Write(" ");
            }
            Console.WriteLine(Otstup(freeSpace - otstupSpace - 1) + forBorder);

            Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);

            Console.Write(Otstup(otstupForSpisok) + forBorder + Otstup(otstupSpace));
            for (int i = number; i <= lastShown; i++)
            {
                int dlina = Math.Max(array[i].ToString().Length + 4, (i + 1).ToString().Length + 2);
                otstupVnutri = (dlina - (i + 1).ToString().Length - 2) / 2;
                Console.Write(Otstup(otstupVnutri) + "№ " + (i + 1) + Otstup(dlina - (i + 1).ToString().Length - 2 - otstupVnutri));
                Console.Write(" ");
            }
            Console.WriteLine(Otstup(freeSpace - otstupSpace - 1) + forBorder);

            Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
            Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
            Console.WriteLine();
        }
        static void ShowArray(string[] logo, string signature, int[] array, string[] note)
        {
            int shirina, vysota, maxMenuString, choosedButton = 0;
            Console.Clear();

            string voidArray = "МАССИВ ПУСТ";
            string poiskString = "ПЕРЕЙТИ В ПОЗИЦИЮ";
            string quitButton = "ВЫЙТИ В МЕНЮ";
            maxMenuString = quitButton.Length;
            
            int minShir, minVys;
            minShir = Math.Max(logo[0].Length, Math.Max( signature.Length, maxMenuString));

            minVys = logo.Length + 2 + 10 +1+5+2+2+4+2*note.Length+7;

            int number = 0;
            Console.CursorVisible = false;

            bool rezhimVvoda = false;

            while (true)
            {
                shirina = Console.WindowWidth; vysota = Console.WindowHeight;
                int otstupForLogo, otstupForMenu, otstupForSign, buttonShirina, otstupVertical;

                int otstupForSpisok;

                if (shirina < minShir)
                {
                    shirina = minShir;
                }
                if (vysota < minVys)
                {
                    vysota = minVys;
                }
                Console.SetBufferSize(shirina, vysota);
                Console.SetWindowSize(shirina, vysota);
                Console.CursorVisible = false;

                otstupForLogo = (shirina - logo[0].Length) / 2;
                otstupForSign = (shirina - signature.Length) / 2;

                otstupVertical = vysota - minVys + 4;

                buttonShirina = Math.Max(maxMenuString, (signature.Length + logo[0].Length) / 2);

                otstupForMenu = (shirina - buttonShirina) / 2;

                otstupForSpisok = (shirina - minShir + 2) / 2;

                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.WriteLine(Otstup(otstupForLogo) + logo[i]);
                }
                Console.ResetColor();

                for (int i = 0; i < otstupVertical / 2; i++)
                {
                    Console.WriteLine();
                }

                ShowNote(otstupForMenu, buttonShirina, note);

                int otstupVnutri;
                int freeSpace = minShir - 6;
                int lastShown = number;

                if (array.Length != 0)
                {
                    freeSpace -= Math.Max(array[lastShown].ToString().Length + 5, (lastShown + 1).ToString().Length + 3);
                    while (freeSpace >= 0 && lastShown < array.Length - 1)
                    {
                        freeSpace -= Math.Max(array[lastShown].ToString().Length + 5, (lastShown + 1).ToString().Length + 3);
                        lastShown++;
                    }

                    if (freeSpace < 0)
                    {
                        freeSpace += array[lastShown - 1].ToString().Length + 5;
                        lastShown--;
                    }
                }
                
                if (choosedButton == 0 && array.Length!=0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ShowList(otstupForSpisok,minShir,number,array,lastShown);
                    Console.ResetColor();
                }
                else if (choosedButton != 0 && array.Length != 0)
                {
                    Console.ResetColor();
                    ShowList(otstupForSpisok, minShir, number, array, lastShown);
                }

                else if (choosedButton == 0 && array.Length == 0)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    otstupVnutri = (minShir - 4 - voidArray.Length) / 2;

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + voidArray + Otstup(minShir - 4 - voidArray.Length- otstupVnutri) + forBorder);

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }

                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    otstupVnutri = (minShir - 4 - voidArray.Length) / 2;

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + voidArray + Otstup(minShir - 4 - voidArray.Length - otstupVnutri) + forBorder);

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }

                otstupVnutri = (minShir - 6 - poiskString.Length - 1) / 2;

                if (choosedButton == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + poiskString + Otstup(minShir - 4 - poiskString.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - 5 - 1) / 2;
                    if (rezhimVvoda)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                    else
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + ". . ." + Otstup(minShir - 4 - 5 - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + poiskString + Otstup(minShir - 4 - poiskString.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - 5 - 1) / 2;
                    if (rezhimVvoda)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                    else
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + ". . ." + Otstup(minShir - 4 - 5 - otstupVnutri) + forBorder + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }


                if (choosedButton == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ShowButton(otstupForMenu, buttonShirina, "ВЫЙТИ В МЕНЮ", true);
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    ShowButton(otstupForMenu, buttonShirina, "ВЫЙТИ В МЕНЮ");
                }

                for (int i = 0; i < otstupVertical - (otstupVertical / 2) - 1; i++)
                {
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Otstup(otstupForSign) + signature);
                Console.ResetColor();

                if (rezhimVvoda)
                {
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(otstupForMenu, logo.Length + otstupVertical / 2 + 2 + 10 + 4 +3+2*note.Length);
                    Console.ForegroundColor = ConsoleColor.Green;
                    string s;
                    s = Console.ReadLine();
                    int o; bool b = Int32.TryParse(s, out o);
                    if (!b)
                    {
                        Console.CursorVisible = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (o<1)
                    {
                        Console.CursorVisible = false;
                        number = 0;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (o > array.Length)
                    {
                        Console.CursorVisible = false;
                        lastShown = array.Length-1;
                        
                        freeSpace = minShir - 6;
                        number = lastShown;
                        freeSpace -= Math.Max(array[number].ToString().Length + 5, (number + 1).ToString().Length + 3);
                        while (freeSpace >= 0 && number > 0)
                        {
                            number--;
                            freeSpace -= Math.Max(array[number].ToString().Length + 5, (number + 1).ToString().Length + 3);
                             
                        }
                        number++;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        number = o-1;
                        lastShown = number;
                        freeSpace = minShir - 6;
                        freeSpace -= Math.Max(array[lastShown].ToString().Length + 5, (lastShown + 1).ToString().Length + 3);
                        while (freeSpace >= 0 && lastShown < array.Length - 1)
                        {
                            freeSpace -= Math.Max(array[lastShown].ToString().Length + 5, (lastShown + 1).ToString().Length + 3);
                            lastShown++;
                        }
                        if (lastShown == array.Length - 1)
                        {
                            freeSpace = minShir - 6;
                            number = lastShown;
                            freeSpace -= Math.Max(array[number].ToString().Length + 5, (number + 1).ToString().Length + 3);
                            while (freeSpace >= 0 && number > 0)
                            {
                                number--;
                                freeSpace -= Math.Max(array[number].ToString().Length + 5, (number + 1).ToString().Length + 3);
                                
                            }
                            number++;
                        }
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                }

                while (true)
                {
                    if (shirina != Console.WindowWidth || vysota != Console.WindowHeight)
                    {
                        Console.Clear(); break;
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo knopka;
                        knopka = Console.ReadKey(true);

                        if (knopka.Key == ConsoleKey.Enter)
                        {
                            if (choosedButton == 1 && array.Length!=0)
                            {
                                rezhimVvoda = true; break;
                            }
                            else if (choosedButton == 2)
                            {
                                return;
                            }
                        }
                        else if (knopka.Key == ConsoleKey.UpArrow)
                        {
                            choosedButton--;
                            choosedButton = choosedButton < 0 ? 3 - 1 : choosedButton;
                            choosedButton %= 3;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.DownArrow)
                        {
                            choosedButton++;
                            choosedButton %= 3;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.Spacebar)
                        {
                            choosedButton++;
                            choosedButton %= 3;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.LeftArrow && choosedButton==0 && number != 0)
                        {
                            number--;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.RightArrow && choosedButton == 0 && lastShown != array.Length - 1)
                        {
                            number++;
                            if (number >= array.Length)
                            {
                                number--;
                            }
                            break;
                        }

                    }
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        static void ShowAdd(string[] logo, string signature, ref int[] array, string[] note, bool isInit=false)
        {
            int shirina, vysota, maxMenuString, choosedButton = 0;
            Console.Clear();

            string vvedyteZnachenie = "ВВЕДИТЕ ЗНАЧЕНИЕ:";
            string postavitVPozitsiu = "ДОБАВИТЬ В ПОЗИЦИЮ №:";
            string voidArray = "ДОБАВЛЯЕМЫЙ МАССИВ ПУСТ";
            int number = 0;

            int choosedNumber = -1;

            int numberOfPosition = 0;

            int[] supArray = new int[0];

            int kolvoKnopok=6;

            int minShir, minVys;
            minShir = Math.Max(logo[0].Length, signature.Length);
            maxMenuString = minShir-2-10-2;

            minVys = logo.Length + 2 + 13 + 7 + 7 + 2 + 2 + 3 + note.Length + 12;

            if (isInit)
            {
                minVys -= 9;
                kolvoKnopok--;
            }
            Console.CursorVisible = false;

            bool rezhimVvoda = false;

            while (true)
            {
                shirina = Console.WindowWidth; vysota = Console.WindowHeight;
                int otstupForLogo, otstupForMenu, otstupForSign, buttonShirina, otstupVertical;

                int otstupForSpisok;

                if (shirina < minShir)
                {
                    shirina = minShir;
                }
                if (vysota < minVys)
                {
                    vysota = minVys;
                }
                Console.SetBufferSize(shirina, vysota);
                Console.SetWindowSize(shirina, vysota);
                Console.CursorVisible = false;

                otstupForLogo = (shirina - logo[0].Length) / 2;
                otstupForSign = (shirina - signature.Length) / 2;

                otstupVertical = vysota - minVys + 4;

                buttonShirina = (signature.Length + logo[0].Length) / 2;

                otstupForMenu = (shirina - buttonShirina) / 2;

                otstupForSpisok = (shirina - minShir + 2) / 2;

                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.WriteLine(Otstup(otstupForLogo) + logo[i]);
                }
                Console.ResetColor();

                for (int i = 0; i < otstupVertical / 2; i++)
                {
                    Console.WriteLine();
                }

                ShowNote(otstupForMenu, buttonShirina, note);

                int otstupVnutri;
                int freeSpace = minShir - 6;
                int lastShown = number;
                
                if (supArray.Length != 0)
                {
                    freeSpace -= Math.Max(supArray[lastShown].ToString().Length + 5, (lastShown + 1).ToString().Length + 3);
                    while (freeSpace >= 0 && lastShown < supArray.Length - 1)
                    {
                        freeSpace -= Math.Max(supArray[lastShown].ToString().Length + 5, (lastShown + 1).ToString().Length + 3);
                        lastShown++;
                    }

                    if (freeSpace < 0)
                    {
                        freeSpace += supArray[lastShown - 1].ToString().Length + 5;
                        lastShown--;
                    }
                }

                if (choosedButton == 0 && supArray.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ShowList(otstupForSpisok, minShir, number, supArray, lastShown, choosedNumber);
                    Console.ResetColor();
                }
                else if (choosedButton != 0 && supArray.Length > 0)
                {
                    Console.ResetColor();
                    ShowList(otstupForSpisok, minShir, number, supArray, lastShown, choosedNumber);
                }
                else if (choosedButton == 0 && supArray.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    otstupVnutri = (minShir - 4 - voidArray.Length) / 2;

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + voidArray + Otstup(minShir - 4 - voidArray.Length - otstupVnutri) + forBorder);

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else if (choosedButton != 0 && supArray.Length == 0)
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    otstupVnutri = (minShir - 4 - voidArray.Length) / 2;

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + voidArray + Otstup(minShir - 4 - voidArray.Length - otstupVnutri) + forBorder);

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }
                

                if(choosedButton == 1)
                {
                    Console.ForegroundColor= ConsoleColor.Green;   
                }

                int startVerticalPosition = logo.Length + 2 + 14 + otstupVertical / 2 + 2*note.Length+3;
                int horizontalPosition = otstupForSpisok;

                Console.SetCursorPosition(horizontalPosition, startVerticalPosition);
                Console.Write(Otstup(5,forBorder));
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+1);
                Console.Write(forBorder + Otstup(3) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+2);
                Console.Write(forBorder + " + " + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+3);
                Console.Write(forBorder + Otstup(3) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+4);
                Console.Write(Otstup(5, forBorder));

                Console.ResetColor();

                horizontalPosition += 6;
                if (choosedButton == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                otstupVnutri = (maxMenuString - 2 - vvedyteZnachenie.Length) / 2;

                Console.SetCursorPosition(horizontalPosition, startVerticalPosition);
                Console.Write(Otstup(maxMenuString, forBorder));
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+1);
                Console.Write(forBorder + Otstup(maxMenuString-2) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+2);
                Console.Write(forBorder + Otstup(otstupVnutri) + vvedyteZnachenie + Otstup(maxMenuString - 2 - otstupVnutri- vvedyteZnachenie.Length) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+3);
                otstupVnutri = (maxMenuString - 2 - 5 - 1) / 2;

                if (rezhimVvoda && choosedButton == 2)
                    Console.Write(forBorder + " >" + Otstup(maxMenuString - 4) + forBorder);
                else if (supArray.Length == 0)
                    Console.Write(forBorder + Otstup(otstupVnutri) + ". . ." + Otstup(maxMenuString - 2 - 5 - otstupVnutri) + forBorder);
                else
                    Console.Write(forBorder + Otstup((maxMenuString - 2 - supArray[choosedNumber].ToString().Length) / 2) + supArray[choosedNumber] + Otstup(maxMenuString - 2 - supArray[number].ToString().Length - (maxMenuString - 2 - supArray[choosedNumber].ToString().Length) / 2) + forBorder);

                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+4);
                Console.Write(forBorder + Otstup(maxMenuString-2) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+5);
                Console.Write(Otstup(maxMenuString, forBorder));

                Console.ResetColor();
                if (choosedButton == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                horizontalPosition += maxMenuString + 1;

                Console.SetCursorPosition(horizontalPosition, startVerticalPosition);
                Console.Write(Otstup(5, forBorder));
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+1);
                Console.Write(forBorder + Otstup(3) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+2);
                Console.Write(forBorder + " X " + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+3);
                Console.Write(forBorder + Otstup(3) + forBorder);
                Console.SetCursorPosition(horizontalPosition, startVerticalPosition+4);
                Console.Write(Otstup(5, forBorder));

                Console.ResetColor();

                Console.SetCursorPosition(0, startVerticalPosition + 7);

                if (!isInit)
                {

                    otstupVnutri = (minShir - 4 - postavitVPozitsiu.Length - 1) / 2;
                    if (choosedButton == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + postavitVPozitsiu + Otstup(minShir - 4 - postavitVPozitsiu.Length - otstupVnutri) + forBorder);
                        otstupVnutri = (minShir - 4 - (numberOfPosition + 1).ToString().Length - 1) / 2;
                        if (rezhimVvoda)
                            Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                        else
                            Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + (numberOfPosition + 1) + Otstup(minShir - 4 - (numberOfPosition + 1).ToString().Length - otstupVnutri) + forBorder + ' ');
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                        Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + postavitVPozitsiu + Otstup(minShir - 4 - postavitVPozitsiu.Length - otstupVnutri) + forBorder);
                        otstupVnutri = (minShir - 4 - (numberOfPosition + 1).ToString().Length) / 2;
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + (numberOfPosition + 1) + Otstup(minShir - 4 - (numberOfPosition + 1).ToString().Length - otstupVnutri) + forBorder + ' ');
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                        Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                        Console.WriteLine();
                    }

                }


                if (choosedButton == kolvoKnopok-1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ShowButton(otstupForMenu, buttonShirina, "ДОБАВИТЬ И ВЫЙТИ В МЕНЮ", true);
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    ShowButton(otstupForMenu, buttonShirina, "ДОБАВИТЬ И ВЫЙТИ В МЕНЮ");
                }

                for (int i = 0; i < otstupVertical - (otstupVertical / 2) - 1; i++)
                {
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Otstup(otstupForSign) + signature);
                Console.ResetColor();

                if (rezhimVvoda)
                {
                    Console.CursorVisible = true;
                    if (choosedButton == 2)
                        Console.SetCursorPosition(otstupForSpisok + 10, startVerticalPosition + 3);
                    else if (choosedButton == 4 && !isInit)
                        Console.SetCursorPosition(otstupForSpisok + 4, startVerticalPosition + 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    string s;
                    s = Console.ReadLine();
                    int o; bool b = Int32.TryParse(s, out o);
                    if (!b)
                    {
                        Console.CursorVisible = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (o < 1 && choosedButton == 4 && !isInit)
                    {
                        Console.CursorVisible = false;
                        numberOfPosition = 0;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (o > array.Length && choosedButton == 4 && !isInit)
                    {
                        Console.CursorVisible = false;
                        numberOfPosition = array.Length;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else if (choosedButton == 4 && !isInit)
                    {
                        Console.CursorVisible = false;
                        numberOfPosition = o-1;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        supArray[choosedNumber] = o;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                }

                while (true)
                {
                    if (shirina != Console.WindowWidth || vysota != Console.WindowHeight)
                    {
                        Console.Clear(); break;
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo knopka;
                        knopka = Console.ReadKey(true);

                        if (knopka.Key == ConsoleKey.Enter)
                        {
                            if (((choosedButton == 2 && supArray.Length!=0) || (choosedButton==4 && !isInit) ) && supArray.Length != 0)
                            {
                                rezhimVvoda = true; break;
                            }
                            else if (choosedButton == 0)
                            {
                                choosedButton = 2;
                                rezhimVvoda = true; break;
                            }
                            else if (choosedButton == 1)
                            {
                                int[] supSupArray = { 0 };
                                supArray = AddToEnd(supArray, supSupArray); choosedNumber++; break;
                            }
                            else if (choosedButton == 3 && supArray.Length!=0)
                            {
                                supArray = DeleteFromArray(supArray, choosedNumber); choosedNumber--; break;
                            }
                            else if (choosedButton == kolvoKnopok-1)
                            {
                                if (isInit && supArray.Length!=0)
                                    array = new int[0];
                                if (numberOfPosition < array.Length)
                                {
                                    array = AddToArray(array, supArray, numberOfPosition); return;
                                }
                                else
                                {
                                    array = AddToEnd(array, supArray); return;
                                }
                            }
                        }
                        else if (knopka.Key == ConsoleKey.UpArrow)
                        {
                            if (choosedButton >= 1 && choosedButton <= 3)
                            {
                                choosedButton = 0;
                                break;
                            }
                            if (choosedButton == 4)
                            {
                                choosedButton = 2;
                                break;
                            }
                            choosedButton--;
                            choosedButton = choosedButton < 0 ? kolvoKnopok - 1 : choosedButton;
                            choosedButton %= kolvoKnopok;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.DownArrow)
                        {
                            if (choosedButton >=1 && choosedButton <= 3)
                            {
                                choosedButton = 4;
                                break;
                            }
                            if (choosedButton == 0)
                            {
                                choosedButton = 2;
                                break;
                            }
                            choosedButton++;
                            choosedButton %= kolvoKnopok;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.Spacebar)
                        {
                            choosedButton++;
                            choosedButton %= kolvoKnopok;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.LeftArrow && choosedButton == 0)
                        {
                            number--;
                            if (number <0)
                            {
                                number++;
                            }
                            choosedNumber--;
                            if (choosedNumber < 0)
                            {
                                choosedNumber++;
                            }
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.LeftArrow && ( choosedButton == 3 || choosedButton == 2))
                        {
                            choosedButton--; break;
                        }
                        else if (knopka.Key == ConsoleKey.RightArrow && choosedButton == 0 && lastShown != supArray.Length - 1)
                        {
                            number++;
                            choosedNumber++;
                            if (number >= supArray.Length)
                            {
                                number--;
                            }
                            if (choosedNumber >= supArray.Length)
                            {
                                choosedNumber--;
                            }
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.RightArrow && (choosedButton == 1 || choosedButton == 2))
                        {
                            choosedButton++; break;
                        }
                        else if (knopka.Key == ConsoleKey.RightArrow && choosedButton == 0)
                        {
                            choosedNumber++;
                            if (choosedNumber >= supArray.Length)
                            {
                                choosedNumber--;
                            }
                            break;
                        }

                    }
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        static void ShowPoisk(string[] logo, string signature, int[] array, string[] note, bool isArraySorted)
        {
            int shirina, vysota, maxMenuString, choosedButton = 0;
            Console.Clear();

            bool isBegin = true, toFindInit = false;

            string beginString = "ИСКОМЫЙ ЭЛЕМЕНТ НЕ ЗАДАН";
            string whereFoundString = "ИСКОМЫЙ ЭЛЕМЕНТ НАШЁЛСЯ В ПОЗИЦИИ:";
            string noWhereFound = "ИСКОМЫЙ ЭЛЕМЕНТ НЕ НАЙДЕН";
            string compCounterString = "ПОТРЕБОВАЛОСЬ СРАВНЕНИЙ:";
            string poiskString = "ВВЕДИТЕ ЗНАЧЕНИЕ ИСКОМОГО ЭЛЕМЕНТА";
            string findButton = "НАЙТИ ЭЛЕМЕНТ";
            string quitButton = "ВЫЙТИ В МЕНЮ";
            maxMenuString = Math.Max(quitButton.Length, findButton.Length);

            int minShir, minVys;
            minShir = Math.Max(logo[0].Length, Math.Max(signature.Length, maxMenuString));

            minVys = logo.Length + 2 + 2*6 + 10 +2 + 1 + 2 * note.Length + 7+3;

            int whereFound = -1, compCounter=0;
            Console.CursorVisible = false;

            bool rezhimVvoda = false;

            int toFind=0;

            while (true)
            {
                shirina = Console.WindowWidth; vysota = Console.WindowHeight;
                int otstupForLogo, otstupForMenu, otstupForSign, buttonShirina, otstupVertical;

                int otstupForSpisok;

                if (shirina < minShir)
                {
                    shirina = minShir;
                }
                if (vysota < minVys)
                {
                    vysota = minVys;
                }
                Console.SetBufferSize(shirina, vysota);
                Console.SetWindowSize(shirina, vysota);
                Console.CursorVisible = false;

                otstupForLogo = (shirina - logo[0].Length) / 2;
                otstupForSign = (shirina - signature.Length) / 2;

                otstupVertical = vysota - minVys + 4;

                buttonShirina = Math.Max(maxMenuString, (signature.Length + logo[0].Length) / 2);

                otstupForMenu = (shirina - buttonShirina) / 2;

                otstupForSpisok = (shirina - minShir + 2) / 2;

                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.WriteLine(Otstup(otstupForLogo) + logo[i]);
                }
                Console.ResetColor();

                for (int i = 0; i < otstupVertical / 2; i++)
                {
                    Console.WriteLine();
                }

                ShowNote(otstupForMenu, buttonShirina, note);

                int otstupVnutri;

                

                if (whereFound==-1 || isBegin)
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    otstupVnutri = (minShir - 4 - beginString.Length)/2;

                    if (isBegin)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + beginString + Otstup(minShir - 4 - beginString.Length - otstupVnutri) + forBorder);
                    else
                    {
                        otstupVnutri = (minShir - 4 - noWhereFound.Length)/2;
                        
                        Console.Write(Otstup(otstupForSpisok) + forBorder);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Otstup(otstupVnutri) + noWhereFound + Otstup(minShir - 4 - noWhereFound.Length - otstupVnutri));
                        Console.ResetColor();
                        Console.WriteLine(forBorder);
                    }

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);

                    otstupVnutri = (minShir - 4 - whereFoundString.Length)/2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + whereFoundString + Otstup(minShir - 4 - whereFoundString.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 4 - whereFound.ToString().Length) / 2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + whereFound + Otstup(minShir - 4 - whereFound.ToString().Length - otstupVnutri) + forBorder);

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);

                    otstupVnutri = (minShir - 4 - compCounterString.Length) / 2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + compCounterString + Otstup(minShir - 4 - compCounterString.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 4 - compCounter.ToString().Length) / 2;
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + compCounter + Otstup(minShir - 4 - compCounter.ToString().Length - otstupVnutri) + forBorder);

                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }

                otstupVnutri = (minShir - 6 - poiskString.Length - 1) / 2;

                if (choosedButton == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + poiskString + Otstup(minShir - 4 - poiskString.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - 5 - 1) / 2;
                    if (rezhimVvoda)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + " > " + Otstup(minShir - 7) + forBorder);
                    else if (!toFindInit)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + ". . ." + Otstup(minShir - 4 - 5 - otstupVnutri) + forBorder + ' ');
                    else
                    {
                        otstupVnutri = (minShir - 6 - toFind.ToString().Length) / 2;
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + toFind + Otstup(minShir - 4 - toFind.ToString().Length - otstupVnutri) + forBorder + ' ');
                    }
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder) + ' ');
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + poiskString + Otstup(minShir - 4 - poiskString.Length - otstupVnutri) + forBorder);
                    otstupVnutri = (minShir - 6 - 5 - 1) / 2;
                    if (!toFindInit)
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + ". . ." + Otstup(minShir - 4 - 5 - otstupVnutri) + forBorder + ' ');
                    else
                    {
                        otstupVnutri = (minShir - 6 - toFind.ToString().Length) / 2;
                        Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(otstupVnutri) + toFind + Otstup(minShir - 4 - toFind.ToString().Length - otstupVnutri) + forBorder + ' ');
                    }
                    Console.WriteLine(Otstup(otstupForSpisok) + forBorder + Otstup(minShir - 4) + forBorder);
                    Console.WriteLine(Otstup(otstupForSpisok) + Otstup(minShir - 2, forBorder));
                    Console.WriteLine();
                }

                if (choosedButton == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ShowButton(otstupForMenu, buttonShirina, findButton, true);
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    ShowButton(otstupForMenu, buttonShirina, findButton);
                }

                if (choosedButton == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ShowButton(otstupForMenu, buttonShirina, quitButton, true);
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    ShowButton(otstupForMenu, buttonShirina, quitButton);
                }

                for (int i = 0; i < otstupVertical - (otstupVertical / 2) - 1; i++)
                {
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Otstup(otstupForSign) + signature);
                Console.ResetColor();

                if (rezhimVvoda)
                {
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(otstupForMenu, logo.Length + otstupVertical / 2 + 10+4 + 3 + 2 * note.Length);
                    Console.ForegroundColor = ConsoleColor.Green;
                    string s;
                    s = Console.ReadLine();
                    int o; bool b = Int32.TryParse(s, out o);
                    if (!b)
                    {
                        Console.CursorVisible = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        toFind = o;
                        toFindInit = true;
                        rezhimVvoda = false; Console.SetCursorPosition(0, 0); Console.ResetColor(); continue;
                    }
                }

                while (true)
                {
                    if (shirina != Console.WindowWidth || vysota != Console.WindowHeight)
                    {
                        Console.Clear(); break;
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo knopka;
                        knopka = Console.ReadKey(true);

                        if (knopka.Key == ConsoleKey.Enter)
                        {
                            if (choosedButton == 0)
                            {
                                rezhimVvoda = true; break;
                            }
                            else if (choosedButton == 1 && toFindInit)
                            {
                                if (isArraySorted)
                                {
                                    whereFound = BinPoisk(array,toFind,out compCounter);
                                }
                                else
                                {
                                    whereFound = Poisk(array, toFind, out compCounter);
                                }
                                whereFound = whereFound == -1 ? -1 : whereFound + 1;

                                isBegin = false;
                                break;
                            }
                            else if (choosedButton == 2)
                            {
                                return;
                            }
                        }
                        else if (knopka.Key == ConsoleKey.UpArrow)
                        {
                            choosedButton--;
                            choosedButton = choosedButton < 0 ? 3 - 1 : choosedButton;
                            choosedButton %= 3;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.DownArrow)
                        {
                            choosedButton++;
                            choosedButton %= 3;
                            break;
                        }
                        else if (knopka.Key == ConsoleKey.Spacebar)
                        {
                            choosedButton++;
                            choosedButton %= 3;
                            break;
                        }

                    }
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        static void Main(string[] args)
        {
            string[] logo = new String[5];
            logo[0] = "    ___    ____   ____   ___  _  __         __  ______  __";
            logo[1] = "   /   |  / __ \\ / __ \\ /   || |/ /        / / / __  / / /";
            logo[2] = "  / /| | / /_/ // /_/ // /| || /,/ _____  / / / / / / / /";
            logo[3] = " / ___ |/ _, _// _, _// ___ |/ /  /____/ / / / /_/ / / /";
            logo[4] = "/_/  |_/_/ |_|/_/ |_|/_/  |_/_/         /_/ /_____/ /_/";

            string[] menuStrings = new String[6];
            menuStrings[0] = "СОЗДАТЬ МАССИВ";
            menuStrings[1] = "ВЫВЕСТИ МАССИВ НА ЭКРАН";
            menuStrings[2] = "ДОБАВИТЬ / УДАЛИТЬ ЭЛЕМЕНТЫ";
            menuStrings[3] = "ПЕРЕСТАВИТЬ ЭЛЕМЕНТЫ В МАССИВЕ";
            menuStrings[4] = "ПОИСК И СОРТИРОВКА ЭЛЕМЕНТОВ";
            menuStrings[5] = "ВЫЙТИ ИЗ ПРОГРАММЫ";

            string[] errorStrings = new String[2];
            errorStrings[0] = menuStrings[0];
            errorStrings[1] = "ВЫЙТИ В МЕНЮ";

            string[] noArrayNote = new String[2];
            noArrayNote[0] = "ОЙ! ПРЕЖДЕ ЧЕМ РАБОТАТЬ С МАССИВОМ";
            noArrayNote[1] = "НУЖНО СНАЧАЛА ЕГО СОЗДАТЬ!";

            string[] tipNote = new String[2];
            tipNote[0] = "СОВЕТ: ЕСЛИ СНАЧАЛА ОТСОРТИРОВАТЬ МАССИВ";
            tipNote[1] = "ТО ПОИСК В НЁМ ЗАЙМЁТ МЕНЬШЕ ВРЕМЕНИ!";

            string[] poiskSortirovkaStrings = new String[3];
            poiskSortirovkaStrings[0] = "ОТСОРТИРОВАТЬ МАССИВ";
            poiskSortirovkaStrings[1] = "НАЙТИ В МАССИВЕ";
            poiskSortirovkaStrings[2] = errorStrings[1];

            string[] sortirovkaStrings = new String[2];
            sortirovkaStrings[0] = "ОТСОРТИРОВАТЬ МАССИВ";
            sortirovkaStrings[1] = errorStrings[1];

            string[] perestanovkaStrings = new String[2];
            perestanovkaStrings[0] = "ПЕРЕСТАВИТЬ ЭЛЕМЕНТЫ";
            perestanovkaStrings[1] = errorStrings[1];

            string[] perestanovkaNote = new String[3];
            perestanovkaNote[0] = "ПРИ ПЕРЕСТАНОВКЕ ВСЕ ПОЛОЖИТЕЛЬНЫЕ";
            perestanovkaNote[1] = "ЭЛЕМЕНТЫ БУДУТ ПЕРЕМЕЩЕНЫ В НАЧАЛО,";
            perestanovkaNote[2] = "А ВСЕ ОТРИЦАТЕЛЬНЫЕ - В КОНЕЦ";

            string[] addDeleteStrings = new String[3];
            addDeleteStrings[0] = "ДОБАВИТЬ ЭЛЕМЕНТЫ В МАССИВ";
            addDeleteStrings[1] = "УДАЛИТЬ НЕЧЁТНЫЕ ЭЛЕМЕНТЫ";
            addDeleteStrings[2] = errorStrings[1];

            string[] deleteStrings = new String[2];
            deleteStrings[0] = "УДАЛИТЬ ВСЕ НЕЧЁТНЫЕ ЭЛЕМЕНТЫ";
            deleteStrings[1] = errorStrings[1];

            string[] addNote = new String[5];
            addNote[0] = "+ ДОБАВЛЯЕТ НОВЫЙ ЭЛЕМЕНТ ЗА ВЫБРАННЫМ";
            addNote[1] = "Х УДАЛЯЕТ ВЫБРАННЫЙ ЭЛЕМЕНТ";
            addNote[2] = "ВВЕДИТЕ ПОЗИЦИЮ, КУДА В МАССИВ НУЖНО";
            addNote[3] = "БУДЕТ ДОБАВИТЬ НОВЫЕ ЭЛЕМЕНТЫ";
            addNote[4] = "ЧТОБЫ НАЧАТЬ / ЗАКОНЧИТЬ ВВОД НАЖМИТЕ ENTER";

            string[] addNewNote = new String[3];
            addNewNote[0] = "+ ДОБАВЛЯЕТ НОВЫЙ ЭЛЕМЕНТ ЗА ВЫБРАННЫМ";
            addNewNote[1] = "Х УДАЛЯЕТ ВЫБРАННЫЙ ЭЛЕМЕНТ";
            addNewNote[2] = "ЧТОБЫ НАЧАТЬ / ЗАКОНЧИТЬ ВВОД НАЖМИТЕ ENTER";

            string[] deleteNote = new String[2];
            deleteNote[0] = "ЭТО ДЕЙСТВИЕ УДАЛИТ ВСЕ НЕЧЁТНЫЕ";
            deleteNote[1] = "ЭЛЕМЕНТЫ В МАССИВЕ";

            string[] sortirovkaNote = new String[2];
            sortirovkaNote[0] = "ЭТО ДЕЙСТВИЕ ОТСОРТИРУЕТ МАССИВ";
            sortirovkaNote[1] = "В ПОРЯДКЕ ВОЗРАСТАНИЯ";

            string[] showNote = new String[2];
            showNote[0] = "ДЛЯ НАВИГАЦИИ ПО МАССИВУ ";
            showNote[1] = "ИСПОЛЬЗУЙТЕ СТРЕЛКИ";

            string[] sozdanieStrings = new String[3];
            sozdanieStrings[0] = "СГЕНЕРИРОВАТЬ МАССИВ";
            sozdanieStrings[1] = "ЗАДАТЬ МАССИВ ВРУЧНУЮ";
            sozdanieStrings[2] = errorStrings[1];

            string[] sozdanieNote = new String[3];
            sozdanieNote[0] = "ЧТОБЫ СГЕНЕРИРОВАТЬ МАССИВ ИЗ СЛУЧАЙНЫХ";
            sozdanieNote[1] = "ЧИСЕЛ, ВЫБЕРИТЕ ПЕРВЫЙ ПУНКТ МЕНЮ";
            sozdanieNote[2] = "ЧТОБЫ ЗАДАТЬ МАССИВ ВРУЧНУЮ, ВЫБЕРИТЕ ВТОРОЙ";

            string[] binPoiskNote = new String[2];
            binPoiskNote[0] = "ТАК КАК МАССИВ ОТСОРТИРОВАН";
            binPoiskNote[1] = "БУДЕТ ИСПОЛЬЗОВАТЬСЯ БИНАРНЫЙ ПОИСК";

            string[] poiskNote = new String[2];
            poiskNote[0] = "ТАК КАК МАССИВ НЕ ОТСОРТИРОВАН";
            poiskNote[1] = "БУДЕТ ИСПОЛЬЗОВАТЬСЯ ОБЫЧНЫЙ ПОИСК";

            string[] voidNotes = { "" };

            string signature = "ПОТОРОЧИН ВИТАЛИЙ, ВШЭ - ПЕРМЬ, 2022";

            bool isArrSorted;
            isArrSorted = false;

            int[] array = new int[0];

            Console.Title="ARRAY-101";

            while (true)
            {
                int yourMove = ShowMenu(logo, menuStrings, signature,voidNotes);
                if (array.Length == 0 && yourMove != 1 && yourMove != 0 && yourMove != menuStrings.Length - 1)
                {
                    yourMove = ShowMenu(logo, errorStrings, signature, noArrayNote);
                    if (yourMove == 0)
                    {
                        int u = ShowMenu(logo, sozdanieStrings, signature, sozdanieNote);
                        if (u == 0)
                        {
                            ShowArrayInit(logo, signature, out array);
                        }
                        else if (u == 1)
                        {
                            ShowAdd(logo, signature, ref array, addNewNote, true);
                        }
                        isArrSorted = SortCheck(array);
                    }
                }
                else if (yourMove == 1 || (yourMove > 1 && yourMove < menuStrings.Length - 1))
                {
                    int y;
                    switch (yourMove)
                    {
                        case 1: ShowArray(logo, signature, array, showNote); break; // печать массива
                        case 2: // удаление / добавление
                            y = ShowMenu(logo, addDeleteStrings, signature, voidNotes);
                            if (y == 0) // добавление
                            {
                                int a = array.Length;
                                ShowAdd(logo, signature, ref array, addNote);
                                isArrSorted = a==array.Length ? isArrSorted : false; break;
                            }
                            else if (y == 1) // удаление
                            {
                                if (ShowMenu(logo, deleteStrings, signature, deleteNote) == 0)
                                {
                                    array = UdalitNechyotnie(array);
                                }
                            }
                            isArrSorted = SortCheck(array);
                            break;
                        case 3: // перестановка
                            if (ShowMenu(logo, perestanovkaStrings, signature, perestanovkaNote) == 0)
                            {
                                array = Perestanovka(array);
                                isArrSorted = SortCheck(array);
                            }
                            break;
                        case 4: // поиск и сортировка
                            y = ShowMenu(logo, poiskSortirovkaStrings, signature, tipNote);
                            if (y == 0) // сортировка
                            {
                                if (ShowMenu(logo, sortirovkaStrings, signature, sortirovkaNote) == 0)
                                {
                                    array = Sortirovka(array, 0, array.Length - 1);
                                    isArrSorted = true;
                                }
                            } else if (y == 1) { // поиск
                                if (isArrSorted)
                                {
                                    ShowPoisk(logo, signature, array, binPoiskNote, isArrSorted);
                                }
                                else
                                {
                                    ShowPoisk(logo, signature, array, poiskNote, isArrSorted);
                                }
                            }
                            break;
                    }
                }
                else if (yourMove == 0)
                {
                    int u = ShowMenu(logo, sozdanieStrings, signature, sozdanieNote);
                    if (u == 0)
                    {
                        ShowArrayInit(logo, signature, out array);
                    }
                    else if (u == 1)
                    {
                        ShowAdd(logo, signature, ref array, addNewNote, true);
                    }
                    isArrSorted = SortCheck(array);
                }
                else
                {
                    Console.BufferHeight += 3;
                    Console.WindowHeight += 3;
                    return;
                }
            }
        }
    }
}