using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddSumniki
{
    class Runner
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"C:\Users\km\source\repos\AddSumniki\AddSumniki\input.txt");
            string output = new TextSumnikizer().Rectify(input);
            File.WriteAllText(@"C:\Users\km\source\repos\AddSumniki\AddSumniki\output.txt", output);
            Console.ReadLine();
        }
    }
}
