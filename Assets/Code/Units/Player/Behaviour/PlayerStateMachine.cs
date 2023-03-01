using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private protected PlayerControler _controler;
    private protected Game _game;
    [SerializeField] protected private AudioClip stateSound;

    private void Awake()
    {
        OnGetClass<PlayerControler>();
        _game = Game.Get();
    }

    private void Start()
    {

    }

    public void OnGetClass<T>() where T : PlayerControler
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
