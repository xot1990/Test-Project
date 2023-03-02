using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDeath : PlayerStateMachine
{    
    private float deathTimer = 1f;

    public override void OnEnterState()
    {
        _controler.PlayAnimation("DeathAnimation");
    }

    public override void OnUpdateState()
    {
        deathTimer -= Time.deltaTime;

        if (deathTimer < 0)
        {
            EventBus.GetEndGame();
        }
    }

    public override void OnExitState()
    {

    }

    


}
