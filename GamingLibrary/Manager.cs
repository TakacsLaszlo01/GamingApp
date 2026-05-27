using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingLibrary;
public abstract class Manager
{
    private MySqlConnection connection;
    protected Manager(string address, string database, int port,
                       string user, string password = "")
    {
        string connectionString = $"Data Source={address}; Initial Catalog={database}; Port={port}; User ID={user}; Password={password}; SslMode=none";
        connection = new MySqlConnection(connectionString);
    }
    protected MySqlConnection Connection
    {
        get { return connection; }
        set { connection = value; }
    }
}
