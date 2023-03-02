using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateDeath : EnemyStateMachine
{    
    private float deathTimer = 1f;

    public override void OnEnterState()
    {
        _controler.PlayAnimation("Death");
        _game.AddSoftCurrency(10);
    }

    public override void OnUpdateState()
    {
        deathTimer -= Time.deltaTime;

        if (deathTimer < 0)
        {            
            Destroy(gameObject);
            EventBus.GetEnemyDie();
        }
    }

    public override void OnExitState()
    {

    }

    


}
