﻿// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Enter Day of Advent of Code:");

// Create a string variable and get user input from the keyboard and store it in the variable
var day = Console.ReadLine();

string textFile = Path.Combine(Directory.GetCurrentDirectory(), "Input AOC\\Day" + day + ".txt");
if (File.Exists(textFile))
{
    // Read a text file line by line.
    string[] lines = File.ReadAllLines(textFile);

    switch (day)
    {
        case "1":
            Console.WriteLine("******** Day 1 - Advent of Code ********");
            #region Day 1

            //Separate the Column into 2 rows
            List<int> firstNums = new List<int>();
            List<int> secondNums = new List<int>();
            foreach (string line in lines)
            {
                string[] numCodes = line.Split("   ");
                for (int i = 0; i < numCodes.Length; i++)
                {
                    if (i == 0)
                        firstNums.Add(int.Parse(numCodes[i]));
                    else
                        secondNums.Add(int.Parse(numCodes[i]));
                }
            }

            //Sort
            firstNums.Sort();
            secondNums.Sort();

            //Part 1

            //Calculate find the differences
            List<int> totalNum1 = new List<int>();
            for (int i = 0; i < firstNums.Count; i++)
            {
                totalNum1.Add(Math.Abs(firstNums[i] - secondNums[i]));
                //Console.WriteLine((i + 1).ToString() + ". Distance between " + firstNums[i].ToString() + " and " + secondNums[i].ToString() + " is " + (Math.Abs(firstNums[i] - secondNums[i])).ToString());
            }

            //Calculate the sum
            string total1 = totalNum1.Sum().ToString();
            Console.WriteLine("Part 1: Total distance is " + total1 + " \n");

            //Part 2

            //Calculate find the similarity score
            List<int> totalNum2 = new List<int>();
            foreach (int firstNum in firstNums)
            {
                if (firstNum == 11652)
                    Console.WriteLine("found!");

                var duplicates = secondNums.GroupBy(x => x)
               .Where(g => g.Count() >= 1)
               .Where (g => g.Key == firstNum)
               .Select(y => y.Count())
               .ToList();

              //  var secondNumDuplicates = secondNums.GroupBy(x => x)
              //.Where(g => g.Count() > 1)
              //.ToDictionary(x => x.Key, y => y.Count());

                if (duplicates.Count > 0)
                {
                    totalNum2.Add(firstNum * duplicates.First());

                    Console.WriteLine(firstNum.ToString() + " appears " + duplicates.First().ToString() + " times in right list");
                    Console.WriteLine(firstNum.ToString() + " * " + duplicates.First().ToString() + " = " + (firstNum * duplicates.First()).ToString());
                }
                else
                {
                    totalNum2.Add(firstNum * 0);

                    Console.WriteLine(firstNum.ToString() + " appears 0 times in right list");
                    Console.WriteLine(firstNum.ToString() + " * 0 = " + (firstNum * 0).ToString());
                }
            }

            //Calculate the sum
            string total2 = totalNum2.Sum().ToString();
            Console.WriteLine("Part 2: Total similarity score is " + total2 + " \n");

            #endregion
            break;

        case "2":
            Console.WriteLine("******** Day 2 - Advent of Code ********");
            #region Day 2



            #endregion
            break;

        default:

            break;
    }
}
else
    Console.WriteLine("Sorry, file not found :( ");