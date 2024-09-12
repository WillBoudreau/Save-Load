using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI XpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI damageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + GameManager.GameMan.health;
        XpText.text = "Xp: " + GameManager.GameMan.Xp;
        scoreText.text = "Score: " + GameManager.GameMan.score;
        damageText.text = "Damage: " + GameManager.GameMan.damage;
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
        if (GameManager.GameMan.Xp < 0)
        {
            GameManager.GameMan.Xp = 0;
        }
    }
    public void ScoreUp()
    {
        GameManager.GameMan.score += 10;
    }
    public void ScoreDown()
    {
        GameManager.GameMan.score -= 10;
        if (GameManager.GameMan.score < 0)
        {
            GameManager.GameMan.score = 0;
        }
    }
    public void DamageUp()
    {
        GameManager.GameMan.damage += 10;
    }
    public void DamageDown()
    {
        GameManager.GameMan.damage -= 10;
        if (GameManager.GameMan.damage < 0)
        {
            GameManager.GameMan.damage = 0;
        }
    }
}
