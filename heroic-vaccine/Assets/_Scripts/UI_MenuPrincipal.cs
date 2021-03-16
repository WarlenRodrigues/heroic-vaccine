using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_MenuPrincipal : MonoBehaviour
{

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Comecar()
    {
        gm.vidas = 10;
        gm.pontos = 0;
        gm.ChangeState(GameManager.GameState.GAME);
    }
}