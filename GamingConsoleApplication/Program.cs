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
                case "D":
                    break;
                default: break;
            }
        }
        while (!input.Equals("X"));
    }

}
