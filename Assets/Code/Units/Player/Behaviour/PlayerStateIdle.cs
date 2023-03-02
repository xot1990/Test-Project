using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateMachine
{
    private float attackCd;
   
    public override void OnEnterState()
    {
        attackCd = _controler.GetAttackSpeed();
    }

    public override void OnUpdateState()
    {
        attackCd -= Time.deltaTime;

        if(attackCd <= 0)
            if (Physics.OverlapSphere(transform.position, 7f, _game.layerMaskEnemy).Length > 0)
                _controler.ChangeState<PlayerStateAttack>();
    }

    public override void OnExitState()
    {
        attackCd = _controler.GetAttackSpeed();
    }
}
