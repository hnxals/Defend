using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text wavesText;

    void OnEnable()
    {
        wavesText.text = PlayerStatus.waves.ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
