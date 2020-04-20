using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static int health;
    public static int money;
    public int startMoney = 400;
    public int startHealth = 20;
    public Text moneyText;
    public Text healthText;
    public static int waves;
    public static int difficult;

    void Start()
    {
        money = startMoney;
        if(difficult == 0)
            health = startHealth;
        if (difficult == 1)
            health = 15;
        if (difficult == 2)
            health = 10;
        if (difficult == 3)
            health = 1;
    }
    void Update()
    {
        moneyText.text = "$:" +  money.ToString();
        healthText.text = "❤:" + health.ToString();
    }

}
