using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class AbstractProjectile : MonoBehaviour
{
    protected private LayerMask layerMaskContactGroupEnemy;
    protected private LayerMask layerMaskContactGroupPlayer;
    protected private Collider[] _contactCollider;
    protected private Animator animator;
    protected private AudioSource audioSource;
    [SerializeField] protected private int damage;
    [SerializeField] protected private float speed;
    [SerializeField] protected private AudioClip enterSound;
    [SerializeField] protected private Transform target;
    protected private Game _game;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _game = Game.Get();
        onAwake();
    }

    void Start()
    {
        onStart();        
    }

    
    void Update()
    {
        onUpdate();        
    }

    protected private virtual void onUpdate() { }
    protected private virtual void onStart()
    {
        layerMaskContactGroupEnemy = LayerMask.GetMask("Enemy");
        layerMaskContactGroupPlayer = LayerMask.GetMask("Player");
    }
    protected private virtual void onAwake() { }

    protected private void Contact(Collider collider)
    {
        collider.GetComponent<TakenDamage>().Hit(damage);
    }

    public void PlaySound()
    {
        audioSource.clip = enterSound;
        audioSource.Play();
    }
}
