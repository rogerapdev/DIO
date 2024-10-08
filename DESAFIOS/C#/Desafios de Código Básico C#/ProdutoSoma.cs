/* Desafio
Dado um número inteiro ( n ) , retorne a diferença entre o produto de seus dígitos e a soma de seus dígitos.

Entrada
A entrada consiste em um número inteiro ( n );

Saída
A saída consiste na multiplicação do produto dos dígitos ( n ), a soma de seus dígitos e a diferenção entre o produto e a soma, como no exemplo a baixo: 

Exemplo 1

Entrada	Saída
234	15
Explicação: 

Produto de dígitos = 2 * 3 * 4 = 24

Soma dos dígitos = 2 + 3 + 4 = 9

Resultado = 24 - 9 = 15
*/

using System;

class DIO {
        
static void Main(string[] args){

        string entrada = Console.ReadLine();
        char[] numeros = entrada.ToCharArray();
        
        int produto = 1;
        int soma = 0;
        foreach  (char n in numeros) { 
          int conversao = int.Parse(n.ToString());
          produto *= conversao;
          soma += conversao;
        }
        
        int resultado = produto - soma;
        
        Console.WriteLine(resultado);

    }
}