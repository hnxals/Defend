using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public int damage = 50;

    public GameObject bulletImpactEffect;

    public float explosionRaius = 0f;


    public void seek(Transform oldTarget)
    {
        target = oldTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (explosionRaius > 0f)
        {
            Explore();
        }
        else
        {
            Damage(target);
            
        }
        Destroy(gameObject);
           
    }
    
    void Explore()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRaius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "enemy")
            {
                
                Damage(collider.transform);

            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyMove e = enemy.GetComponent<EnemyMove>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, explosionRaius);
    }
}
