using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAttack : EnemyStateMachine
{
    public float attackDelay = 1f;

    public override void OnEnterState()
    {
        _controler.PlayAnimation("Punch");
        _controler.PlaySound(stateSound);
    }

    public override void OnUpdateState()
    {
        attackDelay -= Time.deltaTime;

        if (attackDelay < 0)
        {
            attackDelay = 1f;
            _player.Hit(_controler.GetDamage());
            _controler.ChangeState<EnemyStateIdle>();
        }
    }

    public override void OnExitState()
    {

    }

}

