using System;
using System.Collections.Generic;

namespace M.Challenge.Domain.Entities
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Ethnicity { get; set; }
        public string Genre { get; set; }
        public ICollection<Person> Filiation { get; set; }
        public ICollection<Person> Children { get; set; }
        public string EducationLevel { get; set; }

        public Person(string name,
            string lastName,
            string ethnicity,
            string genre,
            string educationLevel)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Ethnicity = ethnicity ?? throw new ArgumentNullException(nameof(ethnicity));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            EducationLevel = educationLevel ?? throw new ArgumentNullException(nameof(educationLevel));
        }

        public Person AddFilliation(Person fatherOrMother)
        {
            Filiation.Add(fatherOrMother);

            return this;
        }

        public Person AddChild(Person sonOrDaughter)
        {
            Children.Add(sonOrDaughter);

            return this;
        }
    }
}
