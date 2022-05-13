using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class Grabber : MonoBehaviour
{
    private GameObject _selectObject;
    private Vector3 _startPos;
    private Vector3 _pos;
    private GameObject otherGO;
    private GameObject _node;
    [SerializeField] public AllySO allySO;
    [SerializeField] bool isMerge = false;
    [SerializeField] bool isContact = false;


    private void Awake()
    {
        _startPos = transform.position;
       
    }

    private void Start()
    {
      //  transform.Rotate(0, 0, 0);
    }
    private void OnMouseDown()
    {
        if (_selectObject == null)
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null)
            {
                if (!hit.collider.CompareTag("Ally"))
                {
                    return;
                }

                _selectObject = hit.collider.gameObject;
                Cursor.visible = false;
            }
        }
    }

    private void OnMouseDrag()
    {
        if (_selectObject != null)
        {
            //if (transform.position.z < -1f)
            //{
            //    Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            //    Vector3 worldPosiiton = Camera.main.ScreenToWorldPoint(position);
            //    _selectObject.transform.position = new Vector3(worldPosiiton.x, .435f, worldPosiiton.z);
            //}
            //else
            //{
            //    //Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            //    //Vector3 worldPosiiton = Camera.main.ScreenToWorldPoint(position);
            //    //_selectObject.transform.position = _startPos;
            //}

            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectObject.transform.position).z);
            Vector3 worldPosiiton = Camera.main.ScreenToWorldPoint(position);
            _selectObject.transform.position = new Vector3(worldPosiiton.x, .435f, worldPosiiton.z);

        }
    }

    private void OnMouseUp()
    {
        if (_selectObject != null)
        {

            transform.position = new Vector3(_pos.x, .435f, _pos.z);
            _selectObject = null;
           // Debug.Log("Birakti");
            Cursor.visible = true;
            if (isMerge)
            {
                Merge();
                _selectObject = null;
                Cursor.visible = true;
            }
            if (isContact)
            {
                transform.position = new Vector3(_startPos.x, .435f, _startPos.z);
                _selectObject = null;
                Cursor.visible = true;
            }
            else
            {
                _startPos = transform.position;
            }

        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Node)
        {
            _pos = other.gameObject.transform.position;
            _node = other.gameObject;
        }
        if (gameObject.tag == other.tag)
        {
            isContact = true;
            if (allySO.levelID == other.gameObject.GetComponent<Grabber>().allySO.levelID)
            {
                if (allySO.allyEnum == other.gameObject.GetComponent<Grabber>().allySO.allyEnum)
                {
                    isMerge = true;
                    otherGO = other.gameObject;
                    isContact = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Node)
        {
          //  node = null;
        }

        if (gameObject.tag == other.tag)
        {
            isMerge = false;
            otherGO = null;
            isContact = false;
        }
    }

    void Merge()
    {
        EventManager.GamePlayAllyMerge(allySO.allyEnum, allySO.levelID, otherGO, gameObject,otherGO.transform.parent); 
    }
}

