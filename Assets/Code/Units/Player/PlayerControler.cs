using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : AbstractUnit
{
    public GameObject projectile;
    private bool dead;
    private bool isMove;

    private void OnEnable()
    {
        dead = false;
        EventBus.updateDamge += GetUpdateDamage;
        EventBus.updateHp += GetUpdateHp;
        EventBus.updateAttackSpeed += GetUpdateAttackSpeed;
        EventBus.playerStartMove += StartMove;
    }

    private void OnDisable()
    {
        EventBus.updateDamge -= GetUpdateDamage;
        EventBus.updateHp -= GetUpdateHp;
        EventBus.updateAttackSpeed -= GetUpdateAttackSpeed;
        EventBus.playerStartMove -= StartMove;
    }

    void Start()
    {        
        ChangeState<PlayerStateIdle>();
        EventBus.updateUiValue(damage, attackSpeed, hp);
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

    private void StartMove()
    {
        if (isMove)
        {
            isMove = false;
            PlayAnimation("Idle");
        }
        else
        {
            isMove = true;
            PlayAnimation("Walk");
        }
    }

    private void GetUpdateDamage(int value)
    {
        damage += value;
        EventBus.updateUiValue(damage, attackSpeed, maxHp);
    }

    private void GetUpdateHp(int value)
    {
        hp += value;
        maxHp += value;
        EventBus.updateUiValue(damage, attackSpeed, maxHp);
    }

    private void GetUpdateAttackSpeed(float value)
    {
        attackSpeed -= value / 10;
        attackSpeed = Mathf.Clamp(attackSpeed, 0.3f, 10);
        EventBus.updateUiValue(damage, attackSpeed, maxHp);
    }

}
