using System;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine;
using UnityEngine.Device;

public class Database : MonoBehaviour
{
    private static string urlDataBase = $"URI=file:C:/Users/luans/OneDrive/Área de Trabalho/Developer/Softwares/Unity/DarknessFalls/Assets/DarknessFallsSQLite.db";

    public static void CreatePlayer(string name, int level, int hp, int mp, int speed, int jumpForce)
    {
        IDbConnection _connection = new SqliteConnection(urlDataBase);
        IDbCommand _command = _connection.CreateCommand();

        _connection.Open();

        string sql = $"INSERT INTO player(name, level, hp, mp, speed, jump_force) VALUES({name}, {level}, {hp}, {mp}, {speed}, {jumpForce})";
        
        _command.CommandText = sql;
        _command.ExecuteNonQuery();

        _connection.Close();
    }
}
