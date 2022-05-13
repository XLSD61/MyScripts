using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;
    [SerializeField] private int _id;
    private Camera cam;

    private void OnEnable()
    {
        EventManager.GameUpdateHealthBar += UpdateHealthBar;
        EventManager.GameDeleteHealthBar += DeleteHealthBar;
    }

    private void OnDisable()
    {
        EventManager.GameUpdateHealthBar -= UpdateHealthBar;
        EventManager.GameDeleteHealthBar -= DeleteHealthBar;
    }
    void Start()
    {
        cam = Camera.main;
        _id = transform.parent.gameObject.GetComponent<SoldierControl>().id;
    }

    public void UpdateHealthBar(int ID, int health)
    {
        if (ID == _id)
        {
            _healthBarSprite.fillAmount =  (float)health / 100;
        }
        
    }

    public void DeleteHealthBar(int ID)
    {
        if (ID == _id)
        {
            gameObject.SetActive(false);
        }
    }

    
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(0,90,0));    
    }
}
