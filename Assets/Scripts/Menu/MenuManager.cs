using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text bestScoreMenu;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreMenu.text = "Best Score : " + GameManager.Instance.highScoreInGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNew()
    {
        GameManager.Instance.highScorePlayerName = inputField.text;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
