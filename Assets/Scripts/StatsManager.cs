using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI XpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + GameManager.GameMan.health;
        XpText.text = "Xp: " + GameManager.GameMan.Xp;
    }
    public void HealthUp()
    {
        GameManager.GameMan.health += 10;
    }
    public void HealthDown()
    {
        GameManager.GameMan.health -= 10;
        if(GameManager.GameMan.health < 0)
        {
            GameManager.GameMan.health = 0;
        }
    }
    public void XpUp()
    {
        GameManager.GameMan.Xp += 10;
    }
    public void XpDown()
    {
        GameManager.GameMan.Xp -= 10;
    }
}
