using System.Collections.Generic;

namespace Programm1.Database
{
    public static class Databases
    {
        public static byte[] DiametrList()
        {
            byte[] diametrlist = { 4, 5, 6, 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32, 36, 40 };// Список возможных диаметров
            return diametrlist;
        }

        public static float[] Dmassa()
        {
            float[] dmassa = { 0.099f, 0.154f, 0.222f, 0.395f, 0.617f, 0.888f, 1.208f, 1.578f, 1.998f, 2.466f, 2.984f, 3.853f, 4.834f, 6.313f, 7.990f, 9.865f }; // Список масс
            return dmassa;
        }

        public static Dictionary<string, string[]> VedDetalei() 
        {   /// Тестовая версия
            Dictionary<string, string[]> vedDetList = new Dictionary<string, string[]>()
            {
            {"П10-1", new string[] { "10", "2400", "A500C", "ГОСТ 34028-2016"} },
            {"П12г-1",new string[]{ "12", "1200", "A240", "ГОСТ 34028-2016" } },
            { "П16-1", new string[]{ "16","9800", "A500C", "ГОСТ 34028-2016" } },
            { "Р5-1", new string[] { "5", "750", "Вр1", "ГОСТ 6727-80" } }
            };
            return vedDetList;
        }

    }
}
