using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidence : MonoBehaviour
{
    public Sprite[] mySprites;
    private int index;
    public Button nextBtn;
    public Button priviousBtn;
    public AudioClip soundClip;

    void Start()
    {
        index = 0;
        gameObject.GetComponent<Image>().sprite = mySprites[index];
    }

    public void ClickNext()
    {
        if (index == 4)
            return;

        gameObject.GetComponent<Image>().sprite = mySprites[++index];
        gameObject.GetComponent<AudioSource>().PlayOneShot(soundClip);
    }

    public void ClickPrevious()
    {
        if (index == 0)
            return;

        gameObject.GetComponent<Image>().sprite = mySprites[--index];
        gameObject.GetComponent<AudioSource>().PlayOneShot(soundClip);
    }

    void Update()
    {
        if (index == 0)
            priviousBtn.interactable = false;
        if (index == 4)
            nextBtn.interactable = false;
        nextBtn.interactable = true;
        priviousBtn.interactable = true;
    }
}
