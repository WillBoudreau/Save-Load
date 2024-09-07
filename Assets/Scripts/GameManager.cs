using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Script call
    public static GameManager GameMan;
    //Varaiables
    public float health;
    public float score;
    public float Xp;
    public float level;
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
}
