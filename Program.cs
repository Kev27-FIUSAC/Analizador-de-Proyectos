using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practica1_201403793
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("                         Bienvenido, Practica 1 201403793");

            Menus_201403793 nuevo = new Menus_201403793();
            nuevo.comienzo();
            Console.WriteLine("                     Presione Enter para salir");
            Console.ReadLine();

        }
    }
}
