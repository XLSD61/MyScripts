using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Constans;

public class Draggable : MonoBehaviour
{
    [SerializeField] public int cartID;
    [SerializeField] GameObject[] carts;
    [SerializeField] GameObject[] soldiers;
    [SerializeField] Image image;
    GameObject otherCart;
    bool startDrag;
    [SerializeField] bool inUse = false;
    Vector2 startPos;
    Vector2 slotPos;
    Vector3 difference;



    private void Start()
    {
        startPos = transform.position;
    }


    private void Update()
    {
        if (startDrag)
        {
            transform.position = Input.mousePosition;
        }
    }


    public void StartDrag()
    {
        startDrag = true;
       // difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    }

    public void StopDrag()
    {
        startDrag = false;
        if (inUse)
        {
            transform.position = slotPos;
            GameObject go = Instantiate(carts[cartID], transform.position, Quaternion.identity);
            go.transform.SetParent(transform.parent);
            Destroy(gameObject);
            Destroy(otherCart);
        }
        else
        {
            transform.position = startPos;
            //image.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == collision.tag)
        {
            inUse = true;
            slotPos = collision.transform.position;
           // Debug.Log("Býraktý");
            otherCart = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == collision.tag)
        {
            inUse = false;
        }
        if (collision.tag == Tags.Deck)
        {
            difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            //Debug.LogWarning("Deck Area Exit");
            image.enabled = false;
          //  GameObject soldier = Instantiate(soldiers[cartID -1], Camera.main.ScreenToWorldPoint(Input.mousePosition - difference), Quaternion.identity);
            GameObject soldier = Instantiate(soldiers[cartID -1], new Vector3(0,0.61f,0), Quaternion.identity);
        }
    }
}

