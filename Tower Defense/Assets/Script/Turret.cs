using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private EnemyController targetEnemy;

    [Header ("Attributes")]
    public float range = 15f;
    private float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    private Vector3 Orot;
    
    [Header("Turret")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    
    [Header("Laser")]
    public bool UseLaser;
    public LineRenderer line;
    public ParticleSystem LaserEffect;
    public ParticleSystem LaserImpact;
    private int damage = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);
        Orot = transform.rotation.eulerAngles;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestD = Mathf.Infinity;
        GameObject closestE = null;

        foreach (GameObject e in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
            if (distanceToEnemy < closestD)
            {
                closestD = distanceToEnemy;
                closestE = e;
            }
        }

        if (closestE != null && closestD < range)
        {
            target = closestE.transform;
            targetEnemy = target.GetComponent<EnemyController>();
        }
        else
        {
            target = null;
            targetEnemy = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (UseLaser && line.enabled)
            {
                line.enabled = false;
                LaserEffect.Stop();
                LaserImpact.Stop();
            }
            return;
        }

        LockTarget();
        if (UseLaser)
            Laser();

        else
        {
            if (fireCountDown < 0)
            {
                Shoot();
                fireCountDown = fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void LockTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(Orot.x, rotation.y, 0);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damage*Time.deltaTime);

        targetEnemy.Slow(0.5f);

        if (!line.enabled)
        {
            LaserEffect.Play();
            LaserImpact.Play();
            line.enabled = true;
        }
        
        var position = target.position;
        Vector3 dir = firePoint.position - position;
        Transform transform1;
        (transform1 = LaserImpact.transform).rotation = Quaternion.LookRotation(dir);
        transform1.position = position + dir.normalized;
        
        
        
        line.SetPosition(0, firePoint.position);
        line.SetPosition(1, position);
    }
}
