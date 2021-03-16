using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IDamageable
{

    GameManager gm;
    public float velocity;

    private void Start() {
        gm = GameManager.GetInstance();
    }

    private void FixedUpdate()
    {
        if(gm.pontos <= 100) {
            velocity = 0.0f;
        } else if( gm.pontos > 100 && gm.pontos <= 400 ) {
            velocity = 0.5f;
        } else if (gm.pontos > 400 && gm.pontos <= 1200) {
            velocity = 0.75f;
        } else
        {
            velocity = 1.0f;
        }
        Thrust(-velocity, 0.0f);
    }

    public void TakeDamage() {
        Die();
    }

    public void Die() {
        Destroy(gameObject);
    }


}
