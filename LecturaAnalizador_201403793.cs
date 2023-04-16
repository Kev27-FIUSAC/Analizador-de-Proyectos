using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Practica1_201403793
{
    class LecturaAnalizador_201403793
    {
        //Atributos de la clase
        private string ubicacion;
        private StreamReader archivo;
        private ArrayList lexemas = new ArrayList();
        private ArrayList tokens = new ArrayList();
        private ArrayList ErrorCaracter = new ArrayList();
        private ArrayList Descripcion = new ArrayList();
        private ArrayList FilaListado = new ArrayList();
        private ArrayList ColumnaListado = new ArrayList();
        private ArrayList misComandos = new ArrayList();
        private ArrayList IDtoken = new ArrayList();
        private Comparacion_201403793 Mio = new Comparacion_201403793();



        //Primer paso es establecer la ubicacion del archivo a leer
        public void setUbicacion(string ub)
        {

            ubicacion = ub;

        }

        //Imprime el archivo para que el usuario lo visualize 
        public void imprimir()
        {

            StreamReader lfpA = new StreamReader(ubicacion);
            string linea;

            while ((linea = lfpA.ReadLine()) != null)
            {
                Console.WriteLine(linea);
            }

            lfpA.Close();

        }

        //Segundo paso: Contar las lineas que contiene el archivo
        public void comenzar()
        {
           
            archivo = new StreamReader(ubicacion);
            string fila;
            int filanum = 0;

            while((fila = archivo.ReadLine()) != null){

                filanum++;
                analizadorLexico(fila, filanum);            

            }

            archivo.Close();

        }

        //Tercer paso: leer caracter por caracter del archivo, Analizador Lexico -----------------------------------------------------------------------------------------------------
        public void analizadorLexico(string linea, int actual)
        {

            linea = linea + "#";
            int interacion = 0;
            int estado = 0;
            string palabra = null;
            string temp;
            char caracter;
            string cmDoble = "\"";
            string fila = actual.ToString();
            string atributo = null;
            string cComando = null;
            string cadenaRuta = null;
            string cadena = null;
            Boolean esRuta = false;
            int numCol = 0;

            while (interacion < linea.Length)
            {

                caracter = nextLetra(linea, interacion);
                temp = caracter.ToString();

                switch (estado)
                {
                    case 0:
                        if (temp == "\t")
                        {
                            estado = 0;
                            interacion += 1;
                            numCol += 1;

                        }
                        else if (temp == "\n")
                        {
                            estado = 0;
                            interacion += 1;
                            numCol += 1;
                        }
                        else if (caracter == '<')
                        {
                            estado = 1;
                            lexemas.Add(temp);
                            tokens.Add("SignoMenor");
                            numCol += 1;
                            interacion += 1;
                            IDtoken.Add("S1");
                            

                        }
                        else
                        {
                            FilaListado.Add(fila);
                            ColumnaListado.Add(numCol);
                            ErrorCaracter.Add(temp);
                            Descripcion.Add("Caracter Invalido");
                            interacion = linea.Length;

                        }

                        break;

                    case 1:
                        if(Mio.esLetra(caracter)){

                            estado = 2;
                            palabra = palabra + caracter;
                            numCol += 1;
                            interacion += 1;
                        }
                        else if (caracter == '/')
                        {
                            estado = 2;
                            lexemas.Add(temp);
                            tokens.Add("SimboloCierreEtiqueta");
                            numCol += 1;
                            cComando = cComando + caracter;
                            interacion += 1;
                            IDtoken.Add("S3");

                        }
                        else
                        {

                            FilaListado.Add(fila);
                            ColumnaListado.Add(numCol);
                            ErrorCaracter.Add(temp);
                            Descripcion.Add("Desconocido");
                            interacion = linea.Length;

                        }
                        break;

                    case 2:
                        if (Mio.esLetra(caracter))
                        {
                            estado = 2;
                            palabra = palabra + caracter;
                            numCol += 1;
                            interacion += 1;
                        }
                        else if (caracter == '>')
                        {
                            estado = 3;

                            switch (palabra)
                            {
                                case "comando":
                                    cComando = cComando + palabra;
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva"+palabra);
                                    IDtoken.Add("R2");
                                    palabra = null;
                                    break;

                               case "lfscript":
                                     lexemas.Add(palabra);
                                    tokens.Add("Reserva"+palabra);
                                    palabra = null;
                                    IDtoken.Add("R1");
                                    break;

                               case "tipo":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva"+palabra);
                                    IDtoken.Add("R3");
                                    palabra = null;
                                    break;

                               case "accion":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva"+palabra);
                                    IDtoken.Add("R4");
                                    palabra = null;
                                    break;

                               case "nombre":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva"+palabra);
                                    IDtoken.Add("R5");
                                    palabra = null;
                                    break;

                               case "texto":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva"+palabra);
                                    IDtoken.Add("R6");
                                    palabra = null;
                                    break;

                               case "ruta":
                                    lexemas.Add(palabra);
                                    IDtoken.Add("R7");
                                    tokens.Add("Reserva"+palabra);
                                    palabra = null;
                                    break;

                                default:
                                    FilaListado.Add(fila);
                                    ColumnaListado.Add(numCol);
                                    ErrorCaracter.Add(temp);
                                    Descripcion.Add("No es palabra reservada");
                                    break;
                            }

                            lexemas.Add(temp);
                            tokens.Add("SignoMayor");
                            IDtoken.Add("S2");
                            numCol += 1;
                            interacion += 1;
                        }
                        else
                        {

                            switch (palabra)
                            {
                                case "comando":
                                    cComando = cComando + palabra;
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R2");
                                    palabra = null;
                                    break;

                                case "lfscript":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    palabra = null;
                                    IDtoken.Add("R1");
                                    break;

                                case "tipo":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R3");
                                    palabra = null;
                                    break;

                                case "accion":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R4");
                                    palabra = null;
                                    break;

                                case "nombre":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R5");
                                    palabra = null;
                                    break;

                                case "texto":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R6");
                                    palabra = null;
                                    break;

                                case "ruta":
                                    lexemas.Add(palabra);
                                    IDtoken.Add("R7");
                                    tokens.Add("Reserva" + palabra);
                                    palabra = null;
                                    break;

                                default:
                                    FilaListado.Add(fila);
                                    ColumnaListado.Add(numCol);
                                    ErrorCaracter.Add(temp);
                                    Descripcion.Add("No es palabra reservada");
                                    break;
                            }

                            FilaListado.Add(fila);
                            ErrorCaracter.Add(temp);
                            ColumnaListado.Add(numCol);
                            Descripcion.Add("Caracter Invalido");
                            interacion = linea.Length;

                        }
                        break;

                    case 3:
                        if (Mio.esLetra(caracter))
                        {
                            estado = 4;
                            atributo = atributo + caracter;
                            numCol += 1;
                            interacion += 1;
                        }
                        else if (caracter == '#')
                        {

                            if (cComando == "/comando")
                            {
                                Metodos_201403793 ejecutar = new Metodos_201403793(misComandos);
                                ejecutar.EjecutarMetodos();
                                misComandos.Clear();
                            }

                            Console.WriteLine("Cadena Leida, Aceptada");
                            interacion = linea.Length;

                        }else if (temp == cmDoble)
                        {
                            estado = 5;
                            palabra = palabra + caracter;
                            numCol += 1;
                            interacion += 1;
                        } 
                        break;

                    case 4:
                        if (Mio.esLetra(caracter))
                        {
                            estado = 4;
                            atributo = atributo + caracter;
                            numCol += 1;
                            interacion += 1;
                        }
                        else if (caracter == '-')
                        {
                            estado = 4;
                            atributo = atributo + caracter;
                            numCol += 1;
                            interacion += 1;
                        }
                        else if (caracter == '<')
                        {
                            estado = 7;

                            switch(atributo){
                                case "carpeta":
                                    lexemas.Add(atributo);
                                    tokens.Add("Comando"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("C1");
                                    break;

                                case "archivo":
                                    lexemas.Add(atributo);
                                    tokens.Add("Comando"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("C2");
                                    break;

                                case "especial":
                                    lexemas.Add(atributo);
                                    tokens.Add("Comando"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("C3");
                                    break;

                                case "crear":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A1");
                                    break;

                                case "eliminar":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A2");
                                    break;

                                case "null":
                                    lexemas.Add(atributo);
                                    tokens.Add("Valor nulo");
                                    misComandos.Add(atributo);
                                    IDtoken.Add("21");
                                    break;

                                case "modificar":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A3");
                                    break;

                                case "obtener-fecha":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A4");
                                    break;

                                case "nuevo-nombre-shell":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A5");
                                    break;

                                case "obtener-hora":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo"+atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A6");
                                    break;

                                default:
                                    FilaListado.Add(fila);
                                    ColumnaListado.Add(numCol);
                                    ErrorCaracter.Add(atributo);
                                    Descripcion.Add("No es valido");
                                    palabra = null;
                                    break;      
                            }

                            lexemas.Add(temp);
                            tokens.Add("SignoMenor");
                            IDtoken.Add("S1");
                            numCol += 1;
                            interacion += 1;
                        }
                        else
                        {
                            switch (atributo)
                            {
                                case "carpeta":
                                    lexemas.Add(atributo);
                                    tokens.Add("Comando" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("C1");
                                    break;

                                case "archivo":
                                    lexemas.Add(atributo);
                                    tokens.Add("Comando" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("C2");
                                    break;

                                case "especial":
                                    lexemas.Add(atributo);
                                    tokens.Add("Comando" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("C3");
                                    break;

                                case "crear":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A1");
                                    break;

                                case "eliminar":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A2");
                                    break;

                                case "null":
                                    lexemas.Add(atributo);
                                    tokens.Add("Valor nulo");
                                    misComandos.Add(atributo);
                                    IDtoken.Add("21");
                                    break;

                                case "modificar":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A3");
                                    break;

                                case "obtener-fecha":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A4");
                                    break;

                                case "nuevo-nombre-shell":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A5");
                                    break;

                                case "obtener-hora":
                                    lexemas.Add(atributo);
                                    tokens.Add("Atributo" + atributo);
                                    misComandos.Add(atributo);
                                    IDtoken.Add("A6");
                                    break;

                                default:
                                    FilaListado.Add(fila);
                                    ColumnaListado.Add(numCol);
                                    ErrorCaracter.Add(atributo);
                                    Descripcion.Add("No es valido");
                                    palabra = null;
                                    break;
                            }

                            FilaListado.Add(fila);
                            ColumnaListado.Add(numCol);
                            ErrorCaracter.Add(temp);
                            Descripcion.Add("Caracter Invalido");
                        }
                        break;

                    case 5:
                        if (Mio.esLetra(caracter))
                        {
                            estado = 5;
                            numCol += 1;
                            palabra = palabra + caracter;
                            cadena = cadena + caracter;
                            cadenaRuta = cadenaRuta + caracter;
                        }
                        else if (Mio.esDigito(caracter))
                        {
                            estado = 5;
                            palabra = palabra + caracter;
                            numCol += 1;
                            cadenaRuta = cadenaRuta + caracter;
                            cadena = cadena + caracter;
                        }
                        else if (Mio.esSimbolo(caracter))
                        {
                            estado = 5;
                            palabra = palabra + caracter;
                            numCol += 1;
                            cadena = cadena + caracter;
                        }
                        else if (Mio.esPuntuacion(caracter))
                        {
                            estado = 5;
                            palabra = palabra + caracter;
                            numCol += 1;

                            if(temp == @"\" || temp == ":" || temp == "_" || temp == "-"){
                                esRuta = true;
                                cadenaRuta = cadenaRuta + caracter;
                            }else{
                                cadena = cadena + cadena;
                            }

                        }
                        else if (caracter == ' ')
                        {
                            estado = 5;
                            palabra = palabra + caracter;
                            numCol += 1;
                            cadenaRuta = cadenaRuta + caracter;
                            cadena = cadena + caracter;
                        }
                        else if (temp == cmDoble)
                        {
                            estado = 6;
                            palabra = palabra + caracter;
                            numCol += 1;
                            lexemas.Add(palabra);
                            IDtoken.Add("20");
                            tokens.Add("Cadena");

                            if(esRuta){
                                
                                misComandos.Add(cadenaRuta);

                            }else{

                                misComandos.Add(cadena);

                            }

                            palabra = null;
                        }

                        interacion += 1;
                        break;

                    case 6:
                        if (caracter == '<')
                        {
                            estado = 7;
                            lexemas.Add(temp);
                            numCol += 1;
                            tokens.Add("SignoMenor");
                            IDtoken.Add("S1");
                            interacion += 1;
                        }
                        else
                        {
                            FilaListado.Add(fila);
                            ColumnaListado.Add(numCol);
                            ErrorCaracter.Add(temp);
                            Descripcion.Add("Caracter Invalido");
                            interacion = linea.Length;
                        }
                       
                        break;

                    case 7:
                        if (Mio.esLetra(caracter))
                        {
                            estado = 8;
                            palabra = palabra + caracter;
                            numCol += 1;
                            interacion += 1;
                        }
                        else if (caracter == '/')
                        {
                            estado = 8;
                            lexemas.Add(temp);
                            numCol += 1;
                            tokens.Add("SimboloCierreEtiqueta");
                            IDtoken.Add("S3");
                            interacion += 1;
                        }
                        else
                        {
                            FilaListado.Add(fila);
                            ColumnaListado.Add(numCol);
                            ErrorCaracter.Add(temp);
                            Descripcion.Add("Desconocido");
                            interacion = linea.Length;
                        }

                        break;

                    case 8:
                        if (Mio.esLetra(caracter))
                        {
                            estado = 8;
                            palabra = palabra + caracter;
                            interacion += 1;
                            numCol += 1;
                        }
                        else if (caracter == '>')
                        {
                            estado = 9;
                            numCol += 1;

                            switch (palabra)
                            {
                                case "comando":
                                    cComando = cComando + palabra;
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R2");
                                    palabra = null;
                                    break;

                                case "lfscript":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    palabra = null;
                                    IDtoken.Add("R1");
                                    break;

                                case "tipo":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R3");
                                    palabra = null;
                                    break;

                                case "accion":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R4");
                                    palabra = null;
                                    break;

                                case "nombre":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R5");
                                    palabra = null;
                                    break;

                                case "texto":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R6");
                                    palabra = null;
                                    break;

                                case "ruta":
                                    lexemas.Add(palabra);
                                    IDtoken.Add("R7");
                                    tokens.Add("Reserva" + palabra);
                                    palabra = null;
                                    break;

                                default:
                                    FilaListado.Add(fila);
                                    ColumnaListado.Add(numCol);
                                    ErrorCaracter.Add(temp);
                                    Descripcion.Add("No es palabra reservada");
                                    break;
                            }

                            lexemas.Add(temp);
                            tokens.Add("SignoMayor");
                            IDtoken.Add("S2");
                            interacion += 1;
                        }
                        else
                        {
                            interacion = linea.Length;

                            switch (palabra)
                            {
                                case "comando":
                                    cComando = cComando + palabra;
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R2");
                                    palabra = null;
                                    break;

                                case "lfscript":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    palabra = null;
                                    IDtoken.Add("R1");
                                    break;

                                case "tipo":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R3");
                                    palabra = null;
                                    break;

                                case "accion":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R4");
                                    palabra = null;
                                    break;

                                case "nombre":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R5");
                                    palabra = null;
                                    break;

                                case "texto":
                                    lexemas.Add(palabra);
                                    tokens.Add("Reserva" + palabra);
                                    IDtoken.Add("R6");
                                    palabra = null;
                                    break;

                                case "ruta":
                                    lexemas.Add(palabra);
                                    IDtoken.Add("R7");
                                    tokens.Add("Reserva" + palabra);
                                    palabra = null;
                                    break;

                                default:
                                    FilaListado.Add(fila);
                                    ColumnaListado.Add(numCol);
                                    ErrorCaracter.Add(temp);
                                    Descripcion.Add("No es palabra reservada");
                                    break;
                            }

                            FilaListado.Add(fila);
                            ColumnaListado.Add(numCol);
                            ErrorCaracter.Add(temp);
                            Descripcion.Add("Caracter Invalido");
                        }
                        
                        break;

                    //Estado de aceptacion, cuando la cadena es correcta, cuando hay errores, el analizador continua con la siguiente linea
                    case 9:
                        if (caracter == '#')
                        {

                            //Cuando la palabra de reserva y el atributo estan correctos <reservada>atributo</reservada> la palabra se añade al listado de comandos

                            Console.WriteLine("Cadena Leida, Aceptada");
                            interacion = linea.Length;
                        }
                        break;
                        
                        
                }

            }
            

        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Metodo que obtiene el caracter individual de la linea
        private Char nextLetra(string texto, int posicion)
        {
            char letra;
            char[] conjunto = texto.ToCharArray();

            letra = conjunto[posicion];

            return letra;

        }

        public ArrayList getLexemas()
        {
            return lexemas;
        }

        public ArrayList getTokens()
        {
            return tokens;
        }

        public ArrayList getCErrores()
        {
            return ErrorCaracter;
        }

        public ArrayList getDescripcion()
        {
            return Descripcion;
        }

        public ArrayList getNumFilas()
        {
            return FilaListado;
        }

        public ArrayList getNumColumnas()
        {
            return ColumnaListado;
        }

        public ArrayList getIDs()
        {
            return IDtoken;
        }
    }
}
