using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace PrimeiroPrograma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variável tipada
            int i = 0;
            //variável por inferência
            var x = false;
 
            //variável tipada
            bool teste = true;
 
            Console.WriteLine("olá mundo");
            string nome = Console.ReadLine();
            Console.WriteLine("olá " + nome);
 
 
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var condicao = true;
            //operadores lógicos
            //  && E
            //  || Or
            // !  negação /  not 
 
            //conversao de tipos
 
            int inteiro= Convert.ToInt32("32");
            string numero = 10.ToString();
 
            if (condicao  )
            {
                Console.WriteLine("CONDICAO VERDADEIRA");
            }
            else { }
 
 
                while (i++ < 10)
                {
                    Console.WriteLine("i = " + i);
                }
 
        }
    }
}
