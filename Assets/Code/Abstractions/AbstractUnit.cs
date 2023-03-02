using System.Collections;
using System.Collections.Generic;
using TMPro;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class AbstractUnit : MonoBehaviour, TakenDamage
{
    [SerializeField] protected private int hp;
    [SerializeField] protected private int maxHp;
    [SerializeField] protected private int speed;
    [SerializeField] protected private float attackSpeed;
    [SerializeField] protected private int damage;

    [SerializeField] protected private StateMachine state;
    protected private AudioSource actionAudio;
    protected private Animator animator;
       

    protected private Game _game;
    protected private float damageDelay = 0;


    private void Awake()
    {
        onAwake();
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    protected private virtual void onAwake()
    {
        _game = Game.Get();

        animator = GetComponentInChildren<Animator>();
        actionAudio = GetComponent<AudioSource>();
    }

    public void ChangeState<T>() where T : StateMachine
    {
        if (state != null) state.OnExitState();
        state = GetComponent<T>();
        state.OnEnterState();
    }    

    public void PlayAnimation(string value)
    {
        animator.Play(value);
    }

    public void PlaySound(AudioClip clip)
    {
        actionAudio.clip = clip;
        actionAudio.Play();
    }
    
    
    public virtual void Hit(int value)
    {
        hp -= value;
    }

    protected private void Death()
    {
        Destroy(gameObject);
    }    
}
