using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Enums;
//using DorukEvents;


public class UIManager : MonoBehaviour
{
    [SerializeField] UISO uISO;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject playImage;
    [SerializeField] GameObject sellPanel;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject successPanel;
    [SerializeField] Text levelCountText;
    [SerializeField] Text priceText;
    private void OnEnable()
    {
        EventManager.GameStart += SetPlayButton;
        EventManager.GameSuccess += SetSuccessPanel;
        EventManager.GameFail += SetFailPanel;
        EventManager.GameLevelCount += SetLevelCount;
        EventManager.GameAddMoney += AddMoney;
    }

    private void OnDisable()
    {
        EventManager.GameStart -= SetPlayButton;
        EventManager.GameSuccess -= SetSuccessPanel;
        EventManager.GameFail -= SetFailPanel;
        EventManager.GameLevelCount -= SetLevelCount;
        EventManager.GameAddMoney -= AddMoney;
    }

    private void Start()
    {
        priceText.text = uISO.priceValue.ToString();
    }

    public void SetPlayButton(bool value)
    {
        playButton.SetActive(value);
        playImage.SetActive(value);
        sellPanel.SetActive(value);
      // GameObject playbutton = Instantiate(uISO.playButton, transform.position, Quaternion.identity);
    }

    public void SetFailPanel(bool value)
    {
        failPanel.SetActive(value);
    }

    public void SetSuccessPanel(bool value)
    {
        successPanel.SetActive(value);
    }

    public void SetLevelCount(int value)
    {
      //  levelCountText.text = "LEVEL\n" + value.ToString();
    }

    public void StartFightButton()
    {
        EventManager.GamePlayTriggerActiveted();
        EventManager.GamePlayCamerePlayPos();
        EventManager.GamePlayAllyCount();
        SetPlayButton(false);
    }


    public void MeleeButton()
    {
        EventManager.GamePlayAlignAlly(AllyEnum.Melee);
        Purchase();
    }


    public void RangedButton()
    {
        EventManager.GamePlayAlignAlly(AllyEnum.Ranged);
        Purchase();
    }

    void Purchase()
    {
        uISO.priceValue -= 200;
        priceText.text = uISO.priceValue.ToString();
    }

    public void AddMoney()
    {
        uISO.priceValue += 100;
        priceText.text = uISO.priceValue.ToString();
    }

}
