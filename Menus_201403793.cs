using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201403793
{
    class Menus_201403793
    {

      private  string ubicacion1 = null;
       private ArrayList Tokens;
       private ArrayList Lexemas;
       private ArrayList Caracter;
       private  ArrayList Descripcion;
       private ArrayList NumFilas;
       private ArrayList NumColumnas;
       private ArrayList Ids;
       private  LecturaAnalizador_201403793 analizador = new LecturaAnalizador_201403793();

        public void comienzo()
        {

            int seleccion = 1;
            string temp;

            while (seleccion <= 3)
            {

                Console.WriteLine("");
                Console.WriteLine("                 1. Leer archivo Script");
                Console.WriteLine("                 2. Generar archivos de salida");
                Console.WriteLine("                 3. Descripcion");
                Console.WriteLine("                 4. Salir");
                Console.WriteLine("");
                Console.WriteLine("Escriba el numero que desea realizar");

                temp = Console.ReadLine();
                seleccion = int.Parse(temp);

                switch (seleccion)
                {

                    case 1:
                        leerScrip();
                        break;

                    case 2:
                        Console.WriteLine("");
                        mostrarTokens();
                        break;

                    case 3:
                        Console.WriteLine("");
                        descripcion();
                        break;

                    case 4:
                        Console.WriteLine("                     Gracias por usar el software");
                        seleccion = 5;
                        break;


                }


            }
        }

        //Primer paso del programa
        private void leerScrip()
        {

            Console.WriteLine("Por favor escriba la ubicacion que se encuentra el archivo: ");
            ubicacion1 = Console.ReadLine(); //Captura la ubicacion escrita por el usuario

            analizador.setUbicacion(ubicacion1);
            Console.WriteLine("");
            Console.WriteLine("Comenzando proceso");
            Console.WriteLine("");

            analizador.imprimir();
            Console.WriteLine("");
            analizador.comenzar();
            Console.WriteLine("");

            //Luego que se haya realizado el analizador y procesos, se obtiene los listados
            Lexemas = analizador.getLexemas();
            Tokens = analizador.getTokens();
            Caracter = analizador.getCErrores();
            Descripcion = analizador.getDescripcion();
            NumFilas = analizador.getNumFilas();
            NumColumnas = analizador.getNumColumnas();
            Ids = analizador.getIDs();

            

        }

        private void mostrarTokens()
        {

            //Cuando el analizador lexico fue un exito !!!!
            if (Tokens.Count == 0)
            {
                Console.WriteLine("No se puede saltar de instruccion, por favor elija la primera, No hay ubicacion introduccida");
            }

                //Cuando el analizador lexico detecto errores lexicos en el archivo
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Escriba la ubicacion que desea guardar los archivos a generar");

                string guardar = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("Se han obtenido " + Tokens.Count + " Tokens y Se ha detectado " + Descripcion.Count + " Errores");
                GeneradorArchivo_201403793 crearHTML = new GeneradorArchivo_201403793(guardar);
                crearHTML.generadorTokens(Lexemas, Tokens, Ids);
                crearHTML.generadorError(Caracter, Descripcion, NumFilas, NumColumnas);
                Console.WriteLine("");
                Lexemas.Clear();
                Tokens.Clear();
                Caracter = null;
                Descripcion.Clear();
                NumFilas.Clear();
                NumColumnas.Clear(); 
            }

        }

        //Ayuda en pantalla
        private void descripcion()
        {
            Console.Write("1 Leer Archivo Script: Primer paso, escriba la ubicacion del archivo que desea analizar");
            Console.WriteLine("e interpretar, debe tomar en cuenta que la extencion del archivo debe ser *.lfp, de lo contrario el programa no funcionara correctamente");
            Console.WriteLine("Despues el programa comenzara con su analisis lexico y si esta correcto el archivo empezara la interpretacion.");
            Console.WriteLine("");
            Console.WriteLine("2 Generar archivos de salida: Segundo paso, luego del analisis e interpretacion, puede autogenerar los archivos tokens.html y erroes.html, podra visualizar los tokens obtenidos durante el analisis y los erroes que se detectaron.");
            Console.WriteLine("");
            Console.WriteLine("3 Descripcion: Detalles del programa");
            Console.WriteLine("");
            Console.WriteLine("4 Salir: Finalizar el programa");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
 
        }

    }
}
