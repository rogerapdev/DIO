using System;
using System.Text.RegularExpressions;

class MinhaClasse {
  public static void Main (string[] args) {

    // do {
    string senha = Console.ReadLine();
    
    while (!String.IsNullOrEmpty(senha)) {
      
      if(senha.Length < 6 || senha.Length > 32) {
        Console.WriteLine("Senha invalida.");
      } else {
        
        int countUpper = 0;
        int countLower = 0;
        int countDigit = 0;
        int countSpecial = 0;
        
        foreach (char c in senha)
        {
            //if is upper case add to cap_count
            if (Char.IsUpper(c))
                countUpper++;
                
            if (Char.IsLower(c))
              countLower++;
              
            if (Char.IsDigit(c))
              countDigit++;
              
            if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                countSpecial++;
    
        }
        
        if(countLower < 1 || countUpper < 1 || countDigit < 1 || countSpecial > 0) {
          Console.WriteLine("Senha invalida.");
        } else {
          Console.WriteLine("Senha valida.");
        }
        
        
      }
      senha = Console.ReadLine();
    }

  }
}