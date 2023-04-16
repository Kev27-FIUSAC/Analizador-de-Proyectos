using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Practica1_201403793
{
    class Metodos_201403793
    {


        //Clase Metodos_201403793 Contiene todos las acciones del lenguaje

       private ArrayList ListaComandos;

        public Metodos_201403793(ArrayList Comandos)
        {
            ListaComandos = Comandos;
        }

        //Comienza aca la verificacion del tipo correspondiente, especial son dos diferentes
        public void EjecutarMetodos()
        {

            switch (ListaComandos.Count)
            {

                case 3:
                    if (ListaComandos[0].ToString() == "especial")
                    {
                        MetodosEspeciales2(ListaComandos[2].ToString(), ListaComandos[1].ToString());
                    }
                    break;

                case 4:
                    if (ListaComandos[0].ToString() == "especial")
                    {
                        MetodosEspeciales1(ListaComandos[1].ToString(), ListaComandos[2].ToString(), ListaComandos[3].ToString());
                    }
                    break;

                case 5:
                    switch (ListaComandos[0].ToString())
                    {
                        case "carpeta":
                            MetodosCarpetas(ListaComandos[1].ToString(), ListaComandos[4].ToString(), ListaComandos[2].ToString());
                            break;

                        case "archivo":
                            MetodosArchivos(ListaComandos[1].ToString(), ListaComandos[2].ToString(), ListaComandos[3].ToString(), ListaComandos[4].ToString());
                            break;

                        default:
                            Console.WriteLine("Comando omitido");
                            break;
                    }
                    break;
            }

        }

        private void MetodosCarpetas(string aAccion, string aRuta, string aNombre)
        {
            switch (aAccion)
            {
                case "crear":
                    MetodoCrearCarpeta(aRuta, aNombre);
                    break;

                case "eliminar":
                    MetodoEliminarCarpeta(aRuta, aNombre);
                    break;
            }
        }

        private void MetodoCrearCarpeta(string aRuta, string aNombre)
        {
            string nueva = Path.Combine(aRuta, aNombre);
            Directory.CreateDirectory(nueva);
        }

        private void MetodoEliminarCarpeta(string bRuta, string bNombre)
        {

            string borrar = Path.Combine(bRuta, bNombre);

            if (Directory.Exists(borrar))
            {

                Directory.Delete(borrar, true);

            }
            else
            {
                Console.WriteLine(borrar + ", No Existe la carpeta");
            }
      
        }

        private void MetodosArchivos(string aAccion, string aNombre, string aTexto, string aRuta)
        {

            switch (aAccion)
            {
                case "crear":
                    MetodoCrearArchivo(aNombre,aTexto,aRuta);
                    break;

                case "modificar":
                    MetodoModificarArchivo(aNombre, aTexto, aRuta);
                    break;

                case "eliminar":
                    MetodoEliminarArchivo(aNombre, aRuta);
                    break;

                default:
                    Console.WriteLine("Omitido");
                    break;
                    
            }

        }

        private void MetodoCrearArchivo(string bNombre, string bTexto, string bRuta)
        {
            if (Directory.Exists(bRuta))
            {
            
                GeneradorArchivo_201403793 nuevo = new GeneradorArchivo_201403793(bRuta);
                nuevo.setTexto(bTexto);
                nuevo.generarArchivo(bNombre);

            }
            else
            {
                Console.WriteLine("No existe la ruta: " + bRuta + ", Error");
            }
           
        }

        private void MetodoModificarArchivo(string cNombre, string cTexto, string cRuta)
        {
            string primero = Path.Combine(cRuta, cNombre);
            primero += ".txt";

            if (File.Exists(primero))
            {

            File.Delete(primero);

            GeneradorArchivo_201403793 modificado = new GeneradorArchivo_201403793(cRuta);
            modificado.setTexto(cTexto);
            modificado.generarArchivo(cNombre);

            }
            else
            {
                Console.WriteLine("No existe el archivo " + cNombre + ".txt" + " En la ruta especificada: " + cRuta);
            }

            
        }

        private void MetodoEliminarArchivo(string dNombre, string dRuta)
        {
            string archivo = Path.Combine(dRuta, dNombre);
            archivo = archivo + ".txt";

            if (File.Exists(archivo))
            {

                File.Delete(archivo);

            }
            else
            {

                Console.WriteLine("No existe el archivo"+dNombre+".txt"+ " En la ruta especificada: "+ dRuta);

            }

            
        }

        private void MetodosEspeciales1(string aAccion, string aNombre, string aRuta)
        {

            switch (aAccion)
            {
                case "obtener-fecha":
                    MetodoFechaEspecial(aNombre, aRuta);
                    break;

                case "obtener-hora":
                    MetodoHoraEspecial(aNombre, aRuta);
                    break;
            }

        }

        private void MetodoFechaEspecial(string cNombre, string cRuta)
        {

            GeneradorArchivo_201403793 generar = new GeneradorArchivo_201403793(cRuta);
            generar.generarFecha(cNombre);

        }

        private void MetodoHoraEspecial(string dNombre, string dRuta)
        {
            GeneradorArchivo_201403793 generar = new GeneradorArchivo_201403793(dRuta);
            generar.generarHora(dNombre);
        }

        private void MetodosEspeciales2(string bNombre, string aAccion)
        {
            Console.WriteLine("Nuevo Shell");
        }

        private void MetodoNombreShell(string aNombre)
        {

        }

    }
}
