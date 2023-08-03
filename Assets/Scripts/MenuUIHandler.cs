using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = $"Best Score : {ScoreManager.Instance.bestPlayerName} : {ScoreManager.Instance.highScore}";
        nameInput.text = ScoreManager.Instance.currentPlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
