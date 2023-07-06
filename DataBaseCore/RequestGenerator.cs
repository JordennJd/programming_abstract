using System;
using MySql.Data.MySqlClient;
namespace DataBaseCore;

	sealed class RequestGenerator
	{

    private static string ConnectionSTR = "server=localhost;user=root;database=lol;password=lfybk2000";
    private static MySqlConnection conn = new MySqlConnection(ConnectionSTR);

    public static void INSERT(string VALUE, string TABLE_INFO)
    {
        conn.Open();
            new MySqlCommand($"INSERT INTO {TABLE_INFO} VALUES ({VALUE})", conn).ExecuteScalar();
        conn.Close();
    }

    public static List<string> SELECT(string VALUE, string TABLE, string WHERE = "")
    {
        List<string> VALUES = new List<string>();

        conn.Open();

        MySqlCommand SelectAllId = new MySqlCommand($"SELECT {VALUE} FROM {TABLE} {WHERE}", conn);
        MySqlDataReader reader = SelectAllId.ExecuteReader();

        while (reader.Read())
        {
            VALUES.Add(reader[0].ToString());
        }
        conn.Close();

        return VALUES;
    }

}

