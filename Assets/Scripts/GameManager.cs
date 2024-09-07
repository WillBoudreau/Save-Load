using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    //Script call
    public static GameManager GameMan;
    //Varaiables
    public float health;
    public float score;
    public float Xp;
    public string level;
    public float damage;
    // Start is called before the first frame update
    void Awake()
    {
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
        data.level = level;
        data.damage = damage;

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
        }
    }
    [System.Serializable]
    class PlayerData
    {
        public float health;
        public float score;
        public float Xp;
        public string level;
        public float damage;
    }
}
