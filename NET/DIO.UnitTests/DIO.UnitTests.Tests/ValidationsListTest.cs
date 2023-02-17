using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.UnitTests.Tests
{
    public class ValidationsListTest
    {
        private ValidationsList _validations = new ValidationsList();

        [Fact]
        public void ShouldRemoverNegativesNumbersOfAList()
        {
            //Arrange
            var list = new List<int> { 5, -1, -8, 9 };
            var expectedResult = new List<int> { 5, 9 };

            //Act
            var result = _validations.RemoversNegativeNumbers(list);

            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void ShouldContainsTheNumber9AtList()
        {
            //Arrange
            var list = new List<int> { 5, -1, -8, 9 };
            var numberToSearch = 9;

            //Act
            var result = _validations.ListContainsCertainNumber(list, numberToSearch);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void NoShouldContainsTheNumber10AtList()
        {
            //Arrange
            var list = new List<int> { 5, -1, -8, 9 };
            var numberToSearch = 10;

            //Act
            var result = _validations.ListContainsCertainNumber(list, numberToSearch);

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void ShouldMultiplyTheElementsFromTheListBy2()
        {
            //Arrange
            var list = new List<int> { 5, 7, 8, 9 };
            var expectedResult = new List<int> { 10, 14, 16, 18 };

            //Act
            var listMultipliedBy2 = _validations.MultiplyListNumber(list, 2);


            //Assert
            Assert.Equal(expectedResult, listMultipliedBy2);

        }

        [Fact]
        public void ShouldReturn9AsTheLargestNumberInTheList()
        {
            // Arrange
            var list = new List<int> { 5, -1, -8, 9 };
            var expectedResult = 9;

            //Act
            var result = _validations.ReturnTheLargestNumberFromTheList(list);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturn8NegativeTheSmallestNumberInTheList()
        {
            //Arrange
            var list = new List<int> { 5, -1, -8, 9 };
            var expectedResult = -8;

            //Act
            var result = _validations.ReturnLowestNumberList(list);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}