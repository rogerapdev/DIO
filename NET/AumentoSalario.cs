using System;  

class minhaClasse { 

  public static double ValorReajuste(double valor, double percentual)
  {
    return (percentual * valor);
  }
  
  public static double Porcentagem(double p)
  {
    return p / 100;
  }
  
  public static double NovoSalario(double valor, double reajuste)
  {
    return valor + reajuste;
  }
  
  static void Main(string[] args) {  

    double salario = 0.00; 
    double reajuste = 0.00; 
    double novoSalario = 0.00; 
    double percentual = 0.00; 
  
    salario = Convert.ToDouble(Console.ReadLine()); 
 
//TODO: Complete os espaços em branco com uma possível solução para o problema:
   
    if(salario < 0) { 
      return; 

    } else if ( salario <= 400) { 
      percentual = Porcentagem(15); 
      reajuste =  ValorReajuste(salario, percentual); 
      novoSalario =  NovoSalario(salario, reajuste) ; 


    } else if ( salario <= 800) { 
      percentual = Porcentagem(12); 
      reajuste =  ValorReajuste(salario, percentual); 
      novoSalario =  NovoSalario(salario, reajuste) ; 

    } else if (  salario  <= 1200) { 
      percentual = Porcentagem(10); 
      reajuste =  ValorReajuste(salario, percentual); 
      novoSalario =  NovoSalario(salario, reajuste) ; 

    } else if ( salario  <= 2000) { 
      percentual = Porcentagem(7); 
      reajuste =  ValorReajuste(salario, percentual); 
      novoSalario =  NovoSalario(salario, reajuste) ; 

    } else { 
      percentual = Porcentagem(4); 
      reajuste =  ValorReajuste(salario, percentual); 
      novoSalario =  NovoSalario(salario, reajuste) ; 

    } 

    Console.WriteLine("Novo salario: {0:0.00}",    novoSalario          ); 
    Console.WriteLine("Reajuste ganho: {0:0.00}",     reajuste        ); 
    Console.WriteLine("Em percentual: {0} %", percentual *  100   ); 

  } 
}