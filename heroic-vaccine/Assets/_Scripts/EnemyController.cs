using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject tiro;
    GameManager gm;

    public void Shoot()
    {
      Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {       
        gm = GameManager.GetInstance();
        Destroy(gameObject);
        gm.pontos+=100;
    }
}
