using System;
using System.IO;

namespace Homework2
{
    class Program
    {
        static string[] Sort(string[] scores, int length) //Sorting Function
        {
            //initializing a few arrays for transferring
            string[] sorted_array = new string[length]; //final array
            string[] numbers = new string[length];
            for (int k = 0; k < length; k++)
            {
                string[] number = scores[k].Split(";");
                numbers[k] = number[1]; //Assinging scores to array(numbers) in order
            }
            int counter = 0; //index to be deleted after using
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (j == 0) //initial assignment
                    {
                        sorted_array[i] = scores[j];
                        counter = 0;
                    }
                    else if (Convert.ToInt16(numbers[counter]) < Convert.ToInt16(numbers[j])) // choosing the largest number
                    {
                        sorted_array[i] = scores[j];
                        counter = j;
                    }
                }
                numbers[counter] = "0"; //deleting used score by assigning to zero
            }
            return sorted_array;
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                //initializing a few variables
                int point = 0;
                int pnt;
                Random rand = new Random();
                string[,] choosens = new string[9, 2]; //choosen cards' array 
                string[] colors = { "Red", "Green", "Blue" }; //color pool of choosen cards
                int red = 0;
                int green = 0;
                int blue = 0;
                //Generating Random Array
                for (int i = 0; i < 9; i++)
                {
                    while (true)
                    {
                        int lett = rand.Next(65, 69); //random letter from A-B-C-D
                        int color = rand.Next(0, 3); // random choosing from 3 colors
                        if (!((red == 3 && colors[color] == "Red") || (green == 3 && colors[color] == "Green") || (blue == 3 && colors[color] == "Blue"))) //if there are 3 same color and if the selected color is the same, choose again
                        {
                            choosens[i, 0] = $"{Convert.ToChar(lett)}"; //choosens[i, 0] represents i. card's letter
                            choosens[i, 1] = colors[color]; //choosens[i, 1] represents i. card's color
                            switch (colors[color])
                            {
                                case "Red":
                                    red++;
                                    break;
                                case "Green":
                                    green++;
                                    break;
                                case "Blue":
                                    blue++;
                                    break;
                            }
                            break; //break the infinity loop after choosing i. card 
                        }
                        continue;
                    }
                }
                Console.WriteLine("_".PadRight(46, '_'));
                //Printing Generated Array
                Console.Write("Randomly generated array: ");
                for (int i = 0; i < 9; i++)
                {
                    if (choosens[i, 1] == "Red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(choosens[i, 0] + " ");
                    }
                    else if (choosens[i, 1] == "Green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(choosens[i, 0] + " ");
                    }
                    else if (choosens[i, 1] == "Blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(choosens[i, 0] + " ");
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White; //Reseting Fore Ground Color 
                //Calculating Score
                for (int i = 0; i < 7; i++)
                {
                    pnt = 0;
                    if ((choosens[i, 0] == choosens[i + 1, 0]) && (choosens[i + 1, 0] == choosens[i + 2, 0]))
                    {
                        if ((choosens[i, 1] == choosens[i + 1, 1]) && (choosens[i + 1, 1] == choosens[i + 2, 1]))
                        {
                            pnt = 33;

                        }
                        else if (!(choosens[i, 1] == choosens[i + 1, 1]) && !(choosens[i + 1, 1] == choosens[i + 2, 1]) && !(choosens[i, 1] == choosens[i + 2, 1]))
                        {
                            pnt = 28;
                        }
                        else
                        {
                            pnt = 22;
                        }
                    }
                    else if ((!(choosens[i, 0] == choosens[i + 1, 0]) && !(choosens[i + 1, 0] == choosens[i + 2, 0]) && !(choosens[i, 0] == choosens[i + 2, 0])) && !((choosens[i, 0] == "A" || choosens[i + 1, 0] == "A" || choosens[i + 2, 0] == "A") && (choosens[i, 0] == "D" || choosens[i + 1, 0] == "D" || choosens[i + 2, 0] == "D")))
                    {
                        if ((choosens[i, 1] == choosens[i + 1, 1]) && (choosens[i + 1, 1] == choosens[i + 2, 1]))
                        {
                            pnt = 18;
                        }
                        else if (!(choosens[i, 1] == choosens[i + 1, 1]) && !(choosens[i + 1, 1] == choosens[i + 2, 1]) && !(choosens[i, 1] == choosens[i + 2, 1]))
                        {
                            pnt = 16;
                        }
                        else
                        {
                            pnt = 14;
                        }
                    }
                    else if ((choosens[i, 1] == choosens[i + 1, 1]) && (choosens[i + 1, 1] == choosens[i + 2, 1]))
                    {
                        pnt = 12;
                    }
                    else if (!(choosens[i, 1] == choosens[i + 1, 1]) && !(choosens[i + 1, 1] == choosens[i + 2, 1]) && !(choosens[i, 1] == choosens[i + 2, 1]))
                    {
                        pnt = 10;
                    }
                    //Printing Important Combination that made point
                    if (!(pnt == 0)) //to print combinations only made point
                    {
                        for (int a = i; a < i + 3; a++)
                        {
                            if (choosens[a, 1] == "Red")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(choosens[a, 0] + " ");
                            }
                            else if (choosens[a, 1] == "Green")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(choosens[a, 0] + " ");
                            }
                            else if (choosens[a, 1] == "Blue")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(choosens[a, 0] + " ");
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{pnt} points");
                        point += pnt;
                        Console.WriteLine();
                    }
                }
                Console.WriteLine($"You get {point} points !!!");
                //Saving score and name to .txt file
                Console.WriteLine("Please enter your name: ");
                string name = Console.ReadLine();
                StreamWriter f = File.AppendText("scores.txt");
                f.WriteLine($"{name};{point}"); // To make the sort function digit number sensitive
                f.Close();
                //Printing High Score Table
                Console.WriteLine("_".PadRight(46, '_'));
                Console.WriteLine("High Score Table ");
                //To calculate number of score&name - it will be used for many transactions later
                int counter = 0;
                StreamReader f2 = File.OpenText("scores.txt");
                do
                {
                    f2.ReadLine();
                    counter++;
                } while (!f2.EndOfStream);
                f2.Close();
                string[] array = new string[counter];
                StreamReader f3 = File.OpenText("scores.txt");
                for (int i = 0; i < counter; i++)
                {
                    array[i] = f3.ReadLine();
                }
                f3.Close();
                string[] sorted_array = Sort(array, counter);
                StreamWriter f4 = File.CreateText("scores.txt");
                if (counter < 10) //printing if counter <10
                {
                    for (int i = 0; i < counter; i++)
                    {
                        string[] s = sorted_array[i].Split(";");
                        Console.WriteLine(s[0] + " " + s[1]);
                        f4.WriteLine($"{s[0]};{s[1]}");
                    }
                }
                else // printing if counter >=10
                {
                    for (int i = 0; i < 10; i++)
                    {
                        string[] s = sorted_array[i].Split(";");
                        Console.WriteLine(s[0] + " " + s[1]);
                        f4.WriteLine($"{s[0]};{s[1]}");
                    }
                }
                f4.Close();
                //for breaking nested loop i used this way (like double break)
                string breakloop = "  ";
                Console.WriteLine("_".PadRight(46, '_'));
                while (true)
                {
                    //Asking to user whether she/he play again.
                    Console.WriteLine("Do you want to play again ? (Yes/No)");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        break;
                    }
                    else if (answer == "no")
                    {
                        breakloop = "break";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                }
                if (breakloop == "break")
                {
                    break;
                }
            }
        }
    }
}
