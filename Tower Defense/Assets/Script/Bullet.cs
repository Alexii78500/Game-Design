using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impact;

    [Header("Bullet stats")]
    public float speed;
    public float radius;
    public int damage;

    public void Seek(Transform t)
    {
        target = t;
    }

    // Update is called once per frame
    void Update()
    {
        //No target -> destroy the bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        
        //Computing direction to the target
        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        //Target is hit
        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        //Move towards target
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        //Look at target
        transform.LookAt(target);
    }

    void HitTarget()
    {
        //Initialise boom
        Destroy(Instantiate(impact, transform.position, transform.rotation), 2f);
        
        //Damage zone depending on radius
        if (radius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Damage(Transform e)
    {
        EnemyController enemy = e.GetComponent<EnemyController>();
        enemy.TakeDamage(damage);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var c in colliders)
        {
            if (c.CompareTag("Enemy"))
            {
                Damage(c.transform);
            }
        }
    }
}
