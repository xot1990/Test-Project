using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateMachine
{    
    [SerializeField]
    private float rangeAttackTimer = 3f;

   
    public override void OnEnterState()
    {
        
    }

    public override void OnUpdateState()
    {
        
    }

    public override void OnExitState()
    {
        rangeAttackTimer = 3f;
    }
}
