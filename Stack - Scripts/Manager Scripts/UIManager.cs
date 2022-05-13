using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DorukEvents;


public class UIManager : MonoBehaviour
{
    public enum CanvasEnum
    {
        playButton,
        failPanel,
        successPanel
    }
    public CanvasEnum canvasEnum;

    [SerializeField] UISO uISO;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject successPanel;
    [SerializeField] Text levelCountText;
    private void OnEnable()
    {
        EventManager.GameStart += SetPlayButton;
        EventManager.GameSuccess += SetSuccessPanel;
        EventManager.GameLevelCount += SetLevelCount;
    }

    private void OnDisable()
    {
        EventManager.GameStart -= SetPlayButton;
        EventManager.GameSuccess -= SetSuccessPanel;
        EventManager.GameLevelCount -= SetLevelCount;

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
        levelCountText.text = "LEVEL\n" + value.ToString();
    }

}
