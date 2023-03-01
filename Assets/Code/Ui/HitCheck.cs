using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private Image HpBar;

    private void OnEnable()
    {
        EventBus.hit += ChengeAfterHit;
    }

    private void OnDisable()
    {
        EventBus.hit -= ChengeAfterHit;
    }

    private void ChengeAfterHit(GameObject gameO)
    {
        if (gameO == gameObject)
        {
            HpBar.fillAmount -= 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
