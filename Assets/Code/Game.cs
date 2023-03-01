using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public sealed class Game : MonoBehaviourService<Game>
{
    public GameObject menu;
    public GameObject deadMenu;
    
    public bool isPause = false;

    public LayerMask layerMaskGround;
    public LayerMask layerMaskEnemy;
    public LayerMask layerMaskBoolet;
    public LayerMask layerMaskPlayer;

    public AudioSource audioSource;
    public AudioClip gameMuisic;
    
    protected override void OnCreateService()
    {
        ProjectileData.ProjectileList.Initialize();
        layerMaskEnemy = LayerMask.GetMask("Enemy");
        layerMaskGround = LayerMask.GetMask("Ground");
        layerMaskBoolet = LayerMask.GetMask("Boolet");
        layerMaskPlayer = LayerMask.GetMask("Player");
    }

    protected override void OnDestroyService()
    {       
        
    }

    void Start()
    {
        
    }
    
    void Update()
    {
       
    }
    
}
