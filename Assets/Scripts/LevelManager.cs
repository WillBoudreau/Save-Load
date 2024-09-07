using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class LevelManager : MonoBehaviour
{
    //Script call
    public static LevelManager LevelMan;
    //Varaiables
    public string currentLevel;

    public string NextLevel;

    public string PreviousLevel;

    public string sceneName;

    public int SceneCount;

    public List<string> levelList;

    public TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        //Add all levels to list
        levelList = new List<string>();
        SceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < SceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            sceneName = System.IO.Path.GetFileNameWithoutExtension(path);
            levelList.Add(sceneName);
        }
        levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Display current level name
        currentLevel = SceneManager.GetActiveScene().name;
        levelText.text = currentLevel;
        // currentLevel = GameManager.GameMan.level;
    }
    public void LoadNextLevel()
    {
        
        NextLevel = levelList[levelList.IndexOf(currentLevel) + 1];
       SceneManager.LoadScene(NextLevel);
    }
    public void LoadPreviousLevel()
    {
        PreviousLevel = levelList[levelList.IndexOf(currentLevel) - 1];
        SceneManager.LoadScene(PreviousLevel);
    }
}