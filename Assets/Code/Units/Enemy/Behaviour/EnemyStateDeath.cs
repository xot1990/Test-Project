using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateDeath : EnemyStateMachine
{    
    private float deathTimer = 1f;

    public override void OnEnterState()
    {        
        _controler.gameObject.layer = 16;
        
    }

    public override void OnUpdateState()
    {
        if (!_game.isPause)
        {
            deathTimer -= Time.deltaTime;

            if (deathTimer < 0)
            {
                _controler.gameObject.layer = 7;
                gameObject.SetActive(false);
            }
        }
    }

    public override void OnExitState()
    {

    }

    


}
