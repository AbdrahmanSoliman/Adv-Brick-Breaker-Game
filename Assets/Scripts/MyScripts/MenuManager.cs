using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName;
    public int bestScoreee;

    public string bestPlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestPlayer();
    }

    private void Update()
    {
        if(SceneLoader.isChanged) // To exectue the inside code one time (when we click start/ load scene) as we are putting it in Update() function
        {
            playerName = MenuUIHandler.playerName;
            bestScoreee = MainManager.bestScore;
        }

    }


    [System.Serializable]

    class SaveData
    {
        public string bestPlayerName;
        public int bestScoreee;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestScoreee = bestScoreee;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.bestPlayerName;
            bestScoreee = data.bestScoreee;
        }
    }
}
