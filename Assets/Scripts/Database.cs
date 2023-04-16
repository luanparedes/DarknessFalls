using System;
using System.Data;
using Mono.Data.SqliteClient;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Device;

public class Database : MonoBehaviour
{
    private static string urlDataBase = $"URI=file:{UnityEngine.Application.dataPath}/DarknessFallsSQLite.db";

    public static void CreatePlayer(string namePlayer, int level, int hp, int mp, int speed, int jumpForce)
    {
        string sql = $"INSERT INTO player(id, name, level, hp, mp, speed, jump_force) VALUES(1, '{namePlayer}', {level}, {hp}, {mp}, {speed}, {jumpForce})";

        ExecuteSQL(sql);
    }

    public static void UpdatePlayer(int level, int hp, int mp, int speed, int jumpForce)
    {
        string sql = "UPDATE player " +
                     $"SET level = {level}, hp = {hp}, mp = {mp}, speed = {speed}, jump_force = {jumpForce} " +
                     "WHERE id = 1";

        ExecuteSQL(sql);
    }

    public static void LoadPlayerInfo(Player player)
    {
        string sql = "SELECT level, hp, mp, speed, jump_force FROM player WHERE id = 1";

        using (SqliteConnection _connection = new SqliteConnection(urlDataBase))
        {
            _connection.Open();

            using (SqliteCommand command = new SqliteCommand(sql, _connection))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player.level = reader.GetInt32(0);
                        player.hp = reader.GetInt32(1);
                        player.mp = reader.GetInt32(2);
                        player.speed = reader.GetInt32(3);
                        player.jumpForce = reader.GetInt32(4);
                    }
                }
            }
        }
    }

    private static void ExecuteSQL(string sql)
    {
        using (IDbConnection _connection = new SqliteConnection(urlDataBase))
        {
            _connection.Open();

            using (IDbCommand _command = _connection.CreateCommand())
            {
                _command.CommandText = sql;
                _command.ExecuteNonQuery();
            }
        }
    }
}
