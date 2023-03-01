using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : AbstractUnit
{
    
    private bool dead;

    private void OnEnable()
    {
        dead = false;
    }

    void Start()
    {        
        ChangeState<PlayerStateIdle>();
    }

    
    void Update()
    {
        if (!_game.isPause)
        {
            state.OnUpdateState();
        }

        if (hp <= 0 && !dead)
        {
            ChangeState<PlayerStateDeath>();
            dead = true;
        }

    }

}
