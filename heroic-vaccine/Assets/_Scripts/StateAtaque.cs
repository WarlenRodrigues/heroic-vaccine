using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtaque : State
{

    SteerableBehaviour steerable;
    IShooter shooter;
    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    GameManager gm;



    public override void Awake()
    {
        gm = GameManager.GetInstance();

        base.Awake();

        Transition ToPatrulha = new Transition();
        ToPatrulha.condition = new ConditionDistGT(transform, GameObject.FindWithTag("Player").transform, 8.0f);
        ToPatrulha.target = GetComponent<StatePatrulha>();
        transitions.Add(ToPatrulha);

        steerable = GetComponent<SteerableBehaviour>();

        shooter = steerable as IShooter;
        if (shooter == null)
        {
            throw new MissingComponentException("Esse GameObject não implementa IShooter");
        }
    }

    public void Update()
    {

        if (gm.gameState != GameManager.GameState.GAME) return;

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
