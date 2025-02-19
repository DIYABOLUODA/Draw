using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DrawCardSystem;
using SaveSystem;
using Tool;
using Unity.VisualScripting;
using UnityEngine;

namespace SaveSystem
{
    public class FileDataService 
    {
        private string filePath;
        private string fileExtension;
        private JsonSerializer jsonSerializer;
        public FileDataService(JsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
            filePath = Application.persistentDataPath;
            fileExtension = "json";
        }
        private string GetPathToFile(string fileName)
        {
            return Path.Combine(filePath, string.Concat(fileName, ".", fileExtension));
        }
        private string GetLatestAccessGameDataFile()
        {
          return Directory.EnumerateFiles(filePath, "*.json", SearchOption.TopDirectoryOnly).OrderByDescending(File.GetLastAccessTime).FirstOrDefault();
        }
        public bool HasFile(string dataName)
        {
            string path = GetPathToFile(dataName);
            Say.say("----------------------" + path + "-----------------------", MessagesColor.yellow);
            return File.Exists(path);
        }
        public bool HasFile(out string dataName)
        {
            dataName = Path.GetFileNameWithoutExtension(GetLatestAccessGameDataFile());
            Say.say(dataName,MessagesColor.Blue);
            return !string.IsNullOrEmpty(dataName);
        }
        public bool HasFile()
        {
            return !string.IsNullOrEmpty(Path.GetFileNameWithoutExtension(GetLatestAccessGameDataFile()));
        }
        public void Save(GameData gameData)
        {
            string path = GetPathToFile(gameData.dataName);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
          string dataToJson = jsonSerializer.Serialize(gameData, true);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(dataToJson);
                }
            }
        }
        public GameData Load(string dataName)
        {
            string path = GetPathToFile(dataName);
            Say.say(path,MessagesColor.Blue);
            if (!File.Exists(path))
            {
                throw new ArgumentException();
            }
            using(FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(fileStream))
                {
                    return jsonSerializer.Deserialize<GameData>(reader.ReadToEnd());
                }
            }
        }
    }
}
