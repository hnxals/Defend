using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Generator : MonoBehaviour
{
    public static int enemyAlives = 0;
    public Transform enemy01;
    public Transform enemy02;
    public Transform enemy03;
    public Transform generatePoint;
    public float coolDownTime;
    private float countDown;
    private int waveIndex = 0;
    public Text waveNumberText;
    public Text waveCountNumber;

    void Start()
    {
        countDown = 2.5f;
        coolDownTime = 5.5f;
        waveIndex = 0;
        enemyAlives = 0;
    }

    void Update()
    {
        if(enemyAlives > 0)
        {
            return;
        }

        if(countDown <= 0){
            StartCoroutine(SpawnWave(Random.Range(0f, 0.2f)));
            countDown  = coolDownTime;
            return;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountNumber.text = "Next wave incoming: \n" + string.Format("{0:00.00}", countDown);
        waveNumberText.text = "Wave: " + Mathf.Floor(waveIndex).ToString();
    }

    IEnumerator SpawnWave(float sec){
        waveIndex++;
        PlayerStatus.waves++;
        for (int i = 0; i < waveIndex; i++)
        {
            GenerateEnemy01();
            yield return new WaitForSeconds(sec);
        }
        if (waveIndex % 2 == 0)
        {
            Debug.Log("02");
            for (int i = 0; i < waveIndex/2; i++)
            {
                GenerateEnemy02();
                yield return new WaitForSeconds(sec);
            }
        }
        if (waveIndex % 5 == 0)
        {
            Debug.Log("03");
            for (int i = 0; i < waveIndex / 5; i++)
            {
                GenerateEnemy03();
                yield return new WaitForSeconds(sec);
            }
        }

    }

    void GenerateEnemy01()
    {
        Instantiate(enemy01, generatePoint.position, generatePoint.rotation);
        enemyAlives++;
    }
    void GenerateEnemy02()
    {
        Instantiate(enemy02, generatePoint.position, generatePoint.rotation);
        enemyAlives++;
    }
    void GenerateEnemy03()
    {
        Instantiate(enemy03, generatePoint.position, generatePoint.rotation);
        enemyAlives++;
    }
}
