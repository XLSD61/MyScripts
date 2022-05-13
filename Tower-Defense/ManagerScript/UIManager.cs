using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using DorukEvents;


public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject successPanel;
    [SerializeField] Text levelCountText;
    [SerializeField] Text enemyCount;
    [SerializeField] Slider healhSlider;
    [SerializeField] Image healhSliderRect;
    [SerializeField] Image igloIcon;
    [SerializeField] GameObject DeckPanel;
    [SerializeField] GameObject[] slot;
    private void OnEnable()
    {
        EventManager.GameStart += SetPlayButton;
        EventManager.GameSuccess += SetSuccessPanel;
        EventManager.GameLevelCount += SetLevelCount;
        EventManager.GameHealthSlider += HealthSlider;
        EventManager.GameAlignCart += AlignCart;
        EventManager.GameEnemyCount += SetEnemyCount;
    }

    private void OnDisable()
    {
        EventManager.GameStart -= SetPlayButton;
        EventManager.GameSuccess -= SetSuccessPanel;
        EventManager.GameLevelCount -= SetLevelCount;
        EventManager.GameHealthSlider -= HealthSlider;
        EventManager.GameAlignCart -= AlignCart;
        EventManager.GameEnemyCount -= SetEnemyCount;
    }

    public void SetPlayButton(bool value)
    {
        playButton.SetActive(value);
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

    public void SetEnemyCount(int value)
    {
        enemyCount.text = value.ToString();
    }

    public void HealthSlider()
    {
        healhSlider.value -= 1;
        IgloIconAnim();
        if (healhSlider.value == 0)
        {
            // EventManager.GamePlayFail();
          //  Debug.LogError("!!!!!!!!!!!!!!");
        }
    }

    public void AlignCart(int k, RectTransform cart)
    {
        GameObject cartPrefab =  Instantiate(cart.gameObject, slot[k].transform.position, Quaternion.identity);
        cartPrefab.transform.SetParent(DeckPanel.transform);
    } 


    void IgloIconAnim()
    {
       // igloIcon.DOColor(Color.red, .15f).OnComplete(() => igloIcon.DOColor(Color.white,.15f));
        healhSlider.transform.DOScale(Vector3.one * 1.25f,.15f).OnComplete(() => healhSlider.transform.DOScale(Vector3.one, .15f));
        if (healhSlider.value < healhSlider.maxValue/2)
        {
            if (healhSlider.value < healhSlider.maxValue / 4)
            {
                healhSliderRect.DOColor(Color.red, .15f);
            }
            else
            {
                healhSliderRect.DOColor(Color.yellow, .15f).OnComplete(() => healhSliderRect.DOColor(Color.green, .15f));
            }
          
        }
        else
        {
            healhSliderRect.DOColor(Color.red, .15f).OnComplete(() => healhSliderRect.DOColor(Color.green, .15f));
        }
      
    }
     
}
