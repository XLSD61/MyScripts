using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "MagnoliaGames/UI/UISO")]
public class UISO : ScriptableObject
{
  //  public GameObject UIRoot;
    public Canvas canvas;
    public GameObject playButton;
    public GameObject failPanel;
    public GameObject successPanel;
    public Text levelCountText;
}
