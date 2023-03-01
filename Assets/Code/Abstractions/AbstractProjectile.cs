using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class AbstractProjectile : MonoBehaviour
{
    protected LayerMask layerMaskContactGroupEnemy;
    protected LayerMask layerMaskContactGroupPlayer;
    private Collider2D _contactCollider;
    protected Animator animator;
    [SerializeField] protected private int damage;
    [SerializeField] protected private float speed;

    void Start()
    {
        layerMaskContactGroupEnemy = LayerMask.GetMask("Enemy");
        layerMaskContactGroupPlayer = LayerMask.GetMask("Player");
        
    }

    
    void Update()
    {
        onUpdate();
    }

    protected private virtual void onUpdate() { }

    protected private void Contact(Collider collider)
    {
        collider.GetComponent<TakenDamage>().Hit(damage);
    }
}
