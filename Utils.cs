using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programm1.Util
{
    public static class Utils
    {
        public static bool IsAllDigits(string snum)
        //
        ///Функция проверяет является ли строка числом
        //независимо от того целое, отрицательное или
        //дробное. В качестве разделителя принимается
        /// и '.' и ','
        {
            snum = snum.Trim();// Избавляемся от пробелов
            bool negativ = false;
            bool integer = true;
            if (snum.Length == 0) return false;// Если строка пустая возвращаем false

            if (snum[0] == '-')// Если число отрицательное
            {
                snum = snum.Substring(1);
                negativ = true;
            }

            if (snum[0] == '.' || snum[0] == ',')// Если число дробное
            {
                snum = snum.Substring(1);
                integer = false;
            }
            // Проверяем оставшиеся символы
            foreach (char c in snum)
            {
                if (c == '.' || c == ',')
                    if (!integer)
                    {
                        return false;// Если точка или запятая уже встречались
                    }
                    else
                    {
                        integer = false;
                        continue;
                    }
                if (!Char.IsDigit(c))
                {
                    return false;
                }


            }
            return true;

        }
    }
}
