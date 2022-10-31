using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET
{
    public class Majoritario
    {
        public static void Main (string[] args) {
            int n = int.Parse(Console.ReadLine());

            int[] numeros = new int[n];

            for (int i = 0; i < n; i++)
            {
                numeros[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(ProcuraMajoritario(numeros, n));

        }

        public static int ProcuraMajoritario (int[] elementos, int n)
        {
            int maximo = 0;
            int indice = -1;
            for (int i = 0; i < n; i++)
            {
                int contador = 0;
                for (int j = 0; j < n; j++)
                {
                    if (elementos[i] == elementos[j]) contador++;
                }
                if(contador > maximo)
                {
                    maximo = contador;
                    indice = i;
                }
            }

            if(maximo > n / 2)
                return elementos[indice];
            else
                return 0;
        }
    }
}