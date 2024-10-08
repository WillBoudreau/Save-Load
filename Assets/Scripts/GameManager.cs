using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Script call
    public static GameManager GameMan;
    public LevelManager LevelManager;
    //Varaiables
    public int GameManCount;
    public TextMeshProUGUI GameManNum;
    public float health;
    public float score;
    public float Xp;
    public int level;
    public float damage;
    public float Intelligence;
    public float Stealth;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject levelManagerObject = GameObject.Find("LevelManager");
        if (levelManagerObject != null)
        {
            LevelManager = levelManagerObject.GetComponent<LevelManager>();
        }
        else
        {
            Debug.LogError("LevelManager object not found!");
        }
    
        if(GameMan == null)
        {
            DontDestroyOnLoad(this.gameObject);
            GameMan = this;
        }
        else if (GameMan != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Find the number of GameManager objects in the scene
        GameManCount = FindObjectsOfType<GameManager>().Length;
        KeyInput();
        UpdateNumofGameMan();
    }
    void UpdateNumofGameMan()
    {
        GameManNum.text = "" + GameManCount;
        GameManCount = FindObjectsOfType<GameManager>().Length;
    }
    //Save method
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
        
        PlayerData data = new PlayerData();
        data.health = health;
        data.score = score;
        data.Xp = Xp;
        data.level = LevelManager.levelList.IndexOf(LevelManager.currentLevel);
        data.damage = damage;
        data.Intelligence = Intelligence;
        data.Stealth = Stealth;

        bf.Serialize(file, data);
        file.Close();
    }
    //Load method
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            score = data.score;
            Xp = data.Xp;
            level = data.level;
            damage = data.damage;
            Intelligence = data.Intelligence;
            Stealth = data.Stealth;
        }
    }
    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LevelManager.LoadLevel(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LevelManager.LoadLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LevelManager.LoadLevel(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LevelManager.LoadLevel(3);
        }
    }
    [System.Serializable]
    class PlayerData
    {
        public float health;
        public float score;
        public float Xp;
        public int level;
        public float damage;
        public float Intelligence;
        public float Stealth;
    }
}
