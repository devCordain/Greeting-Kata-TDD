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
    }
}
