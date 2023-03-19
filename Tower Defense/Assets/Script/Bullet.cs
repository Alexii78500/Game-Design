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
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Destroy(Instantiate(impact, transform.position, transform.rotation), 2f);
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
