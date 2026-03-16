using FluentAssertions;
using RestWithASPNet10.Data.Converter.Impl;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Model;

namespace RestWithASPNet10.Tests
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        // PersonDTO to Person conversion tests
        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            // Arrange: prepare the data, objects, and dependencies required for the test
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male"
            };

            // Act: execute the method or functionality under test
            var person = _converter.Parse(dto);

            // Assert: verify that the expected results matches the expected outcome
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonDTOIsNull()
        {
            PersonDTO dto = null;

            var person = _converter.Parse(dto);
            person.Should().BeNull();
        }

        // Person < PersonDTO conversion tests
        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {
            // Arrange: prepare the data, objects, and dependencies required for the test
            var entity = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male",
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male"
            };

            // Act: execute the method or functionality under test
            var person = _converter.Parse(entity);

            // Assert: verify that the expected results matches the expected outcome
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Should().BeEquivalentTo(expectedPerson);
            person.BirthDay.Should().NotBeNull();
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonIsNull()
        {
            Person dto = null;

            var person = _converter.Parse(dto);
            person.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertListOfPersonDTOToListOfPerson()
        {
            // Arrange: prepare the data, objects, and dependencies required for the test
            var dtos = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandan - India",
                    Gender = "Male",
                    BirthDay = new DateTime(1869, 10, 2)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    BirthDay = new DateTime(1917, 11, 19)
                }
            };

            // Act: execute the method or functionality under test
            var personList = _converter.ParseList(dtos);

            // Assert: verify that the expected results matches the expected outcome
            personList.Should().NotBeNull();
            personList.Should().HaveCount(dtos.Count);

            personList[0].Should().BeEquivalentTo(new Person { 
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male",
            });

            personList[1].Should().BeEquivalentTo(new Person
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female",
            });

            personList[0].FirstName.Should().Be("Mahatma");
            personList[0].LastName.Should().Be("Gandhi");
            personList[0].Address.Should().Be("Porbandan - India");
            personList[0].Gender.Should().Be("Male");

            personList[1].FirstName.Should().Be("Indira");
            personList[1].LastName.Should().Be("Gandhi");
            personList[1].Address.Should().Be("Allahabad - India");
            personList[1].Gender.Should().Be("Female");
        }

        [Fact]
        public void Parse_NullListPersonDTOSShouldReturnNull()
        {
            List<PersonDTO> dto = null;

            var listPerson = _converter.ParseList(dto);
            listPerson.Should().BeNull();
        }
    }
}
