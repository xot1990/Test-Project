using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    [SerializeField] private Image HpBar;
    [SerializeField] private GameObject hitCount;
    [SerializeField] private GameObject matherObjectForHitCount;
    private AbstractUnit perrent;


    private void OnEnable()
    {
        EventBus.hit += ChengeAfterHit;
        perrent = GetComponent<AbstractUnit>();
        EventBus.updateHp += UpdateHpBar;
    }

    private void OnDisable()
    {
        EventBus.hit -= ChengeAfterHit;
        EventBus.updateHp -= UpdateHpBar;
    }

    private void ChengeAfterHit(GameObject gameO,int value )
    {
        if (gameO == gameObject)
        {
            float amountValue = (float)value / perrent.GetMaxHp() ;
            HpBar.fillAmount -= amountValue;
            GameObject Hit = Instantiate(hitCount, matherObjectForHitCount.transform);
            Hit.GetComponent<TMP_Text>().text = value.ToString();
        }
    }

    private void UpdateHpBar(int value)
    {
        if (perrent.GetType() == typeof(PlayerControler))
        {
            float p = (float)perrent.GetHp() / perrent.GetMaxHp();
            Debug.Log(p);
            HpBar.fillAmount = p;
        }
    }

    private void Awake()
    {
        
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
