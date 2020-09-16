using System;
using System.Collections.Generic;
using System.Linq;

namespace M.Challenge.Domain.Entities
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Ethnicity { get; set; }
        public string Filiation { get; set; }
        public IEnumerable<Person> Children { get; set; }
        public string EducationLevel { get; set; }

        public Person(string name,
            string lastName,
            string ethnicity,
            string filiation,
            string educationLevel)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Ethnicity = ethnicity ?? throw new ArgumentNullException(nameof(ethnicity));
            Filiation = filiation ?? throw new ArgumentNullException(nameof(filiation));
            EducationLevel = educationLevel ?? throw new ArgumentNullException(nameof(educationLevel));
        }

        public Person AddChild(Person child)
        {
            var person = new Person(
                child.Name,
                child.LastName,
                child.Ethnicity,
                child.Filiation,
                child.EducationLevel);

            if (child.Children != null
                && child.Children.Any())
            {
                person.Children = child.Children;
            }

            Children = Children.Concat(new[] { person });

            return this;
        }
    }
}
