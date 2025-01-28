using Final;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Final
{
    public class SaveManager
    {
        public void SaveGame(string fileName, int playerX, int playerY, Inventory inventory, int[,] map, int[,] map2)
        {
            SaveData saveData = new SaveData();
            saveData.PlayerX = playerX;
            saveData.PlayerY = playerY;
            saveData.Inventory = inventory.GetItems(); // Envanteri kaydet
            saveData.Map = map; //Haritayı kaydet
            saveData.Map2 = map2; //İkinci haritayı kaydet


            string jsonString = JsonSerializer.Serialize(saveData);
            File.WriteAllText(fileName, jsonString);
        }


        public SaveData LoadGame(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<SaveData>(json);
            }
            return null;
        }
    }

    [Serializable]
    public class SaveData
    {
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public int[,] Map { get; set; } = new int[0, 0]; 
        public int[,] Map2 { get; set; } = new int[0, 0];
    }
}
