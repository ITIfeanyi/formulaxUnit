using FormulaApp.Api.Models;

namespace FormulaApp.UnitTests.Fixtures;

public class FansFixtures
{
    public static List<Fan> GetFans() => new()
    {
        new Fan()
        {
            Email = "ifeanyi@gmail.com",
            Id = 1,
            Name = "Ifeanyi igweh"
        },
        new Fan()
        {
            Email = "chi@gmail.com",
            Id = 2,
            Name = "Chisom igweh"
        }
    };

}