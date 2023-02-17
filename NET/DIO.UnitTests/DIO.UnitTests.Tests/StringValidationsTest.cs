using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.UnitTests.Tests
{
    public class StringValidationsTest
    {
        private StringValidations _validation = new StringValidations();

        [Fact]
        public void ShouldReturn6QuantitiesCharactersFromTheWordMatrix()
        {
            //Arrange
            var text = "Matrix";
            var expectedResult = 6;

            // Act
            var result = _validation.ReturnQuantityCharacters(text);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldContainsTheWordAnyInTheText()
        {
            //Arange
            var text = "Esse é um texto qualquer";
            var searchText = "qualquer";

            //Act
            var result = _validation.ContainsCharacter(text, searchText);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void NoShouldContainsTheWordTesteInTheText()
        {
            //Arange
            var text = "Esse é um texto qualquer";
            var searchText = "teste";

            //Act
            var result = _validation.ContainsCharacter(text, searchText);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TextShouldEndsWithTheProcuradoWord()
        {
            //Arrange
            var text = "Começo, meio e fim do texto procurado";
            var searchText = "procurado";

            //Act
            var result = _validation.TextEndsWith(text, searchText);

            //Assert
            Assert.True(result);
        }
    }
}