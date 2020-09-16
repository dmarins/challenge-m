using AutoFixture.Idioms;
using FluentAssertions;
using M.Challenge.Domain.Entities;
using M.Challenge.UnitTests.Config.AutoData;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace M.Challenge.UnitTests.Domain.Entities
{
    public class PeopleTests
    {
        [Theory, AutoNSubstituteData]
        public void Sut_ShouldGuardItsClauses(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(Person).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public void AddChild_WhenPersonHasOneChild_ReturnsPersonWithChildren(Person sut, Person child)
        {
            var previousPerson = new Person(
                sut.Name,
                sut.LastName,
                sut.Ethnicity,
                sut.Filiation,
                sut.EducationLevel);

            var previousChild = new Person(
                child.Name,
                child.LastName,
                child.Ethnicity,
                child.Filiation,
                child.EducationLevel);

            sut.AddChild(child);

            sut
                .Should()
                .BeEquivalentTo(previousPerson, config => config.Excluding(x => x.Children));

            sut.Children
                .Should()
                .HaveCount(1);

            sut.Children
                .First()
                .Should()
                .BeEquivalentTo(previousChild);
        }

        [Theory, AutoNSubstituteData]
        public void AddChild_WhenPersonHasTwoOrMoreChildren_ReturnsPersonWithTwoOrMoreChildren(Person sut, List<Person> children)
        {
            var firstPreviousChild = new Person(
                children[0].Name,
                children[0].LastName,
                children[0].Ethnicity,
                children[0].Filiation,
                children[0].EducationLevel);

            for (int i = 0; i < children.Count; i++)
            {
                sut.AddChild(children[i]);
            }

            sut.Children
                .Should()
                .HaveCount(3);

            sut.Children
                .First()
                .Should()
                .BeEquivalentTo(firstPreviousChild);
        }

        [Theory, AutoNSubstituteData]
        public void AddChild_WhenPersonHasOneGrandchild_ReturnsPersonWithGrandchild(Person sut, Person child, Person grandchild)
        {
            var sonWithGrandchild = child.AddChild(grandchild);
            sut.AddChild(sonWithGrandchild);

            sut.Children
                .Should()
                .HaveCount(1);

            sut.Children
                .First()
                .Children
                .Should()
                .HaveCount(1);
        }
    }
}
