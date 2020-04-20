using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour {

    public float startSpeed = 10f;
    public float startHealth = 100;
    private float health;
    public int rewardValue = 40;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;
    [HideInInspector]
    public float speed ;


    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth; 
        if(health <= 0)
        {
            EnemyDie();
        }
    }
    
    public void Slow(float slowValue)
    {
        speed = startSpeed * (1f - slowValue);
    }
    private void EnemyDie()
    {
        PlayerStatus.money += rewardValue;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Enemy_Generator.enemyAlives--;
        Destroy(gameObject);
    }

    void GetNextPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStatus.health--;
        Enemy_Generator.enemyAlives--;
        Destroy(gameObject);
    }

    
    void Start()
    {
        target = Waypoints.points[0];
        if (PlayerStatus.difficult == 0)
        {
            health = startHealth;
        }
        if (PlayerStatus.difficult == 1)
        {
            health = startHealth * 1.1f;
            startSpeed *= 1.1f;
        }
        if (PlayerStatus.difficult == 2|| PlayerStatus.difficult == 3)
        {
            health = startHealth * 1.3f;
            startSpeed *= 1.3f;
            rewardValue = (int)(rewardValue * 1.1f);
        }
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextPoint();
        }
        speed = startSpeed;
    }
}
