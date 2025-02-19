using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using SaveSystem;
using DrawCardSystem;
namespace Manager 
{
    public class SaveLoadManager : Singletons<SaveLoadManager> 
    {
        FileDataService fileDataService;
        [SerializeField] public GameData gameData;
        protected override void Awake()
        {
            base.Awake();
            fileDataService = new FileDataService(new JsonSerializer());
            if(gameData == null)
            {
            GameDataDetection();
            }
        }
        private void GameDataDetection()
        {
            if (fileDataService.HasFile(out string dataname))
            {
                LoadGame(dataname);
            }
        }
        public void NewGame(string dataName = "data")
        {
            if (HasGameData(dataName))
            {
                LoadGame(dataName);
            }
            else
            {
            gameData = new GameData(dataName);
            SaveGame();
            }
        }
        public void SaveGame()
        {
            fileDataService.Save(gameData);
        }
        public void LoadGame(string dataName)
        {
            gameData = fileDataService.Load(dataName);
        }
        public void LoadLastestGame()
        {
            GameDataDetection();
        }
        public bool HasGameData(string dataName) => fileDataService.HasFile(dataName); 
        public bool HasGameData() => fileDataService.HasFile();
    }
}
