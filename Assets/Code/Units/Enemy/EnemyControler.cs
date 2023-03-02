using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : AbstractUnit
{
    
    private bool dead;
        

    void Start()
    {        
        ChangeState<EnemyStateIdle>();
    }

    
    void Update()
    {
        if (!_game.isPause)
        {
            state.OnUpdateState();
        }

        if (hp <= 0 && !dead)
        {
            dead = true;
            ChangeState<EnemyStateDeath>();
        }

    }

    
    private void OnTriggerStay(Collider other)
    {
        if (!_game.isPause)
        {
            ChangeState<EnemyStateRun>();
        }
        
    }
}
