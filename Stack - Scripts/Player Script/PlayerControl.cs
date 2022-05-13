using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using Constans;
using TMPro;
using Lean.Touch;
using Enums;
public class PlayerControl : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerSO playerSO;
    //[Header ("Speed")]
    //[SerializeField] float speed;
    //[SerializeField] float rotSpeed;
    [Header("doll")]
    [SerializeField] public Transform dollPos;
    [SerializeField] public GameObject dollGO;
    [SerializeField] public GameObject dollHolder;
    [SerializeField] public GameObject PO;
    [SerializeField] public GameObject doll;
    [Header("Game Area")]
    [SerializeField] public  GameObject gameArea;
    [Header("List")]
   public List<GameObject> stack = new List<GameObject>();

    [Header("Ticket")]
    [SerializeField] TextMeshPro ticketText;
    [SerializeField] int ticketValue = 2;
    float inputHorizontal;

    [Header("Mobil Coontrol")]
    Touch touch;
  //  [SerializeField] float speedModifier = 0.01f;

    [Header("Game control")]
    [SerializeField] public bool isEndRoad;

    void Start()
    {
        playerSO.ticketValue = 0;
        //  AdddollList(dollGO.transform.GetChild(0).gameObject);
        stack.Add(doll);
        ticketText.text = playerSO.ticketValue.ToString() + "$";
    }

    void FixedUpdate()
    {
        SetTransform();
        MobileTransform();

    }

    void SetTransform()
    {

        gameArea.transform.Translate(-transform.forward * playerSO.speed);

        inputHorizontal = Input.GetAxis("Horizontal");
        dollGO.transform.Translate(inputHorizontal * Time.deltaTime * playerSO.rotSpeed, 0, 0);
        DollListTransform();
 
    }

    void MobileTransform()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                   transform.position.x + touch.deltaPosition.x * playerSO.mobilRotSpeed,
                    transform.position.y,
                    transform.position.z);
                DollListTransform();
            }
        }
    }

   

    void TicketNewValue()
    {
        ticketValue+=2;
        ticketText.text = ticketValue.ToString();
    }

    public void SetUpgradeTicketValue(int value)
    {
        playerSO.ticketValue += value;
        ticketText.text = playerSO.ticketValue.ToString() + "$";
        // Debug.Log("Money : " + ticketValue);
    }

    public void SetDollNewPos(float value)
    {
        dollPos.position = new Vector3(dollPos.position.x, dollPos.position.y, dollPos.position.z+value);
    }
    public void HandDollParent(GameObject go)
    {
        go.transform.SetParent(dollHolder.transform);
    }

    public void AdDdollList(GameObject go)
    {
        go.transform.DOKill();
       // EventManager.GamePlayGirlAnim(GirlAnim.Walk,stack[stack.Count].gameObject.GetComponent<DollController>().id);
        stack.Add(go);
        stack[stack.Count-1].transform.DOScale(new Vector3(2.6f,2.6f,2.6f),.5f);
        stack[stack.Count-1].gameObject.GetComponent<DollController>().GetWalkAnimEvent();
       // TicketNewValue();
        Vibration.Vibrate(25);
    }

    //void TicketValueNegative()
    //{
    //    playerSO.ticketValue = 0;
    //    for (int i = 0; i < stack.Count; i++)
    //    {
    //        // ticketValue -= go.GetComponent<DollController>().dollMoney;          
    //        playerSO.ticketValue += stack[i].gameObject.GetComponent<DollController>().dollMoney;
    //        ticketText.text = playerSO.ticketValue.ToString() + "$";
    //        // Debug.Log("Name : " + stack[i].gameObject.name);
    //    }
    //}


    void DollIdleAnimEvent()
    {
        for (int i = 0; i < PO.transform.childCount; i++)
        {
            PO.transform.GetChild(i).gameObject.GetComponent<DollController>().GirlNOTriggerIdleAnim();
        }
    }

    void DollListTransform()
    {
        for (int i = 0; i < dollHolder.transform.childCount; i++)
        {
         dollHolder.transform.GetChild(i).DOMoveX(dollGO.transform.position.x, (i) * 0.25f);
        }
    }

    void DollScale()
    {
        for (int i = dollHolder.transform.childCount -1; i > 0; i--)
        {
            Debug.Log(i);
            dollHolder.transform.GetChild(i).gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f).OnComplete(() => gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f));
        }
    }

    public void DollDispersion(int listIndex)
    {
        //float randX;
        //float randZ;

        //for (int i = listIndex+1; i < stack.Count; i++)
        //{
        //    randX = Random.Range(-2.5f, 2.5f);
        //    randZ = Random.Range(1f, 3.5f);
        //    if (stack[i].gameObject.tag == Tags.doll)
        //    {
        //        SetUpgradeTicketValue(-stack[i].gameObject.GetComponent<DollController>().dollMoney);
        //        // Debug.Log(stack[i].transform.parent.name);
        //    }

        //    stack[i].gameObject.transform.SetParent(PO.transform);
        //    stack[i].gameObject.tag = Tags.PO;
        //    stack[i].gameObject.GetComponent<DollController>().isContact = false;
        //    int val = i;
        //    stack[i].transform.DOKill();
        //    stack[i].gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), .3f).OnComplete(() => stack[val].gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), .3f));
        //    stack[i].gameObject.transform.position = new Vector3(
        //    stack[i].gameObject.transform.position.x + randX, stack[i].gameObject.transform.position.y, stack[i].gameObject.transform.position.z + randZ);

        //}
    }

    public void SellToStack(int indexOfDoll)
    {
        for (int i = indexOfDoll+1; i < stack.Count; i++)
        {
            stack[i].transform.DOMoveZ(stack[i].transform.position.z - 2,.05f);
          //  Debug.Log("Stack Index : " + i);
        }
       // TicketValueNegative();
    }

    bool isRecreating = false;
    private string lastObstacle;
    private int indexOfCut = -1;
    public void RecreateToStack(int indexOfdoll, string tagName)
    {
        indexOfCut = -1;
        lastObstacle = tagName;
        if (stack.Count < 1)
            return;
        
        if (stack.Count != indexOfdoll)
        {
            if (indexOfCut == -1 )
            {
                indexOfCut = indexOfdoll;
                StartCoroutine(corRecreate(indexOfdoll));

            }
            else if((indexOfCut == indexOfdoll - 1))
            {
                indexOfCut = indexOfdoll;
                Transform tr = stack[indexOfdoll].transform;
                tr.GetComponent<DollController>().GetIdleAnimEvent();
                stack.Remove(stack[indexOfdoll]);
                tr.tag = Tags.PO;
                tr.SetParent(PO.transform);
                tr.DOKill();
                tr.DOLocalJump(new Vector3(Random.Range(-5, 5), tr.localPosition.y, tr.localPosition.z + Random.Range(3.5f, 6)), 1, 1, 0.5f);
                dollPos.localPosition = new Vector3(0, dollPos.position.y, dollPos.transform.position.z - 2);
            }
            else if (indexOfdoll < indexOfCut -1)
            {
                indexOfCut = indexOfdoll;
                StartCoroutine(AgainCorRecreate(indexOfdoll));
            }
        }
        else if(indexOfdoll == stack.Count)
        {
            indexOfCut = indexOfdoll;
            Transform tr = stack[indexOfdoll].transform;
            tr.GetComponent<DollController>().GetIdleAnimEvent();
            stack.Remove(stack[indexOfdoll]);
            tr.tag = Tags.PO;
            tr.SetParent(PO.transform);
            tr.DOKill();
            tr.DOLocalJump(new Vector3(Random.Range(-5, 5), tr.localPosition.y, tr.localPosition.z + Random.Range(3.5f, 6)), 1, 1, 0.5f);
            dollPos.localPosition = new Vector3(0, dollPos.position.y, dollPos.transform.position.z - 2);
        }

        DollIdleAnimEvent();
    }

    IEnumerator corRecreate(int index)
    {
        int b = stack.Count;
        for (int i = index; i < b ; i++)
        {
            Transform tr = stack[index].transform;
            tr.GetComponent<DollController>().GetIdleAnimEvent();
            stack.Remove(stack[index]);
            tr.tag = Tags.PO;
            tr.SetParent(PO.transform);
            tr.GetComponent<DollController>().isContact = false;           
            tr.DOKill();
            tr.DOLocalJump(new Vector3(Random.Range(-5, 5), tr.localPosition.y, tr.localPosition.z + Random.Range(2.5f, 4)), 1, 1, 0.5f);
            dollPos.localPosition = new Vector3(0,dollPos.position.y, dollPos.transform.position.z - 2);
        }
        yield return null;
    }


    IEnumerator AgainCorRecreate(int index)
    {
       // Debug.Log("count on enter : " + stack.Count);
        int b = stack.Count;
        for (int i = index; i < indexOfCut; i++)
        {
            Transform tr = stack[index].transform;
            tr.GetComponent<DollController>().GetIdleAnimEvent();
            stack.Remove(stack[index]);
            tr.tag = Tags.PO;
            tr.SetParent(PO.transform);
            tr.GetComponent<DollController>().isContact = false;
           
            tr.DOKill();
            tr.DOLocalJump(new Vector3(Random.Range(-5, 5), tr.localPosition.y, tr.localPosition.z + Random.Range(2.5f, 4)), 1, 1, 0.5f);
            dollPos.localPosition = new Vector3(0, dollPos.position.y, dollPos.transform.position.z - 2);
          //  SetUpgradeTicketValue(-stack[i].gameObject.GetComponent<DollController>().dollMoney);
          //  Debug.Log(" i : " + index + " stack count : " + stack.Count);
        }
        yield return null;
    }
}
