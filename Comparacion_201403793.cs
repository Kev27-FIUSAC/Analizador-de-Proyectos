using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practica1_201403793
{
    class Comparacion_201403793
    {

        private string abecedario = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnÑñOoPpQqRrSsTtUuVvWwXxYyZz";
        private string digitos = "0123456789";
        private string puntuaciones = @".:;-_/\¿?¡!";
        string simbolos = "+*$%&#|=@";
        private char[] CjAbecedario;
        private char[] CjDigitos;
        private char[] CjPuntuacion;
        private char[] CjSimbolos;

        public Comparacion_201403793()
        {
            CjAbecedario = abecedario.ToCharArray();
            CjDigitos = digitos.ToCharArray();
            CjPuntuacion = puntuaciones.ToCharArray();
            CjSimbolos = simbolos.ToCharArray();
        }

        public Boolean esLetra(char letra)
        {

            Boolean tipo = false; 

            for (int a = 0; a < abecedario.Length; a++)
            {
                if (letra == CjAbecedario[a])
                {
                    tipo = true;
                    break;
                }
                else
                {
                    tipo = false;
                }
            }

            return tipo;
        }


        public Boolean esDigito(char numero)
        {

            Boolean tipo = false;

            for (int b = 0; b < digitos.Length; b++)
            {

                if (numero == CjDigitos[b])
                {
                    tipo = true;
                    break;
                }
                else
                {
                    tipo = false;
                }

            }

                return tipo;
        }

        public Boolean esPuntuacion(char puntuacion)
        {
            Boolean tipo = false;

            for (int c = 0; c < puntuaciones.Length; c++)
            {
                if (puntuacion == CjPuntuacion[c])
                {
                    tipo = true;
                    break;
                }
                else
                {
                    tipo = false;
                }
            }

            return tipo;
        }

        public Boolean esSimbolo(char simbolo)
        {
            Boolean respuesta = false;

            for (int d = 0; d < simbolos.Length; d++)
            {

                if (simbolo == CjSimbolos[d])
                {
                    respuesta = true;
                    break;
                }
                else
                {
                    respuesta = false;
                }

            }
            return respuesta;
        }

    }
}
