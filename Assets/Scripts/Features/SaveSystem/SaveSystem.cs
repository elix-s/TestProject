using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static void SaveCounter(int counter)
    {
        File.WriteAllText(SavePath, counter.ToString());
    }

    public static int LoadCounter(int defaultValue)
    {
        if (File.Exists(SavePath))
        {
            if (int.TryParse(File.ReadAllText(SavePath), out int savedValue))
            {
                return savedValue;
            }
        }
        
        return defaultValue;
    }
}