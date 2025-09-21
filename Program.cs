using System;
using System.Collections.Generic;

namespace Programm1
{
    internal class Program
    {
        static void Main()
        {


            Dictionary<string, Armatura> armaturaList = new Dictionary<string, Armatura>();
            string[] marklist = {"10в", "12в", "40", "П10-1", "10г", "П12г-1", "10", "hsdfsd"};
            uint[] lenlist = { 1250, 7500, 4500, 0, 1450, 3000, 1000 ,1300};
            ushort[] countlist = { 5, 40, 35, 12, 67, 80 , 0,5};
            for (int i = 0; i < marklist.Length; i++)
            { try
                {
                    armaturaList.Add(marklist[i], new Armatura(marklist[i], lenlist[i],countlist[i]));
                }
                catch 
                {   // Переход к следующей позиции в случае некорректных исходных данных. Некорректная позиция не добавятся
                    continue;
                }
            }
            
            foreach (KeyValuePair<string, Armatura> pair in armaturaList)
                Console.WriteLine($"Марка арматуры : {pair.Value.Marka} Диаметр арматуры : {pair.Value.Diametr} Класс арматуры : {pair.Value.Klass} Стандарт : {pair.Value.Standart} Длина : {pair.Value.Length} Масса ед : {pair.Value.Massa1p} IsMetr : {pair.Value.IsMetrP} Count : {pair.Value.Count}");



        }





    }
}

