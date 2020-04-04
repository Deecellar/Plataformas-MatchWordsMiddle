using System;
using System.Collections.Generic;
using System.Linq;

namespace Plataformas
{
    class Program
    {
        static void Main(string[] args)
        {
            double porcentajePresicion = 1;
            Console.WriteLine("Ingrese la cadena de palabras:");
            string cadena = Console.ReadLine();
            Console.WriteLine("Ingrese la palabra a buscar:");
            string palabra = Console.ReadLine().Split(" ")[0];
            Filter filter = new Filter(palabra);
            filter.Find(cadena);
            Console.WriteLine("Modo preciso(Y/N):");
            bool precision = Console.ReadKey().Key == ConsoleKey.Y;
            Console.WriteLine();
            if (!precision)
            {
                Console.WriteLine("Ingrese el porcentaje de presicion del 0 al 100 (por defecto 80 I.E: 0.1, 10, 40):");
                bool parsed = double.TryParse(Console.ReadLine(), out porcentajePresicion);
                if (!parsed)
                {
                    porcentajePresicion = 80 * 0.01;
                }
                else {
                    porcentajePresicion = porcentajePresicion * 0.01;
                }
            }

            IEnumerable<WordSim> matches;
            if (precision)
            {
                matches = filter.Matchs.Where(x => x.IsBetweenWords == true && x.PercentageOfSimilitude >= 1);

            }
            else
            {
                matches = filter.Matchs.Where(x => x.IsBetweenWords == true && x.PercentageOfSimilitude >= porcentajePresicion * 0.3);
            }
            bool found = false;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (matches.Where(x => x.IndexOfWord == i).Count() > 0)
                {
                    found = true;
                }
                if (cadena[i] == ' ')
                {
                    found = false;
                }
                if (found)
                {
                    var def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(cadena[i]);
                    Console.ForegroundColor = def;
                }
                else
                {
                    Console.Write(cadena[i]);
                }
            }
            Console.Write("\n");
        }
    }
}
