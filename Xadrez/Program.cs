using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P;
            P = new Posicao(3,4);
            Console.WriteLine("Posiçao: " + P);
            Console.ReadLine();
        }
    }
}
