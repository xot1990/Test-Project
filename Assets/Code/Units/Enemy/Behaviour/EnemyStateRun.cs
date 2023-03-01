using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateRun : EnemyStateMachine
{

    private Vector3 runPos;
   
    public override void OnEnterState()
    {
        _controler.PlayAnimation("Run");
        runPos = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
    }

    public override void OnUpdateState()
    {
        transform.Translate(-(runPos - transform.position).normalized * Time.deltaTime * _controler.GetSpeed());

        if (Physics.OverlapSphere(transform.position, checkRadius, _game.layerMaskPlayer).Length > 0)
            _controler.ChangeState<EnemyStateAttack>();
    }

    public override void OnExitState()
    {
        
    }
}
