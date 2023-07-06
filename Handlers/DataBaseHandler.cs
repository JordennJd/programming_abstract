using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PersAcc.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace PersAcc.Handlers;

internal sealed class DataBaseHandler
{
    public static bool AddUser(IUser user)
    {
        if (!IsUserInDB(user))
        {
            RequestGenerator.INSERT(GetStringForINSERT(user), "Users(FirstName, LastName, Password, Email)");
        }
        return IsUserInDB(user);
    }
    
    public static bool IsEmailInDB(string Email)
    {
        if (RequestGenerator.SELECT("Email", "Users").Contains(Email))
            return true;
        else
            return false;

    }

    public static string GetPasswordPertainingToEmail(string Email)
    {
        return RequestGenerator.SELECT("Password", "Users", $"WHERE Email = '{Email}'")[0];
    }


    //Нужно реализовать изменение информации о пользователях в БД
    private static string GetStringForINSERT(IUser user)
    {
        if (user != null)
            return $"'{user.FirstName}','{user.LastName}','{user.Password}','{user.Email}'";

        return null;
    }
    private static bool IsUserInDB(IUser user)
    {
        if (RequestGenerator.SELECT("Email", "Users").Contains(user.Email.ToString()))
            return true;
        else
            return false;

    }

}


file sealed class RequestGenerator
{
    
    private static string ConnectionSTR;
    private static MySqlConnection conn;

    static RequestGenerator(){
        switch (Environment.MachineName)
        {
            case ("DESKTOP-AI7DA69"):
                ConnectionSTR = "server=localhost;user=root;database=myDataBase;password=123123";
                break;
            case ("MacBook-Air-Danil"): 
                ConnectionSTR = "server=localhost;user=root;database=PersAcc;password=lfybk2000";
                break;
                
        }
        conn= new MySqlConnection(ConnectionSTR);
    }

    public static void INSERT(string value, string TABLE_INFO)
    {
        conn.Open();
        new MySqlCommand($"INSERT INTO {TABLE_INFO} VALUES ({value})", conn).ExecuteScalar();
        conn.Close();
    }

    public static List<string> SELECT(string value, string table, string WHERE = "")
    {
        List<string> values = new List<string>();

        conn.Open();

        MySqlCommand SelectAllId = new MySqlCommand($"SELECT {value} FROM {table} {WHERE}", conn);
        MySqlDataReader reader = SelectAllId.ExecuteReader();

        while (reader.Read())
        {
            values.Add(reader[0].ToString());
        }
        conn.Close();

        return values;
    }

}