/**
 * ######################################################
 * ##    Programming Assignment #4                     ##
 * ##    Developer: Matthew Obert                      ##
 * ##    Date Submitted: September 06 2019             ##
 * ##    Purpose: Demonstrate usage of void methods.   ##
 * ######################################################
 */

using System;
using static System.Console;

namespace GrossProfitRatio
{
    class Program
    {
        static void RepeatChar(string character, int reps)
        {
            for (int i = 0; i < reps; i++)
            {
                Write(character);
            }
        }

        static void CenterString(string message, int bannerWidth)
        {
            if (message.Length > bannerWidth)
            {
                WriteLine(message);
            }
            else
            {
                RepeatChar(" ", (bannerWidth - message.Length) / 2);
                WriteLine(message);
            }
        }
        static int ReadInt(string input)
        {
            int choice;

            while (!int.TryParse(input, out choice))
            {
                WriteLine("Invalid input.\nPlease choose a number.");
                input = ReadLine();
            }
            return choice;
        }

        static void GenerateHeader()
        {
            const int BANNER_WIDTH = 54;

            // generate output
            RepeatChar("*", BANNER_WIDTH);
            WriteLine();
            CenterString("Apex Stores Gross Profit Ratio Report", BANNER_WIDTH);
            RepeatChar(" ", 8);
            Write("Today's Date: ");
            WriteLine( DateTime.Today.ToShortDateString() );
            RepeatChar("*", BANNER_WIDTH);
            WriteLine();
        }
        static void CalculateGPR(double grossSales, double salesReturns, double costOfGoods)
        {
            // initialize local variables
            double netSales;
            double grossProfit;
            double grossProfitRatio;

            // calculate new total
            netSales = grossSales - salesReturns;
            grossProfit = netSales - costOfGoods;
            grossProfitRatio = grossProfit / netSales;

            // output using percentage format specifier
            WriteLine("Gross Profit Ratio is >> {0:P1}", grossProfitRatio);
        }
        static void Main(string[] args)
        {
            // declare variables
            double grossSales;
            double salesReturns;
            double costOfGoods;
            string input;

            // header output
            GenerateHeader();

            // variable assignment
            Write("Enter Gross Sales: ");
            input = ReadLine();
            grossSales = ReadInt(input);
            Write("Enter Sales Return: ");
            input = ReadLine();
            salesReturns = ReadInt(input);
            Write("Enter Cost of Goods Sold: ");
            input = ReadLine();
            costOfGoods = ReadInt(input);
            WriteLine();

            // Gross Profit Ratio output
            CalculateGPR(grossSales, salesReturns, costOfGoods);
            ReadLine();
        }
    }
}
