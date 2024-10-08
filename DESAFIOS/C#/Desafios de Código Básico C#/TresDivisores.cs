/*
Desafio
Dado um inteiro n, retorne true se n tiver exatamente três divisores positivos. Caso contrário, retorne false. O inteiro m é um divisor de n, se existe um inteiro k tal que n = k * m. 

Entrada
O arquivo de entrada consiste em um inteiro n que será validada caso esteja sob as condições do desafio.

Saída
A saída consistirá em um tipo booleano: true ou false. Como nos exemplos a baixo:

Exemplo 1:

Entrada	Saída
2	false
Explicação: 2 possui apenas dois divisores: 1 e 2.

Exemplo 2:

Entrada	Saída
4	true
Explicação: 4 tem três divisores: 1, 2 e 4.
*/

using System;
 
class Solution {
    public static void Main(string[] args) {
        int entrada = int.Parse(Console.ReadLine());
        int count = 0;
 
        for (int i = 1; i <= entrada; i++) {
// TODO: Crie as outras condições necessárias para a resolução do desafio:
            if (entrada % i == 0) {
                count++;
            }
            if (count == 3) {
                break;
            }
        }
         Console.WriteLine(count == 3);
    }
}