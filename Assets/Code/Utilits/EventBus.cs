using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus 
{       
    public static Action<GameObject,int> hit;
    public static Action nextPlatform;
    public static Action<int> updateDamge;
    public static Action<int> updateHp;
    public static Action<float> updateAttackSpeed;
    public static Action<int, float, int> updateUiValue;
    public static Action updateCurrencyValue;
    public static Action enemyDie;
    public static Action endGame;
    public static Action playerStartMove;

    public static void GetStartMove()
    {
        playerStartMove?.Invoke();
    }

    public static void GetEndGame()
    {
        endGame?.Invoke();
    }

    public static void GetEnemyDie()
    {
        enemyDie?.Invoke();
    }

    public static void GetNextPlatform()
    {
        nextPlatform?.Invoke();
    }

    public static void GetUpdateCurrency()
    {
        updateCurrencyValue?.Invoke();
    }

    public static void GetUpdateUiValues(int attack, float attackSpeed, int hp)
    {
        updateUiValue?.Invoke(attack, attackSpeed, hp);
    }

    public static void GetUpdateDamage(int value)
    {
        updateDamge?.Invoke(value);
    }

    public static void GetUpdateHp(int value)
    {
        updateHp?.Invoke(value);
    }

    public static void GetUpdateAttackSpeed(float value)
    {
        updateAttackSpeed?.Invoke(value);
    }

    public static void GetHit(GameObject gameObject,int value)
    {
        hit?.Invoke(gameObject,value);
    }
}
