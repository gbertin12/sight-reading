using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using System;

public class GstBDD 
{
    private string dbName = "URI=file:Assets/DB/sqlite.db";
    // public Image test3;

    public List<Partition> GetAllPartition()
    {
        List<Partition> lesPartitions = new List<Partition>();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, compositor, workname, level, pathMp3File, tickspermesure, totaltime, nbmesure, nbnotes, pourcentflat, centroid, pathpartitionfiles FROM partitions";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Partition nvPartition = new Partition(Convert.ToInt16(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToInt16(reader[3]),
                                                                reader[4].ToString(), Convert.ToInt16(reader[5]), Convert.ToDouble(reader[6]), Convert.ToInt16(reader[7]),
                                                                Convert.ToInt16(reader[8]), Convert.ToDouble(reader[9]), Convert.ToInt16(reader[10]), reader[11].ToString());
                        lesPartitions.Add(nvPartition);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
        return (lesPartitions);
    }

    public Partition GetPartitionById(int id)
    {
        Partition unePartition;
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, compositor, workname, level, pathMp3File, tickspermesure, totaltime, nbmesure, nbnotes, pourcentflat, centroid, pathpartitionfiles FROM partitions WHERE id =" + id;
                using (IDataReader reader = command.ExecuteReader())
                {
                    
                    unePartition = new Partition(Convert.ToInt16(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToInt16(reader[3]),
                                                                reader[4].ToString(), Convert.ToInt16(reader[5]), Convert.ToDouble(reader[6]), Convert.ToInt16(reader[7]),
                                                                Convert.ToInt16(reader[8]), Convert.ToDouble(reader[9]), Convert.ToInt16(reader[10]), reader[11].ToString());

                    reader.Close();
                }
            }
            connection.Close();
        }
        return unePartition;
    }

    public List<Note> GetNotesByIdPartitions(int idPartition)
    {
        List<Note> lesNotes = new List<Note>();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT duration, midi, time, channel, ticks, mesure FROM notes WHERE idpartition =" + idPartition;


                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Note nvNote = new Note(Convert.ToDouble(reader[0]), Convert.ToInt16(reader[1]), Convert.ToDouble(reader[2]), Convert.ToInt16(reader[3]), Convert.ToInt16(reader[4]), Convert.ToInt16(reader[5]));
                        lesNotes.Add(nvNote);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
        return (lesNotes);
    }

    public void UpdateSetting(string settingName, string newValue)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE settings SET value = '" + newValue + "', lastchange = DATETIME() WHERE name ='" + settingName + "'";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public string GetSetting(string nameSetting)
    {
        string langue;
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT value FROM settings where name = '" + nameSetting + "'";

                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    langue = reader["value"].ToString();
                    reader.Close();
                }
            }
            connection.Close();
        }
        return (langue);
    }

    public List<Settings> getAllSettings()
    {
        List<Settings> settingsList = new List<Settings>();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, value, name, defaultvalue, statut, lastchange FROM settings";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Settings nvSetting = new Settings(Convert.ToInt16(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                        settingsList.Add(nvSetting);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
        return (settingsList);
    }

    public List<Images> getImagesByIdPartitions(int idPartition)
    {
        List<Images> imagesList = new List<Images>();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, idPartition, pathImage, position FROM images WHERE idPartition =" + idPartition;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Images nvImage = new Images(Convert.ToInt16(reader[0]), Convert.ToInt16(reader[1]), reader[2].ToString(), Convert.ToInt16(reader[3]));
                        imagesList.Add(nvImage);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
        return (imagesList);
    }

    public void resetSettings()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE settings SET value = defaultValue, lastChange = DATETIME()";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void insertScoreLevel(int module, int tempoScore, int nbErrors, int level, int idPartition, double accuracyScore)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT into score VALUES (NULL, DATETIME()," + module + ", " + tempoScore + ", " + nbErrors + ", " + level + ", " + idPartition + ", " + accuracyScore + ")";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void displayScore()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, day_played, module, tempo_score, nberrors, level, idpartition, accuracy_score from score";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Debug.Log("id : " + reader[0] + " dayPLayed : " + reader[1] + " module : " + reader[2] + "tempo_score : " + reader[3] + "nbError : " + reader[4]);
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
}
