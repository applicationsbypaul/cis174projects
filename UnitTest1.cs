using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FirstWebResTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAgeCalc1()
        {
            //Arrange
            Person test = new Person();
            test.Name = "Paul Ford";
            test.BirthYear = 2000;
            int expected = 20;

            // Act
            int actual = test.CalculateAge();

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestAgeCalc2()
        {
            //Arrange
            Person test = new Person();
            test.Name = "Amy E";
            test.BirthYear = 1990;
            int expected = 30;

            // Act
            int actual = test.CalculateAge();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAgeCalc3()
        {
            //Arrange
            Person test = new Person();
            test.Name = "Trevor Miller";
            test.BirthYear = 1942;
            int expected = 78;

            // Act
            int actual = test.CalculateAge();

            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestAgeCalc4()
        {
            //Arrange
            Person test = new Person();
            test.Name = "Shane Blum";
            test.BirthYear = 0;
            int expected = 2020;

            // Act
            int actual = test.CalculateAge();

            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestAgeCalc5()
        {
            //Arrange
            Person test = new Person();
            test.Name = "Nolan Stratton";
            test.BirthYear = 1976;
            int expected = 44;

            // Act
            int actual = test.CalculateAge();

            //Assert
            Assert.Equal(expected, actual);

        }
    }

    internal class Person
    {
    
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter your name.")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Please enter the year that you were born in.")]
            [Range(1900, 2019, ErrorMessage = "Year of birth must be between 1900 and 2019")]
            public int? BirthYear { get; set; }

            public const int CurrentYear = 2020;

            /// <summary>
            /// Calculates the Age by 2020 DEC 31st
            /// </summary>
            /// <returns></returns>
            public int CalculateAge()
            {
                return CurrentYear - BirthYear.Value;
            }
        

    }
}
