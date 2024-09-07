using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string currentLevel;

    public string NextLevel;

    public string PreviousLevel;

    public string sceneName;

    public int SceneCount;

    public List<string> levelList;

    // Start is called before the first frame update
    void Start()
    {
        levelList = new List<string>();
        SceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < SceneCount; i++)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(i).name);
            sceneName = SceneManager.GetSceneByBuildIndex(i).name;
            levelList.Add(sceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }
    public void LoadNextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
        NextLevel = nextLevel;
    }
    public void LoadPreviousLevel(string previousLevel)
    {
        SceneManager.LoadScene(previousLevel);
    }
}
