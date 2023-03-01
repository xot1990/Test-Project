using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : PlayerStateMachine
{
    private float attackDelay = 0.2f;

    public override void OnEnterState()
    {
        
    }

    public override void OnUpdateState()
    {
        if (!_game.isPause)
        {
            attackDelay -= Time.deltaTime;

            if (attackDelay < 0)
            {
                attackDelay = 0.2f;
                _controler.ChangeState<PlayerStateIdle>();
            }
        }
    }

    public override void OnExitState()
    {

    }

}

