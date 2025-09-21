using Programm1.Database;
using Programm1.Util;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Programm1
{
    internal class Armatura
    {
        /// <summary>
        /// Класс Арматурная позиция
        /// </summary>
        private string marka; // марка арматуры или гнутой позиции например 10, 12г, П10-1
        private byte diametr; //диаметр арматуры
        private string klass; // Класс арматуры
        private string standart; // Стандарт
        private float massa1p; // Масса 1 ед (п.м. или шт)
        private static readonly byte[] diametrlist = Databases.DiametrList(); // Список возможных диаметров
        private static readonly float[] dmassa = Databases.Dmassa(); // Список масс
        private static readonly Dictionary<string, string[]> vedDetList = Databases.VedDetalei(); // Список ведомостей деталей

        private bool isMetrP = true; // true если масса на п.м.; false если на 1 штуку
        private uint length; // длина линейной позиции
        private ushort count; // Количество шт.


        public Armatura(string marka, uint length, ushort count, string klass, string standart)
        {
            this.Marka = marka;
            this.Diametr = 10;// Фиктивное присвоение
            this.Length = length;
            this.Count = count;
            this.Klass = klass;
            this.Standart = standart;
            this.IsMetrP = true;// Фиктивное присвоение
            this.Massa1p = 0;// Фиктивное присвоение для запуска set Massa1p

        }

        public Armatura(string marka, uint length, ushort count)

        {
            this.Marka = marka;
            this.Diametr = 0;// Фиктивное присвоение
            this.Klass = "";// Фиктивное присвоение
            this.Standart = "";// Фиктивное присвоение
            this.Length = length;
            this.Count = count;
            this.IsMetrP = true;// Фиктивное присвоение
            this.Massa1p = 0;// Фиктивное присвоение для запуска set Massa1p
        }

        public Armatura(string marka, ushort count)

        {
            this.Marka = marka;
            this.Diametr = 0;// Фиктивное присвоение
            this.Klass = "";// Фиктивное присвоение
            this.Standart = "";// Фиктивное присвоение
            this.Count = count;
            this.Length = length;
            this.IsMetrP = true;// Фиктивное присвоение
            this.Massa1p = 0;// Фиктивное присвоение для запуска set Massa1p
        }


        public string Marka
        {
            get { return this.marka; }
            private set
            {
                this.marka = value;
            }
        }

        public byte Diametr
        {
            get { return this.diametr; }
            private set
            {
                if (vedDetList.TryGetValue(this.marka, out string[] value1))// Если марка есть в ведомости деталей
                {
                    this.diametr = Convert.ToByte(value1[0]);
                }
                else
                {
                    if (Utils.IsAllDigits(this.marka) && diametrlist.Contains(Convert.ToByte(this.marka)))
                    {
                        this.diametr = Convert.ToByte(this.marka);
                    }
                    else
                    {
                        if (Char.ToLower(this.marka[this.marka.Length - 1]) == 'г' || Char.ToLower(this.marka[this.marka.Length - 1]) == 'в') // Если марка с индексом "г" или "в" то это гладкая арматура класса А240 или Вр1
                        {

                            if (Utils.IsAllDigits(this.marka.Substring(0, this.marka.Length - 1)) && diametrlist.Contains(Convert.ToByte(this.marka.Substring(0, this.marka.Length - 1))))
                            {
                                this.diametr = Convert.ToByte(this.marka.Substring(0, this.marka.Length - 1));

                            }
                        }
                        else
                        {
                            //несуществующий диаметр
                            throw new ArgumentException("Несуществующий диаметр.");

                        }
                    }
                }
            }
        }

        public string Standart
        {
            get { return this.standart; }
            private set
            {
                if (vedDetList.TryGetValue(this.marka, out string[] value1))// Если марка есть в ведомости деталей
                {
                    this.standart = value1[3];
                }
                else
                {
                    if (value != null && value != "")
                    {
                        this.standart = value;
                    }
                    else
                    {

                        if (Char.ToLower(this.marka[this.marka.Length - 1]) == 'г') // Если марка с индексом "г"  то это гладкая арматура класса А240
                        {
                            this.standart = "ГОСТ 34028-2016";

                        }
                        else if (Char.ToLower(this.marka[this.marka.Length - 1]) == 'в') // Если марка с индексом "в"  то это гладкая арматура класса Вр1
                        {
                            this.standart = "ГОСТ 6727-80";
                        }
                        else if (this.diametr == Convert.ToByte(this.marka))// Если марка соответствует диаметру
                        {
                            this.standart = "ГОСТ 34028-2016";
                        }
                        else
                        {
                            //несуществующий стандарт
                            throw new ArgumentException("Несуществующий стандарт.");

                        }
                    }

                }
            }
        }

        public string Klass
        {
            get { return this.klass; }
            private set
            {
                if (vedDetList.TryGetValue(this.marka, out string[] value1))// Если марка есть в ведомости деталей
                {
                    this.klass = value1[2];
                }
                else
                {
                    if (value != null && value != "")
                    {
                        this.klass = value;
                    }
                    else
                    {

                        if (Char.ToLower(this.marka[this.marka.Length - 1]) == 'г') // Если марка с индексом "г"  то это гладкая арматура класса А240
                        {
                            this.klass = "А240";

                        }
                        else if (Char.ToLower(this.marka[this.marka.Length - 1]) == 'в') // Если марка с индексом "в"  то это гладкая арматура класса Вр1
                        {
                            this.klass = "Вр1";
                        }
                        else if (this.diametr == Convert.ToByte(this.marka))// Если марка соответствует диаметру
                        {

                            this.klass = "А500C";
                        }
                        else
                        {
                            //несуществующий класс
                            throw new ArgumentException("Несуществующий класс.");

                        }
                    }
                }

            }
        }

        public float Massa1p
        {
            get { return this.massa1p; }
            private set
            {
                if (this.IsMetrP)
                {
                    if (diametrlist.Contains(this.Diametr))
                    {
                        this.massa1p = dmassa[Array.IndexOf(diametrlist, this.Diametr)];
                    }
                }
                else
                {
                    if (diametrlist.Contains(this.Diametr))
                    {
                        this.massa1p = dmassa[Array.IndexOf(diametrlist, this.Diametr)] * this.Length / 1000;
                    }

                }
            }
        }

        public bool IsMetrP
        {
            get { return this.isMetrP; }
            private set
            {
                if (vedDetList.ContainsKey(this.marka))// Если марка есть в ведомости деталей
                    this.isMetrP = false;// то поштучный подсчет
                else
                    this.isMetrP = true;
            }

        }

        public uint Length
        {
            get { return this.length; }
            set
            {
                if (vedDetList.TryGetValue(this.marka, out string[] value1))// Если марка есть в ведомости деталей
                {
                    this.length = Convert.ToUInt32(value1[1]);
                }
                else
                {
                    if (value != 0)
                    {
                        this.length = value;
                    }
                    else
                    {
                        throw new ArgumentException("Несуществующая или нулевая длинна");
                    }
                }


            }

        }

        public ushort Count
        {
            get { return this.count; }
            set
            {
                if (vedDetList.ContainsKey(this.marka))// Если марка есть в ведомости деталей
                {
                    this.count = value;
                }
                else
                {
                    if (value != 0 && this.Length != 0)
                    {
                        this.Length = value * this.Length; // Переопределение длины
                        this.count = 1;
                    }
                    else
                    {
                        throw new ArgumentException("Нулевое колличество или длина");
                    }
                }


            }

        }



        public override bool Equals(object obj)// Условия равенства
        {
            if (!(obj is Armatura)) return false;
            Armatura other = (Armatura)obj;
            if (this.IsMetrP)
                return (this.IsMetrP == other.IsMetrP) && (this.Marka == other.Marka) && (this.Diametr == other.Diametr) && (this.Klass == other.Klass);
            else
                return (this.IsMetrP == other.IsMetrP) && (this.Marka == other.Marka) && (this.Length == other.Length) && (this.Diametr == other.Diametr) && (this.Klass == other.Klass);
        }
        public static bool operator ==(Armatura p1, Armatura p2)
        {
            if (p1 is null && p2 is null) return true;
            if (p1 is null || p2 is null) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Armatura p1, Armatura p2)
        {
            if (p1 is null && p2 is null) return false;
            if (p1 is null || p2 is null) return true;
            return !p1.Equals(p2);
        }







    }
}
