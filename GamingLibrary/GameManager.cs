using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
namespace GamingLibrary;

public class GameManager : Manager
{
    public GameManager() : base("localhost", "gaming", 3306, "root") {}
    public List<Game> GetGames()
    {
        List<Game> result = new List<Game>();
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT id, title, `release`, age_limit FROM games";

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Game game = new Game(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDateTime(2), //itt lehet hiba a dátummal
                        reader.GetInt32(3)
                    );
                result.Add(game);
            }
        }
        finally { Connection.Close(); }
        return result;
    }
    public bool InsertGame(int id, string title, DateTime release, int ageLimit)
    {
        bool hasInserted = false;
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO games (id, title, release, age_limit) VALUES (@id, @title, @release, @age_limit)";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@release", release);
            command.Parameters.AddWithValue("@age_limit", ageLimit);

            hasInserted = command.ExecuteNonQuery() > 0;
        }
        finally { Connection.Close(); }
        return hasInserted;
    }
    public bool InsertGame(Game game)
    {
        return InsertGame(game.Id, game.Title, game.Release, game.AgeLimit);
    }
    public bool DeleteGame(int id)
    {
        bool hasDeleted = false;
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM games WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);
            hasDeleted = command.ExecuteNonQuery() > 0;
        }
        finally { Connection.Close(); }
        return hasDeleted;
    }
    public bool UpdateGame(int id, string title, DateTime release, int ageLimit)
    {
        bool hasUpdated = false;
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "UPDATE games SET title = @title, release = @release, age_limit = @age_limit WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@release", release);
            command.Parameters.AddWithValue("@age_limit", ageLimit);

            hasUpdated = command.ExecuteNonQuery() > 0;
        }
        finally { Connection.Close(); }
        return hasUpdated;
    }
    public Game SelectGame(int id)
    {
        try
        {
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT id, title, release, age_limit FROM games WHERE id = @id";

            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string title = reader.GetString(1);
                DateTime release = reader.GetDateTime(2);
                int ageLimit = reader.GetInt32(3);

                return new Game(id, title, release, ageLimit);
            }
        }
        finally { Connection.Close(); }
        return null;
    }
}
