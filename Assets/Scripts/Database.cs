using System;
using System.Data;
using Mono.Data.SqliteClient;
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

    private static void ExecuteSQL(string sql)
    {
        IDbConnection _connection = new SqliteConnection(urlDataBase);
        IDbCommand _command = _connection.CreateCommand();

        _connection.Open();

        _command.CommandText = sql;
        _command.ExecuteNonQuery();

        _connection.Close();
    }
}
