using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHearing : MonoBehaviour
{
    [SerializeField] private Enemy enemy = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            enemy.state = Enemy.EnemyState.Chase;
            enemy.delayShot();
        }

    }
}
