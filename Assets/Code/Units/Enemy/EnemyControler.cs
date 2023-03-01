using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : AbstractUnit
{
    
    private bool dead;

    private void OnEnable()
    {
        dead = false;
    }

    void Start()
    {        
        ChangeState<EnemyStateIdle>();
    }

    
    void Update()
    {
        state.OnUpdateState();

        if (hp <= 0 && !dead)
        {
            ChangeState<EnemyStateDeath>();
            dead = true;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        ChangeState<EnemyStateRun>();
    }
}
