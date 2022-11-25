using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int difficultyRamp = 1;
    int currentHealth = 0;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHealth = maxHealth;
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    
    void ProcessHit()
    {
        currentHealth--;
        if (currentHealth < 1)
        {
            gameObject.SetActive(false);
            enemy.Reward();
            maxHealth += difficultyRamp;
        }
    }

}
