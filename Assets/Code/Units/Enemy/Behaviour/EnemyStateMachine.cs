using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private protected EnemyControler _controler;
    private protected Game _game;
    private protected PlayerControler _player;
    [SerializeField] protected private AudioClip stateSound;
    private protected float checkRadius;

    private void Awake()
    {
        OnGetClass<EnemyControler>();
        _game = Game.Get();
        checkRadius = 0.8f;
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerControler>();
    }

    public void OnGetClass<T>() where T : EnemyControler
    {
        _controler = GetComponent<T>();
    }

    public override void OnEnterState()
    {
    }
    public override void OnUpdateState()
    {
    }
    public override void OnExitState()
    {
    }


}
