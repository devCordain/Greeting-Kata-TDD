using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greeting_Kata_TDD;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Greet_Should_print_a_greeting_with_Name()
        {
            //Arrange
            var program = new Program();
            var input = new string[] { "Andreas" };
            var expected = "Hello, " + input[0] + "." + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_print_general_greeting_When_input_is_Null()
        {
            //Arrange
            var program = new Program();
            string[] input = null;
            var expected = "Hello, my friend." + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_print_all_uppercase_When_input_is_all_uppercase()
        {
            //Arrange
            var program = new Program();
            var input = new string[] { "TOMMY" };
            var expected = "HELLO " + input[0] + "!" + Environment.NewLine; 
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_print_all_names_When_input_is_an_array_of_two_names()
        {
            //Arrange
            var program = new Program();
            var input = new string[] { "Tommy", "Andreas" };
            var expected = $"Hello, {input[0]} and {input[1]}.{Environment.NewLine}";
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_print_all_names_When_input_is_an_array_of_more_than_two_names()
        {
            //Arrange
            var program = new Program();
            var input = new string[] { "Tommy", "Andreas", "Tarzan", "Megatron", "crabby" };
            var expected = $"Hello, {input[0]}, {input[1]}, {input[2]}, {input[3]}, and {input[4]}." + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_print_separate_greeting_for_upper_case_names()
        {
            //Arrange
            var program = new Program();
            var input = new string[] { "Tommy", "Andreas", "CRABPEOPLE", "Megatron", "Tarzan" };
            var expected = $"Hello, {input[0]}, {input[1]}, {input[3]} and {input[4]}. AND HELLO {input[2]}!" + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_repeat_lastest_greeting_when_input_is_repeat()
        {
            //Arrange
            var program = new Program();
            var input = new string[] { "Tommy", "Andreas", "CRABPEOPLE", "Megatron", "Tarzan" };
            var inputRepeat = "repeat";
            var expected = $"Hello, {input[0]}, {input[1]}, {input[3]} and {input[4]}. AND HELLO {input[2]}!" + Environment.NewLine + $"Hello, {input[0]}, {input[1]}, {input[3]} and {input[4]}. AND HELLO {input[2]}!" + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(input);
            program.Greet(inputRepeat);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }


        [TestMethod]
        public void Greet_Should_save_a_greeting_and_reply_with_saved_when_prefixed_by_an_index()
        {
            //Arrange
            var program = new Program();
            var inputInt = 1;
            var inputString = new string[] { "Tommy", "Andreas", "CRABPEOPLE", "Megatron", "Tarzan" };
            var expected = $"Greeting saved on position {inputInt}" + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(inputInt, inputString);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_save_a_greeting_and_reply_with_updated_when_prefixed_by_an_index()
        {
            //Arrange
            var program = new Program();
            var inputInt = 1;
            var inputString = new string[] { "Tommy", "Andreas", "CRABPEOPLE", "Megatron", "Tarzan" };
            var expected = $"Greeting saved on position {inputInt}" + Environment.NewLine + $"Greeting updated on position {inputInt}" + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(inputInt, inputString);
            program.Greet(inputInt, inputString);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Greet_Should_repeat_a_saved_greeting_with_matching_index()
        {
            //Arrange
            var program = new Program();
            var inputInt = 1;
            var inputString = new string[] { "Tommy", "Andreas", "CRABPEOPLE", "Megatron", "Tarzan" };
            var expected = $"Greeting saved on position {inputInt}" + Environment.NewLine + $"Hello, {inputString[0]}, {inputString[1]}, {inputString[3]} and {inputString[4]}. AND HELLO {inputString[2]}!" + Environment.NewLine;
            var sw = new StringWriter();
            Console.SetOut(sw);
            //Act
            program.Greet(inputInt, inputString);
            program.Greet(inputInt);
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}
