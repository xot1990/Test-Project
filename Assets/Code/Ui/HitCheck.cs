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
    private int Hp;

    private void OnEnable()
    {
        EventBus.hit += ChengeAfterHit;
        Hp = GetComponent<AbstractUnit>().GetMaxHp(); 
    }

    private void OnDisable()
    {
        EventBus.hit -= ChengeAfterHit;
    }

    private void ChengeAfterHit(GameObject gameO,int value )
    {
        if (gameO == gameObject)
        {
            float amountValue = (float)value / Hp ;
            Debug.Log(amountValue);
            HpBar.fillAmount -= amountValue;
            GameObject Hit = Instantiate(hitCount, matherObjectForHitCount.transform);
            Hit.GetComponent<TMP_Text>().text = value.ToString();
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
