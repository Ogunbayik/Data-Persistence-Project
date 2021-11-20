using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string highScorePlayerName;
    public int highScoreInGame;

    public Text gameTitle;
    public Text playerNameMenu;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        gameTitle = GameObject.Find("Title").GetComponentInChildren<Text>();
        playerNameMenu = GameObject.Find("Input").GetComponentInChildren<Text>();
        if(highScorePlayerName != "")
        {
            gameTitle.text = "COLORFUL BREAKS";
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    [System.Serializable]
    class Savedata
    {
        public string highScorePlayerName;
        public int highScoreInGame;
    }
    public void SaveHighScore(string playerName, int playerScore)
    {
        Savedata data = new Savedata();
        data.highScorePlayerName = playerName;
        data.highScoreInGame = playerScore;

        string json = JsonUtility.ToJson(data);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Savedata data = JsonUtility.FromJson<Savedata>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScoreInGame = data.highScoreInGame;
        }
    }
}
