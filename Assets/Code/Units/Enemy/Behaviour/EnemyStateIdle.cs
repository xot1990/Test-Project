using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : EnemyStateMachine
{    
   
   
    public override void OnEnterState()
    {
        _controler.PlayAnimation("Idle");
    }

    public override void OnUpdateState()
    {
        if (Physics.OverlapSphere(transform.position, checkRadius, _game.layerMaskPlayer).Length > 0)
            _controler.ChangeState<EnemyStateAttack>();
    }

    public override void OnExitState()
    {
        
    }
}
