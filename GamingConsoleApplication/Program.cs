using GamingLibrary;

namespace GamingConsoleApplication;
internal class Program
{
    static void Main(string[] args)
    {
        GameManager gm = new GameManager();
        List<Game> games = gm.GetGames();
        for (int i = 0; i < games.Count; i++)
            Console.WriteLine($"{games[i].Id:00}: {games[i]}");

        string input;
        do
        {
            Console.WriteLine("Válasszon az alábbi műveletek közül:\nI - beszúrás\nD - törlés\nU - módosítás\nX - kilépés");
            input = Utils.Input("Válasszon műveletet: ").ToUpper();
            switch(input)
            {
                case "I": InsertGame();
                    break;
                default: break;
            }
        }
        while (!input.Equals("X"));
    }
    private static void InsertGame()
    {
        int id, ageLimit;
        string title;
        DateTime release;

        while (!int.TryParse(Utils.Input("Adjon meg egy sorszámot:"), out id))
            Console.WriteLine("Pozitív egészet adjon meg!");
        title = Utils.Input("Adja meg a játék címét: ");

        int year, month, day;
        while(!int.TryParse(Utils.Input("Adja meg a megjelenés évét:"), out year) && year <= 1970)
            Console.WriteLine("1970 utáni évszámot adjon meg!");

        while (!int.TryParse(Utils.Input("Adja meg a hónapot:"), out month) && (month < 1 || month > 12))
            Console.WriteLine("1 és 12 közötti számot adjon meg!");

        while (!int.TryParse(Utils.Input("Adja meg a napot:"), out month) && (month < 1 || month > 12))
            Console.WriteLine("1 és 31 közötti számot adjon meg!");
    }
}
