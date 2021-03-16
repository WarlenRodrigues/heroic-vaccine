﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolantRockSpawner : MonoBehaviour
{
    public GameObject rock;

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

            if (gm.pontos > 100 && gm.pontos <= 400)
            {
                nrocks = 3;
            }
            else if (gm.pontos > 400 && gm.pontos <= 1200)
            {
                nrocks = gm.pontos / 50;
            }
            else if (gm.pontos <= 1200)
            {
                nrocks = gm.pontos / 500;
            }
            else
            {
                nrocks = 0;
            }

            Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;

            for (int i = 0; i < nrocks; i++)
            {
                float rand1 = Random.Range(0.0f, 8.0f);
                float rand2 = Random.Range(0.0f, 8.0f);

                Vector3 posicao = posPlayer + new Vector3(10 + rand1, 4 - rand2);
                Instantiate(rock, posicao, Quaternion.identity, transform);
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