using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private EnemyMove targetEnemy;
    public float range = 50f;
    public Transform rotatePart;
    public GameObject buttletPrefab;
    public Transform firePoint;
    public AudioClip bulletSound;
    private AudioSource myaudio;

    [Header("Bullet")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public Light laserLight;
    public int damageOverTime = 50;
    public float slowValue = 0.5f;
    public AudioClip laserSound;



    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearEnemy = enemy;
            }
        }

        if(nearEnemy != null && shortestDistance <= range)
        {
            target = nearEnemy.transform;
            targetEnemy = target.GetComponent<EnemyMove>();
        }
        else
        {
            target = null;
        }
    }

    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.1f);
        myaudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(target == null)
        {
            if (useLaser)
            {
                if (lineRenderer)
                {
                    lineRenderer.enabled = false;
                    laserLight.enabled = false;
                    laserEffect.Stop();
                }
            }
            return;
        } 

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                shoot();
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }

        
    }

    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowValue);
        myaudio.PlayOneShot(laserSound);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserLight.enabled = true;
            laserEffect.Play();
        }
            
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 direction = firePoint.position - target.position;
        laserEffect.transform.position = target.position + direction.normalized;
        laserEffect.transform.rotation = Quaternion.LookRotation(direction);
    }
    void shoot()
    {
        myaudio.PlayOneShot(bulletSound);
        GameObject bulletGo = (GameObject)Instantiate(buttletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
} 
