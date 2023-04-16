using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Xml;
using System.Data;

namespace Practica1_201403793
{
    class GeneradorArchivo_201403793
    {
        //Atributos
        private string guardar;
        private string guardarTokens;
        private string guardarErroes;
        private string texto;
        private Byte[] etiqueta;

        public GeneradorArchivo_201403793(string ubicacion)
        {
            guardar = ubicacion; 
        }

        public void setTexto(string x)
        {
            texto = x;
        }


        public void generarArchivo(string nombre)
        {
            string archivo = Path.Combine(guardar, nombre);
            archivo = archivo + ".txt";

            FileStream escribir = File.Create(archivo);

            etiqueta = new UTF8Encoding(true).GetBytes(texto);
            escribir.Write(etiqueta, 0, etiqueta.Length);

            escribir.Close();
        }

        public void generarFecha(string nombre)
        {

            string archivo = Path.Combine(guardar, nombre);
            archivo += ".txt";

            FileStream escribir = File.Create(archivo);

            Byte[] linea;

            linea = new UTF8Encoding(true).GetBytes("Fecha obtenida por el sistema: ");
            escribir.Write(linea, 0, linea.Length);

            DateTime actual = DateTime.Now;

            linea = new UTF8Encoding(true).GetBytes(actual.ToString("d"));
            escribir.Write(linea, 0, linea.Length);

            escribir.Close();
                                }

        public void generarHora(string nombre)
        {

            string archivo = Path.Combine(guardar, nombre);
            archivo += ".txt";

            FileStream escribir = File.Create(archivo);

            Byte[] linea;

            linea = new UTF8Encoding(true).GetBytes("Hora obtenida por el sistema: ");
            escribir.Write(linea, 0, linea.Length);

            string hora = DateTime.Now.ToString("hh:mm:ss");

            linea = new UTF8Encoding(true).GetBytes(hora);
            escribir.Write(linea, 0, linea.Length);

            escribir.Close();

        }

        public void generadorTokens(ArrayList Lexemas, ArrayList Tokens, ArrayList ids)
        {

            guardarTokens = guardar;
            guardarTokens = guardarTokens + @"\Tokens_201403793.html";

           FileStream  escribir = File.Create(guardarTokens);


           etiqueta = new UTF8Encoding(true).GetBytes("<html>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<head>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<title>Listado de Tokens</title>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<style>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("table, th, td{");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("     border: 1px solid black;");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("     border-collapse: collapse;");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("}");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("th, td{");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("     padding: 5px");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("}");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("</style>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("</head>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<body>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<H1><CENTER><FONT FACE='ARIAL' COLOR='436E1D'><B><U>Listado General de Tokens obtenidos</U></B></FONT></CENTER></H1>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<center>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<table>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<tr>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='049A42'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'><B>#</B></FONT></th>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='049A42'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'><B>Lexema</B></FONT></th>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='049A42'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'><B>id Token</B></FONT></th>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='049A42'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'><B>Token</B></FONT></th>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("</tr>");
           escribir.Write(etiqueta, 0, etiqueta.Length);

           for (int fila = 0; fila < Tokens.Count; fila++)
           {

               string lexema = (string)Lexemas[fila];
               string token = (string)Tokens[fila];
               string idsT = ids[fila].ToString();


               if ((fila % 2) == 0)
               {

                   etiqueta = new UTF8Encoding(true).GetBytes("<TR>");
                   escribir.Write(etiqueta, 0, etiqueta.Length);
                   etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='F5FCD2'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + (fila + 1) + "</FONT></td>");
                   escribir.Write(etiqueta, 0, etiqueta.Length);
                   etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='F5FCD2'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + lexema + "</FONT></td>");
                   escribir.Write(etiqueta, 0, etiqueta.Length);
                   etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='F5FCD2'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + idsT + "</FONT></td>");
                   escribir.Write(etiqueta, 0, etiqueta.Length);
                   etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='F5FCD2'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + token + "</FONT></td>");
                   escribir.Write(etiqueta, 0, etiqueta.Length);
                   etiqueta = new UTF8Encoding(true).GetBytes("</TR>");
                   escribir.Write(etiqueta, 0, etiqueta.Length);

               }
               else
               {

               etiqueta = new UTF8Encoding(true).GetBytes("<TR>");
               escribir.Write(etiqueta, 0, etiqueta.Length);
               etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='FEFFD8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + (fila + 1) + "</FONT></td>");
               escribir.Write(etiqueta, 0, etiqueta.Length);
               etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='FEFFD8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + lexema + "</FONT></td>");
               escribir.Write(etiqueta, 0, etiqueta.Length);
               etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='FEFFD8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + idsT + "</FONT></td>");
               escribir.Write(etiqueta, 0, etiqueta.Length);
               etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='FEFFD8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + token + "</FONT></td>");
               escribir.Write(etiqueta, 0, etiqueta.Length);
               etiqueta = new UTF8Encoding(true).GetBytes("</TR>");
               escribir.Write(etiqueta, 0, etiqueta.Length);

               }

            
           }

           etiqueta = new UTF8Encoding(true).GetBytes("</table>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("</center>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<center>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<p></p>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("<P ALING=JUSTIFY><FONT FACE='Imprint MT Shadow' COLOR='black' SIZE=4>Nota: Puede consultar en el manual tecnico sobre la descripcion de cada id que le corresponde a los tokens obtenidos correctamente.</FONT><P>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("</body>");
           escribir.Write(etiqueta, 0, etiqueta.Length);
           etiqueta = new UTF8Encoding(true).GetBytes("</html>");
           escribir.Write(etiqueta, 0, etiqueta.Length);

           escribir.Close();
           Lexemas = null;
           Tokens = null;

           Console.WriteLine("Archivo Tokens HTML Generado");
        }

        public void generadorError(ArrayList errores, ArrayList descripcion, ArrayList filas, ArrayList columnas)
        {

            guardarErroes = guardar;
            guardarErroes = guardarErroes + @"\Errores_201403793.html";

            FileStream escribir = File.Create(guardarErroes);

            etiqueta = new UTF8Encoding(true).GetBytes("<html>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<head>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<title>Listado de Errores</title>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<style>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("table, th, td{");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("     border: 1px solid black;");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("     border-collapse: collapse;");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("}");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("th, td{");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("     padding: 5px");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("}");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("</style>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("</head>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<body>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<H1><CENTER><FONT FACE='ARIAL' COLOR='869297'><B><U>Listado General de Errores detectados</U></B></FONT></CENTER></H1>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<center>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<table>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<tr>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='080908'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'>#</FONT></th>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='080908'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'>Fila</FONT></th>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='080908'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'>Columna</FONT></th>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='080908'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'>Caracter</FONT></th>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<th BGCOLOR='080908'><FONT FACE='CENTURY GOTHIC' SIZE=5 COLOR='WHITE'>Descripcion</FONT></th>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("</tr>");
            escribir.Write(etiqueta, 0, etiqueta.Length);

            for (int linea = 0; linea < filas.Count; linea++)
            {

                string lf = filas[linea].ToString();
                string colum = columnas[linea].ToString();
                string caracter = errores[linea].ToString();
                string definicion = descripcion[linea].ToString();

                if ((linea % 2) == 0)
                {

                etiqueta = new UTF8Encoding(true).GetBytes("<TR>");
                escribir.Write(etiqueta, 0, etiqueta.Length);
                etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='D8D8D8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + (linea + 1) + "</FONT></td>");
                escribir.Write(etiqueta, 0, etiqueta.Length);
                etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='D8D8D8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + lf + "</FONT></td>");
                escribir.Write(etiqueta, 0, etiqueta.Length);
                etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='D8D8D8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + colum + "</FONT></td>");
                escribir.Write(etiqueta, 0, etiqueta.Length);
                etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='D8D8D8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + caracter + "</FONT></td>");
                escribir.Write(etiqueta, 0, etiqueta.Length);
                etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='D8D8D8'><FONT FACE='Calibri Light' SIZE=3 COLOR='BLACK'>" + definicion + "</FONT></td>");
                escribir.Write(etiqueta, 0, etiqueta.Length);
                etiqueta = new UTF8Encoding(true).GetBytes("</TR>");
                escribir.Write(etiqueta, 0, etiqueta.Length);

                }
                else
                {

                    etiqueta = new UTF8Encoding(true).GetBytes("<TR>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);
                    etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='6E6E6E'><FONT FACE='Calibri Light' SIZE=3 COLOR='WHITE'>" + (linea + 1) + "</FONT></td>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);
                    etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='6E6E6E'><FONT FACE='Calibri Light' SIZE=3 COLOR='WHITE'>" + lf + "</FONT></td>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);
                    etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='6E6E6E'><FONT FACE='Calibri Light' SIZE=3 COLOR='WHITE'>" + linea  + "</FONT></td>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);
                    etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='6E6E6E'><FONT FACE='Calibri Light' SIZE=3 COLOR='WHITE'>" + caracter + "</FONT></td>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);
                    etiqueta = new UTF8Encoding(true).GetBytes("<td BGCOLOR='6E6E6E'><FONT FACE='Calibri Light' SIZE=3 COLOR='WHITE'>" + definicion + "</FONT></td>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);
                    etiqueta = new UTF8Encoding(true).GetBytes("</TR>");
                    escribir.Write(etiqueta, 0, etiqueta.Length);

                }

            }

            etiqueta = new UTF8Encoding(true).GetBytes("</table>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("</center>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<center>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<p></p>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("<P ALING=JUSTIFY><FONT FACE='Imprint MT Shadow' COLOR='black' SIZE=5>Nota: Las lineas que contiene los errores no son interpretados correctamente.</FONT><P>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("</body>");
            escribir.Write(etiqueta, 0, etiqueta.Length);
            etiqueta = new UTF8Encoding(true).GetBytes("</html>");
            escribir.Write(etiqueta, 0, etiqueta.Length);

            escribir.Close();

            Console.WriteLine("Archivo Errores HTML Generado");

            errores = null;
            descripcion = null;
            filas = null;
            columnas = null;
        }

    }
}
