using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string bestPlayerName;
    public int highScore;

    public string currentPlayerName;

    public TMP_InputField nameInput;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveName()
    {
        currentPlayerName = nameInput.text;
        SaveToFile();
    }


    public void SaveHighScore(int score)
    {
        bestPlayerName = currentPlayerName;
        highScore = score;
        SaveToFile();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int highScore;
        public string currentPlayerName;
    }

    public void SaveToFile()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.highScore = highScore;
        data.currentPlayerName = currentPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Load successful");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            highScore = data.highScore;
            currentPlayerName = data.currentPlayerName;
        }
        else
        {
            bestPlayerName = string.Empty;
            highScore = 0;
            currentPlayerName = string.Empty;
        }
    }

    public void DeleteData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(Application.persistentDataPath + "/savefile.json");
            bestPlayerName = string.Empty;
            highScore = 0;
            currentPlayerName = string.Empty;
            SceneManager.LoadScene(0);
        }
    }
}
