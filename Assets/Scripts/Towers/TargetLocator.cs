using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] float targetHeight;
    [SerializeField] float towerRange = 15f;
    [SerializeField] ParticleSystem projectiles;

    Transform target;
    bool isActive = false;


    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        if (target == null) { return; }

        float targetDistance = Vector3.Distance(transform.position, target.position);

        Vector3 newTarget = target.position;
        newTarget.y = targetHeight;  //angle change so that tower doesn't aim at enemy feet
        head.LookAt(newTarget);
        

        if(targetDistance < towerRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectiles.emission;
        emissionModule.enabled = isActive;
    }
}
