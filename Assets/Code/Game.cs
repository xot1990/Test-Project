using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public GuiPointerListener start;
    public GameObject startScreen;
    public AudioSource audioSource;
    public AudioClip gameMuisic;
    public GameObject lvl;
    public GameObject checkPoint;
    public int currentEnemyCount;
    public int currentNumberPlatform;
    public Platform currentPlatform;

    public List<Platform> platforms;

    private int softCurrency = 100;

    public bool platformCanMove;

    protected override void OnCreateService()
    {
        Application.targetFrameRate = 60;
        start.OnClick += data => { isPause = false; startScreen.SetActive(false); };
        layerMaskEnemy = LayerMask.GetMask("Enemy");
        layerMaskGround = LayerMask.GetMask("Ground");
        layerMaskBoolet = LayerMask.GetMask("Boolet");
        layerMaskPlayer = LayerMask.GetMask("Player");
        EventBus.enemyDie += DieEnemy;
    }

    protected override void OnDestroyService()
    {
        EventBus.enemyDie -= DieEnemy;
    }

    private void Start()
    {
        EventBus.GetUpdateCurrency();
        currentPlatform = platforms[0];
    }

    private void Update()
    {
        if (platformCanMove)
            GetNextPlatform();
    }

    public int GetSoftCurrency()
    {
        return softCurrency;
    }

    public void AddSoftCurrency(int value)
    {
        softCurrency += value;
        EventBus.GetUpdateCurrency();
    }

    public void RemoveSoftCurrency(int value)
    {
        softCurrency -= value;
        softCurrency = Mathf.Clamp(softCurrency, 0, 1000000);
        EventBus.GetUpdateCurrency();
    }

    private void DieEnemy()
    {
        currentEnemyCount--;
        if (currentEnemyCount <= 0)
        {
            if(currentNumberPlatform + 1 >= platforms.Count)
            {
                EventBus.GetEndGame();
                return;
            }
            EventBus.GetStartMove();
            platformCanMove = true;
            currentPlatform = platforms[currentNumberPlatform + 1];
            currentEnemyCount = platforms[currentNumberPlatform + 1].enemyCount;
            currentNumberPlatform++;
        }
    }

    private void GetNextPlatform()
    {
        lvl.transform.Translate(-Vector3.forward * Time.deltaTime*3);
        if (currentPlatform.center.transform.position.z <= checkPoint.transform.position.z)
        {
            EventBus.GetStartMove();
            platformCanMove = false;
        }
    }
}
