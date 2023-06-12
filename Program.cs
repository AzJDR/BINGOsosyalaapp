using System;
using System.Collections.Generic;

namespace BINGO
{
    class BingoCard
    {
        private const int Rows = 5;
        private const int Columns = 5;
        private const int MiddleRow = Rows / 2;
        private const int MiddleColumn = Columns / 2;
        private const string FreeSpace = "F";

        private static readonly object[,] card = new object[Rows, Columns];

        static void Main()
        {
            Console.Clear();
            InitializeCard();
            DisplayCard();
            Pattern();
            int patternNumber = GetPatternNumber();
            do
            {
                Console.Clear();
                switch (patternNumber)
                {
                    case 1:
                        ExtractTopRow();
                        Pattern();
                        break;
                    case 2:
                        ExtractBottomRow();
                        Pattern();
                        break;
                    case 3:
                        ExtractMiddleRow();
                        Pattern();
                        break;
                    case 4:
                        ExtractLeftColumn();
                        Pattern();
                        break;
                    case 5:
                        ExtractRightColumn();
                        Pattern();
                        break;
                    case 6:
                        ExtractMiddleColumn();
                        Pattern();
                        break;
                    case 7:
                        ExtractLeftToRightDiagonal();
                        Pattern();
                        break;
                    case 8:
                        ExtractRightToLeftDiagonal();
                        Pattern();
                        break;
                    case 9:
                        ExtractSquareTopLeftRows();
                        Pattern();
                        break;
                    case 10:
                        ExtractSquareBottomRightRows();
                        Pattern();
                        break;
                    case 0:
                        // Exit the program
                        Console.WriteLine("Exiting the BINGO sosyal app");
                        return;
                    default:
                        Console.WriteLine("Invalid pattern number. Please try again.");
                        break;
                }
                patternNumber = GetPatternNumber();
            } while (true);
        }

        static void InitializeCard()
        {
            Random random = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();

            for (int column = 0; column < Columns; column++)
            {
                int minValue = column * 15 + 1;
                int maxValue = column * 15 + 15;

                for (int row = 0; row < Rows; row++)
                {
                    if (row == MiddleRow && column == MiddleColumn)
                    {
                        card[row, column] = FreeSpace;
                    }
                    else
                    {
                        int randomNumber;
                        do
                        {
                            randomNumber = random.Next(minValue, maxValue + 1);
                        } while (usedNumbers.Contains(randomNumber));

                        usedNumbers.Add(randomNumber);
                        card[row, column] = randomNumber;
                    }
                }
            }
        }

        static void DisplayCard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("BINGO Sosyal App\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("┌───┬───┬───┬───┬───┐");

            Console.Write("│ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("B");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" │ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("I");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" │ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("N");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" │ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("G");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" │ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("O");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" │ ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("├───┼───┼───┼───┼───┤");
            Console.ResetColor();



            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("│");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(card[row, column].ToString().PadLeft(2));

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("│");

                if (row != Rows - 1)
                    Console.WriteLine("├───┼───┼───┼───┼───┤");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("└───┴───┴───┴───┴───┘");
            Console.WriteLine();
            Console.ResetColor(); // Reset color to default
        }
        static int GetPatternNumber()
        {
            int patternNumber;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter pattern number 0-10(ps: type '0' zero to exit the bingo): ");
                if (int.TryParse(Console.ReadLine(), out patternNumber) && patternNumber >= 0 && patternNumber <= 10)
                    break;

                Console.WriteLine("Invalid pattern number. Please try again.");
            }
            return patternNumber;
        }
        static void Pattern()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #1. Top Row");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * * * *\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #2. Bottom Row");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * * * *\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #3. Middle Row");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * F * *\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #4. Left Column          Pattern #5. Right Column           Pattern #6. Middle Column");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*                                *                                  *");
            Console.WriteLine("*                                *                                  *");
            Console.WriteLine("*                                *                                  F");
            Console.WriteLine("*                                *                                  *");
            Console.WriteLine("*                                *                                  *\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #7. From Left to Right Diagonal          Pattern #8. From Right to Left Diagonal");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        *                                                            *");
            Console.WriteLine("         *                                                          *");
            Console.WriteLine("          F                                                        F");
            Console.WriteLine("           *                                                      *");
            Console.WriteLine("            *                                                    *\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #9. Square Top-Left Rows");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* *");
            Console.WriteLine("* *");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Pattern #10. Square Bottom-Right Rows");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* *");
            Console.WriteLine("* *");
            Console.WriteLine();
            Console.ResetColor();
        }

        static void ExtractTopRow()
        {
            Console.WriteLine("Pattern #1. Top Row");

            for (int column = 0; column < Columns; column++)
            {
                Console.Write($"{card[0, column]}\t");
            }
            Console.WriteLine("\n");
        }

        static void ExtractBottomRow()
        {
            Console.WriteLine("Pattern #2. Bottom Row");

            for (int column = 0; column < Columns; column++)
            {
                Console.Write($"{card[Rows - 1, column]}\t");
            }
            Console.WriteLine("\n");

        }

        static void ExtractMiddleRow()
        {
            Console.WriteLine("Pattern #3. Middle Row");

            for (int column = 0; column < Columns; column++)
            {
                Console.Write($"{card[MiddleRow, column]}\t");
            }
            Console.WriteLine("\n");

        }

        static void ExtractLeftColumn()
        {
            Console.WriteLine("Pattern #4. Left Column");

            for (int row = 0; row < Rows; row++)
            {
                Console.WriteLine(card[row, 0]);
            }
            Console.WriteLine();
        }

        static void ExtractRightColumn()
        {
            Console.WriteLine("Pattern #5. Right Column");

            for (int row = 0; row < Rows; row++)
            {
                Console.WriteLine(card[row, Columns - 1]);
            }
            Console.WriteLine();
        }

        static void ExtractMiddleColumn()
        {
            Console.WriteLine("Pattern #6. Middle Column");

            for (int row = 0; row < Rows; row++)
            {
                Console.WriteLine(card[row, MiddleColumn]);
            }
            Console.WriteLine();
        }

        static void ExtractLeftToRightDiagonal()
        {
            Console.WriteLine("Pattern #7. From Left to Right Diagonal");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (j == i)
                        Console.Write($"{card[i, j]}\t");
                    else
                        Console.Write("\t");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ExtractRightToLeftDiagonal()
        {
            Console.WriteLine("Pattern #8. From Right to Left Diagonal");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (j == Rows - 1 - i)
                        Console.Write($"{card[i, j]}\t");
                    else
                        Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void ExtractSquareTopLeftRows()
        {
            Console.WriteLine("Pattern #9. Square Top-Left Rows");

            for (int row = 0; row < Rows / 2; row++)
            {
                for (int column = 0; column < Columns / 2; column++)
                {
                    Console.Write($"{card[row, column]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void ExtractSquareBottomRightRows()
        {
            Console.WriteLine("Pattern #10. Square Bottom-Right Rows");

            for (int row = Rows - 2; row < Rows; row++)
            {
                for (int column = Columns - 2; column < Columns; column++)
                {
                    Console.Write($"{card[row, column]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

}