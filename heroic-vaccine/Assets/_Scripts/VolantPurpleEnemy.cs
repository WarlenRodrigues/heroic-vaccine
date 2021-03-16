using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolantPurpleEnemy : MonoBehaviour
{
    public GameObject ship;

    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
    }

    void Construir()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            int nrocks;

            if (gm.pontos <= 1000)
            {
                nrocks = 0;
            }
            else if (gm.pontos > 1000 && gm.pontos <= 2000)
            {
                nrocks = 3;
            }
            else if (gm.pontos > 2000 && gm.pontos <= 3500)
            {
                nrocks = gm.pontos / 800;
            }
            else if (gm.pontos > 3500 && gm.pontos <= 7000)
            {
                nrocks = gm.pontos / 1000;
            }
            else
            {
                nrocks = 10;
            }

            Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;

            for (int i = 0; i < nrocks; i++)
            {
                float rand1 = Random.Range(0.0f, 8.0f);
                float rand2 = Random.Range(0.0f, 8.0f);

                Vector3 posicao = posPlayer + new Vector3(10 + rand1, 4 - rand2);
                Instantiate(ship, posicao, Quaternion.identity, transform);
            }
        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            Construir();
        }
    }

}