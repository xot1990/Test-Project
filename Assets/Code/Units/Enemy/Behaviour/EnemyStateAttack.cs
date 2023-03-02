using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAttack : EnemyStateMachine
{
    private float attackDelay = 1f;
    private Collider[] contactGroup;
    private bool oneDo;

    public override void OnEnterState()
    {
        _controler.PlayAnimation("Punch");
        oneDo = true;
    }

    public override void OnUpdateState()
    {
        attackDelay -= Time.deltaTime;

        if(attackDelay < 0.4f && oneDo)
        {
            oneDo = false;
            _controler.PlaySound(stateSound);
            _player.Hit(_controler.GetDamage());
            contactGroup = Physics.OverlapSphere(transform.position, checkRadius, _game.layerMaskPlayer);

            foreach (var P in contactGroup)
            {
                EventBus.GetHit(P.gameObject, _controler.GetDamage());
            }
        }

        if (attackDelay < 0)
        {
            attackDelay = 1f;
            _controler.ChangeState<EnemyStateIdle>();
            
        }
    }

    public override void OnExitState()
    {
        oneDo = true;
    }

}

