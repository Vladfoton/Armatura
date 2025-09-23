using Programm1.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Programm1
{
    internal class Program
    {
        static void Main()
        {


            Dictionary<string, Armatura> armaturaList = new Dictionary<string, Armatura>();
            string[] marklist = { "10в", "12в", "40", "П10-1", "10г", "П12г-1", "10", "hsdfsd" };
            uint[] lenlist = { 1250, 7500, 4500, 0, 1450, 3000, 1000, 1300 };
            ushort[] countlist = { 5, 40, 35, 12, 67, 80, 0, 5 };
            for (int i = 0; i < marklist.Length; i++)
            {
                try
                {
                    armaturaList.Add(marklist[i], new Armatura(marklist[i], lenlist[i], countlist[i]));
                }
                catch
                {   // Переход к следующей позиции в случае некорректных исходных данных. Некорректная позиция не добавятся
                    continue;
                }
            }

            foreach (KeyValuePair<string, Armatura> pair in armaturaList)
                Console.WriteLine($"Марка арматуры : {pair.Value.Marka} Диаметр арматуры : {pair.Value.Diametr} Класс арматуры : {pair.Value.Klass} Стандарт : {pair.Value.Standart} Длина : {pair.Value.Length} Масса ед : {pair.Value.Massa1p} IsMetr : {pair.Value.IsMetrP} Count : {pair.Value.Count}");

            Armatura arm1 = new Armatura("П10-1", 1200, 10);
            Armatura arm2 = new Armatura("П10-1", 1500, 20);
            Armatura arm3 = arm1 + arm2;
            Console.WriteLine($"Марка арматуры : {arm3.Marka} Диаметр арматуры : {arm3.Diametr} Класс арматуры : {arm3.Klass} Стандарт : {arm3.Standart} Длина : {arm3.Length} Масса ед : {arm3.Massa1p} IsMetr : {arm3.IsMetrP} Count : {arm3.Count}");



            string stroka = "'':('ГОСТ 34028-2016', 'А500C');'г':('ГОСТ 34028-2016', 'А240');'в':('ГОСТ 6727-80', 'ВрI)";
            string[] armstr= stroka.Split(';');
            Dictionary<string, string[]> armStandart = new Dictionary<string, string[]>(); ;
            foreach (string s in armstr)
            {
                string[] armstr1 = s.Split(':');
                string key = armstr1[0];
                string[] value = armstr1[1].Split(',');
                
                string[] value1={ value[0].Trim('(', ' ', '\''), value[1].Trim(')',' ','\'') };
                key = key.Trim('\'');

                armStandart.Add(key,  value1 );
            }

            foreach( KeyValuePair<string, string[]> valuePair in armStandart)
            {
                Console.WriteLine($"key: {valuePair.Key}  value : {String.Join(" ", valuePair.Value)}  ");


            }
            Console.WriteLine(armStandart[""] + "  "+ String.Join(" ", armStandart[""]));


    }





    }
}

