using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private GuiPointerListener listenerAttackButton;
    [SerializeField] private GuiPointerListener listenerAttackSpeedButton;
    [SerializeField] private GuiPointerListener listenerHpButton;
    [SerializeField] private int upgradeValueAttack;
    [SerializeField] private int upgradeValueAttackPrice;
    [SerializeField] private float upgradeValueAttackSpeed;
    [SerializeField] private int upgradeValueAttackSpeedPrice;
    [SerializeField] private int upgradeValueHp;
    [SerializeField] private int upgradeValueHpPrice;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text attackSpeedText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text currencyText;

    private Game _game;

    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GuiPointerListener listenerRestart;
    [SerializeField] private GuiPointerListener listenerQuit;

    private void OnEnable()
    {
        EventBus.updateCurrencyValue += CurrencyUpdate;
        EventBus.updateUiValue += UpdateUi;
        EventBus.endGame += ShowEndScreen;
    }

    private void OnDisable()
    {
        EventBus.updateCurrencyValue -= CurrencyUpdate;
        EventBus.updateUiValue -= UpdateUi;
        EventBus.endGame -= ShowEndScreen;
    }

    private void Awake()
    {
        _game = Game.Get();
        listenerAttackButton.OnClick += data => { AttackUpgrade(); };
        listenerAttackSpeedButton.OnClick += data => { AttackSpeedUpgrade(); };
        listenerHpButton.OnClick += data => { HpUpgrade(); };
        listenerRestart.OnClick += data => { SceneManager.LoadScene(0); };
        listenerQuit.OnClick += data => { Application.Quit(); };
    }

    void Start()
    {
        
    }

    private void ShowEndScreen()
    {
        EndScreen.SetActive(true);
        _game.isPause = true;
    }

    private void AttackUpgrade()
    {
        
        if(_game.GetSoftCurrency() >= upgradeValueAttackPrice)
        {
            _game.RemoveSoftCurrency(upgradeValueAttackPrice);
            EventBus.GetUpdateDamage(upgradeValueAttack);
            CurrencyUpdate();
        }
    }

    private void AttackSpeedUpgrade()
    {
        if(_game.GetSoftCurrency() >= upgradeValueAttackSpeedPrice)
        {
            _game.RemoveSoftCurrency(upgradeValueAttackSpeedPrice);
            EventBus.GetUpdateAttackSpeed(upgradeValueAttackSpeed);
            CurrencyUpdate();
        }
    }

    private void HpUpgrade()
    {
        if(_game.GetSoftCurrency() >= upgradeValueHpPrice)
        {
            _game.RemoveSoftCurrency(upgradeValueHpPrice);
            EventBus.GetUpdateHp(upgradeValueHp);
            CurrencyUpdate();
        }
    }

    private void CurrencyUpdate()
    {
        currencyText.text = _game.GetSoftCurrency().ToString();
    }

    private void UpdateUi(int attack, float attackSpeed,int hp)
    {
        attackText.text = attack.ToString();
        attackSpeedText.text = attackSpeed.ToString();
        hpText.text = hp.ToString();
    }
}
