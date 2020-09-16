using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using System.Linq;

namespace M.Challenge.UnitTests.Config.AutoData
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute() : base(() =>
        {
            var fixture = new Fixture();

            fixture.Behaviors
                .Add(new OmitOnRecursionBehavior());

            fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));

            return fixture.Customize(new AutoNSubstituteCustomization());
        })
        {
        }
    }
}
