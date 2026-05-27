namespace GamingLibrary;

public class Game
{
    public Game(int id, string title, DateTime release, int ageLimit)
    {
        Id = id;
        Title = title;
        Release = release;
        AgeLimit = ageLimit;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Release { get; set; }
    public int AgeLimit { get; set; }
    public override string ToString()
    {
        return $"{Title} - (megjelent: {Release:yyyy. MMMM dd}, korhatár: {AgeLimit})";
    }
    public override bool Equals(object? obj)
    {
        if (obj is Game game)
            return game.Title.Equals(Title) && game.Release.Equals(Release) &&
                   game.AgeLimit == AgeLimit;
        return false;
    }
}
