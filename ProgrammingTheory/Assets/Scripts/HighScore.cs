using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class HighScore : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI highScoreUI;
    private int _score;

    private void Start()
    {
        
        LoadData();
        highScoreUI.SetText("MAX TREASURE OPEN: " + _score);
       
    }

    [System.Serializable]
    class SaveHighScore
    {
        
        public int score;
    }

    public void SaveData(int score)
    {
        SaveHighScore data = new SaveHighScore();

        
        data.score = score;
        if (data.score > _score)
        {
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveHighScore data = JsonUtility.FromJson<SaveHighScore>(json);

            
            _score = data.score;
        }
    }
}
