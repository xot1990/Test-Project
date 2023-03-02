using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : PlayerStateMachine
{
    

    public override void OnEnterState()
    {
        Instantiate(_controler.projectile, transform);
    }

    public override void OnUpdateState()
    {
        _controler.ChangeState<PlayerStateIdle>();
    }

    public override void OnExitState()
    {

    }

}

