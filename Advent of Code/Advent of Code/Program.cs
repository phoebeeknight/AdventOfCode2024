// See https://aka.ms/new-console-template for more information

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
                string[] numCodes = line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
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
                totalNum1.Add(Math.Abs(firstNums[i] - secondNums[i]));

            //Calculate the sum
            string total1 = totalNum1.Sum().ToString();
            Console.WriteLine("Part 1: Total distance is " + total1 + " \n");//2166959

            //Part 2

            //Calculate find the similarity score
            List<int> totalNum2 = new List<int>();
            foreach (int firstNum in firstNums)
            {
                var duplicates = secondNums.GroupBy(x => x)
               .Where (x => x.Key == firstNum)
               .Select(x => x.Count())
               .ToList();

                if (duplicates.Count > 0)
                    totalNum2.Add(firstNum * duplicates.First());
            }

            //Calculate the sum
            string total2 = totalNum2.Sum().ToString();
            Console.WriteLine("Part 2: Total similarity score is " + total2 + " \n");//23741109

            #endregion
            break;

        case "2":
            Console.WriteLine("******** Day 2 - Advent of Code ********");
            #region Day 2
           
            List<string> unsafeLines = new List<string>();

            //Part 1
            int safeReports1 = 0;
            bool IsSafe1 = false;
            foreach (string line in lines)
            {
                string[] numCodes = line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);               
                for (int i = 0; i < numCodes.Length; i++)
                {
                    if (i + 1 < numCodes.Length)
                    {
                        //find the differences
                        int differences = Math.Abs(int.Parse(numCodes[i]) - int.Parse(numCodes[i + 1]));

                        //makesure the differences gap is between 1-3
                        if (differences > 0 && differences <= 3)
                        {
                            int IsIncrease1 = 0;
                            int IsIncrease2 = 0;
                            if (i + 2 < numCodes.Length)
                            {
                                //0 = decrease, 1 = increase
                                IsIncrease1 = (int.Parse(numCodes[i]) > int.Parse(numCodes[i + 1]) ? 1 : 0);
                                IsIncrease2 = (int.Parse(numCodes[i + 1]) > int.Parse(numCodes[i + 2]) ? 1 : 0);

                                //find if it's continue decreaseing or increasing
                                IsSafe1 = (IsIncrease1 == IsIncrease2) ? true : false;
                            }
                        }
                        else
                            IsSafe1 = false;
                    }

                    if (!IsSafe1)
                        break;
                }

                //record how many safe reports
                if (IsSafe1)
                    safeReports1++;
                else
                    unsafeLines.Add(line);
            }

            Console.WriteLine("Part 1: Total Safe Reports is " + safeReports1.ToString() + " \n"); //559


            // Part 2
            int safeReports2 = 0;           
            foreach (string unsafeLine in unsafeLines)
            {
                bool IsSafe2 = false;
                int IsRemoved = 0;
                string[] numCodes = unsafeLine.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < numCodes.Length; i++)
                {
                    if (i + 1 < numCodes.Length)
                    {
                        //find the differences
                        int differences = Math.Abs(int.Parse(numCodes[i]) - int.Parse(numCodes[i + 1]));

                        //makesure the differences gap is between 1-3
                        if (differences > 0 && differences <= 3)
                        {
                            int IsIncrease1 = 0;
                            int IsIncrease2 = 0;
                            if (i + 2 < numCodes.Length)
                            {
                                //0 = decrease, 1 = increase
                                IsIncrease1 = (int.Parse(numCodes[i]) > int.Parse(numCodes[i + 1]) ? 1 : 0);
                                IsIncrease2 = (int.Parse(numCodes[i + 1]) > int.Parse(numCodes[i + 2]) ? 1 : 0);

                                //find if it's continue decreaseing or increasing
                                IsRemoved = (IsIncrease1 == IsIncrease2) ? + 0 : + 1;
                            }
                        }
                        else
                            IsRemoved++;
                    }

                    if (IsRemoved > 1)
                    {
                        IsSafe2 = false;
                        break;
                    }
                    else
                        IsSafe2 = true;
                }

                //record how many safe reports
                if (IsSafe2)
                    safeReports2++;
            }

            Console.WriteLine("Part 2: Total Safe Reports is " + (safeReports1 + safeReports2).ToString() + " \n"); //817

            #endregion
            break;

        default:

            break;
    }
}
else
    Console.WriteLine("Sorry, file not found :( ");