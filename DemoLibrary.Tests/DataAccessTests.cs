using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Tim", LastName = "Corey" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Tim", "", "LastName")]
        [InlineData("", "Corey", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldWork()
        {
            List<PersonModel> people = new List<PersonModel> { new PersonModel{ FirstName = "Tim", LastName = "Corey" }, new PersonModel { FirstName = "Nikol", LastName = "Corey" } };
            List<string> output = new List<string>();

            output= DataAccess.ConvertModelsToCSV(people);

            Assert.True(output.Count == 2);
            Assert.Contains<string>("Tim,Corey", output);
        }
        [Theory]
        [InlineData(null)]
        public void ConvertModelsToCSV_ShouldFail(PersonModel person)
        {
            List<PersonModel> people = new List<PersonModel> { person };

            Assert.Throws<NullReferenceException>(() => DataAccess.ConvertModelsToCSV(people));

        }
    }
}
