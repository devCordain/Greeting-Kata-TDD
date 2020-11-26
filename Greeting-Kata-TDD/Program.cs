using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greeting_Kata_TDD
{
    public class Program
    {
        string latestGreeting;
        Dictionary<int, string[]> favouriteGreetings = new Dictionary<int, string[]>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void Greet(string[] input)
        {
            var parsedNamesList = GetParsedNamesList(input);
            var response = ComposeResponse(parsedNamesList);
            latestGreeting = response;
            Console.WriteLine(response);
        }

        public void Greet(string input)
        {
            if(input == "repeat")
            {
                Console.WriteLine(latestGreeting);
            }
        }

        public void Greet(int index)
        {
            if (favouriteGreetings.ContainsKey(index))
            {
                var parsedNamesList = GetParsedNamesList(favouriteGreetings[index]);
                var response = ComposeResponse(parsedNamesList);
                latestGreeting = response;
                Console.WriteLine(response);
            }
        }

        public void Greet(int index, string[] input)
        {
            if (favouriteGreetings.ContainsKey(index))
            {
                favouriteGreetings[index] = input;
                Console.WriteLine($"Greeting updated on position {index}");
            }
            else
            {
                favouriteGreetings.Add(index, input);
                Console.WriteLine($"Greeting saved on position {index}");
            }
        }

        private static string ComposeResponse(List<string> inputList)
        {
            if (inputList.Count == 0) 
                inputList = new List<string> { "my friend" };

            var upperCaseNamesExist = false;
            var sbUpperCase = new StringBuilder();
            var sb = new StringBuilder();

            if (inputList.Count > 1)
            {
                foreach (var name in inputList)
                {
                    if (name.All(x => Char.IsUpper(x)))
                    {
                        sbUpperCase.Append("AND HELLO " + name + "!");
                        upperCaseNamesExist = true;
                    }
                    else
                    {
                        sb.Append(name);
                        if (name == inputList[inputList.Count - 2] && inputList.Count > 2 && upperCaseNamesExist)
                        {
                            sb.Append(" and ");
                        }
                        else if (name == inputList[inputList.Count - 2] && inputList.Count > 2)
                        {
                            sb.Append(", and ");
                        }
                        else if (name == inputList[inputList.Count - 2])
                        {
                            sb.Append(" and ");
                        }
                        else if (name != inputList.Last())
                        {
                            sb.Append(", ");
                        }
                    }
                }
            }
            else
            {
                sb.Append(inputList[0]);
            }

            if (inputList.Count == 1 && inputList[0].All(x => Char.IsUpper(x)))
                return $"HELLO {sb}!";
            else if (upperCaseNamesExist)
                return $"Hello, {sb}. {sbUpperCase}";
            else
               return $"Hello, {sb}.";
        }

        private static List<string> GetParsedNamesList(string[] input)
        {
            var inputList = new List<string>();
            if(input == null || input.Length == 0) return inputList;
            foreach (var name in input)
            {
                var splitNames = name.Split(",").ToList();
                if (splitNames.Count < 1)
                {
                    foreach (var splitName in splitNames)
                    {
                        inputList.Add(splitName);
                    }
                }
                else
                {
                    inputList.Add(name);
                }
            }

            return inputList;
        }
    }
}
