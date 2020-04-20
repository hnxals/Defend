using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject difficultUI;
    public GameObject guidenceUI;
    public GameObject AboutUI;
    public AudioClip clickSound;
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        mainUI.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        difficultUI.SetActive(true);
    }

    public void Guidence()
    {
        mainUI.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        guidenceUI.SetActive(true);
    }
    public void About()
    {
        mainUI.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        AboutUI.SetActive(true);
    }
    public void QuitGame()
    {
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        Application.Quit();
    }

    public void BackFromAbout()
    {
        AboutUI.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        mainUI.SetActive(true);
    }

    public void BackFromGuidence()
    {
        guidenceUI.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        mainUI.SetActive(true);
    }

    public void BackFromDifficult()
    {
        difficultUI.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        mainUI.SetActive(true);
    }

    public void Easy()
    {
        PlayerStatus.difficult = 0;
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }
    public void Normal()
    {
        PlayerStatus.difficult = 1;
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }
    public void Hard()
    {
        PlayerStatus.difficult = 2;
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }
    public void OneLife()
    {
        PlayerStatus.difficult = 3;
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }
}
