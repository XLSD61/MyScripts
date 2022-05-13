using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
using DG.Tweening;
using Enums;
public class DollController : MonoBehaviour
{
    //[Header("Money")]
    //[SerializeField] public int dollMoney = 2;

    [Header("Control")]
    [SerializeField] PlayerControl playerControl;
    [SerializeField] public bool isContact;
    [SerializeField] public bool isNO;

    [Header("Epoch")]
    [SerializeField] GameObject[] Epoch;
  //  [SerializeField] GameObject EpochParent;
    [SerializeField] int epochValue;
    [SerializeField] int epochMoney;

    [Header("Accessory")]
    [SerializeField] GameObject[] Accessory;
   // [SerializeField] GameObject AccessoryParent;
    [SerializeField] int AccessoryValue;
    [SerializeField] int AccessoryMoney;

    [SerializeField]public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == Tags.PO)
        {
            if (other.tag == Tags.Hand)
            {
                GetCupcakeNewPos(2f);
                playerControl.AdDdollList(gameObject);
                // other.transform.position = new Vector3( playerControl.stack[1].gameObject.transform.position.x,playerControl.cupcakePos.position.y,playerControl.cupcakePos.position.z);
                gameObject.transform.position = new Vector3(playerControl.dollHolder.transform.position.x, playerControl.dollPos.position.y, playerControl.dollPos.position.z);
                gameObject.transform.SetParent(playerControl.dollHolder.transform);
                gameObject.tag = Tags.Doll;
                EventManager.GamePlayGirlAnim(GirlAnim.Walk, id);
                //   playerControl.SetUpgradeTicketValue(dollMoney);
                // Debug.Log("Girdi El");
            }
        }

        if (gameObject.tag == Tags.Doll)
        {
            if (other.tag == Tags.PO)
            {
                if (!other.gameObject.GetComponent<DollController>().isContact)
                {
                    GetCupcakeNewPos(2f);
                    //  Debug.LogWarning("PO Tirgger Case : " + playerControl.cupcakePos.position);
                    playerControl.AdDdollList(other.gameObject);
                    // other.transform.position = new Vector3( playerControl.stack[1].gameObject.transform.position.x,playerControl.cupcakePos.position.y,playerControl.cupcakePos.position.z);
                    other.transform.DOMove(new Vector3(playerControl.stack[1].gameObject.transform.position.x, playerControl.dollPos.position.y, playerControl.dollPos.position.z), .5f);
                    other.transform.SetParent(playerControl.dollHolder.transform);
                    other.tag = Tags.Doll;
                    other.gameObject.GetComponent<DollController>().isContact = true;
                    EventManager.GamePlayGirlAnim(GirlAnim.Walk, id);
                    //    playerControl.SetUpgradeTicketValue(dollMoney);
                }
            }

            if (other.tag == Tags.EpochGate)
            {
                //  gameObject.GetComponent<MeshFilter>().mesh = meshFilter;            
                ChangeEpoch();
                DoScaleFunk();
                Vibration.Vibrate(25);
                EventManager.GamePlayGirlAnim(GirlAnim.Walk,id);

            }
            if (other.tag == Tags.AccessoryGate)
            {
                //  gameObject.GetComponent<MeshFilter>().mesh = meshFilter;
              //  AccessoryParent.SetActive(true);
                DoScaleFunk();
                ChangeAccessory();
            }
            if (other.tag == Tags.BlueColorGate)
            {
                ChangeColor(3);
                DoScaleFunk();
            }
            if (other.tag == Tags.RedColorGate)
            {
                ChangeColor(2);
                DoScaleFunk();
            }
            if (other.tag == Tags.GreenColorGate)
            {
                ChangeColor(1);
                DoScaleFunk();
            }

            if (other.tag == Tags.Crusher)
            {
                CrusherTrigger();
                this.gameObject.transform.DOKill();
               // this.gameObject.transform.SetParent(other.gameObject.transform.parent);
                this.gameObject.tag = Tags.NO;
                this.gameObject.transform.DOScaleY(.25f, .2f);
                // other.gameObject.GetComponent<Collider>().enabled = false;
            }
            if (other.tag == Tags.Hammer)
            {
                HammerTrigger();
                //other.gameObject.GetComponent<Collider>().enabled = false;
            }

            if (other.tag == Tags.Cutter)
            {
                CutterTrigger();
                // other.gameObject.GetComponent<Collider>().enabled = false;
            }

            if (other.tag == Tags.Spike)
            {
                SpikeTrigger();
                //   other.gameObject.GetComponent<Collider>().enabled = false;
            }
            if (other.tag == Tags.Tongue)
            {
                TongueTrigger();
                other.gameObject.GetComponent<TongueControl>().TongueAnim();
                this.gameObject.transform.DOKill();
                this.gameObject.transform.SetParent(other.gameObject.transform.parent);
                this.gameObject.tag = Tags.NO;
                this.gameObject.transform.DOMoveX(-5f, .4f).OnComplete(() => this.gameObject.SetActive(false));
                //   other.gameObject.GetComponent<Collider>().enabled = false;
            }

            if (other.tag == Tags.Endroad)
            {
                // Destroy(gameObject.GetComponent<StayInside>());
                playerControl.isEndRoad = true;
            }
        }
    }

    void DoScaleFunk()
    {
       // EventManager.GamePlayGirlAnim(GirlAnim.Turn, id);
        gameObject.transform.DOScale(new Vector3(3f, 3f, 3f), 0.2f).OnComplete(() => gameObject.transform.DOScale(new Vector3(2.6f, 2.6f, 2.6f), 0.2f));
       // Debug.Log("Girdi Do ScaleFunk");
    }
   

    void ChangeEpoch()
    {
        if (epochValue < Epoch.Length)
        {
            Epoch[epochValue].gameObject.SetActive(false);
            epochValue++;
            Epoch[epochValue].gameObject.SetActive(true);
            Epoch[epochValue].gameObject.transform.DOScaleY(1, .5f);
         //   GetUpgradeTicketValue(AccessoryMoney, epochValue, 7);
            //DoScaleFunk();
        }
    }

    void ChangeAccessory()
    {
        //if (AccessoryValue < Accessory.Length)
        //{
        //    Accessory[AccessoryValue].gameObject.SetActive(false);
        //    AccessoryValue++;
        //    Accessory[AccessoryValue].gameObject.SetActive(true);
        //    Accessory[AccessoryValue].gameObject.transform.DOScaleY(1, .5f);
        //    GetUpgradeTicketValue(AccessoryMoney, AccessoryValue, 7);
        //    DoScaleFunk();
        //}
        for (int i = 0; i < Accessory.Length; i++)
        {
            Accessory[i].gameObject.SetActive(true);
            Accessory[i].gameObject.transform.DOScaleY(1, .5f);
        }
      //  DoScaleFunk();
    }

    void ChangeColor(int colorValue)
    {
        for (int i = 0; i < Epoch[epochValue].gameObject.transform.childCount-2; i++)
        {
            Epoch[epochValue].gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        Epoch[epochValue].gameObject.transform.GetChild(colorValue).gameObject.SetActive(true);
        EventManager.GamePlayGirlAnim(GirlAnim.Turn, id);
    }

    //void GetUpgradeTicketValue(int value ,int i,int a)
    //{
    //    value =i *a;
    //  //  Debug.Log(value);
    //    playerControl.SetUpgradeTicketValue(value);
    //    dollMoney += value;
    //}
    void GetCupcakeNewPos(float value)
    {
        playerControl.SetDollNewPos(value);
    }


    void CrusherTrigger()
    {
       // transform.DOScaleY(0.25f, 0.5f);
        NOTriggerCase(Tags.Crusher);
    }

    void HammerTrigger()
    {
        // transform.DOScaleZ(0.5f, 0.5f);
        //gameObject.SetActive(false);
        NOTriggerCase(Tags.Hammer);
    }

    void CutterTrigger()
    {
       // gameObject.SetActive(false);
        NOTriggerCase(Tags.Cutter);
    }

    void SpikeTrigger()
    {
        //gameObject.SetActive(false);
        NOTriggerCase(Tags.Spike);
    }
    void TongueTrigger()
    {
        //gameObject.SetActive(false);
        NOTriggerCase(Tags.Spike);
    }

   public void SellTrigger(Transform pos,Transform endPos)
    {
        SellStack();
        this.transform.DOKill();
        playerControl.stack.Remove(this.gameObject);
        GetCupcakeNewPos(-2f);
        this.transform.SetParent(playerControl.PO.transform);
        this.gameObject.tag = Tags.SellDoll;
        this.gameObject.transform.DOMoveX(pos.position.x, .5f).OnComplete(() => gameObject.transform.DOMoveZ(endPos.transform.position.z - 45f, 5f));/*.OnComplete(() =>
            this.gameObject.transform.DOLocalJump(new Vector3(Random.Range(-10, 10), this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + Random.Range(-5f, 5)), 1, 1, 0.5f))); */
      //  Debug.Log("Sell Gate : " + this.gameObject.name);

    }

    void NOTriggerCase(string tagName)
    {
        if (!isNO)
        {
            DistributeToStack(tagName);
           // gameObject.transform.SetParent(playerControl.gameArea.transform);
           // //  gameObject.GetComponent<Collider>().enabled = false;

            // int objIndex = playerControl.stack.IndexOf(gameObject);
            // // Debug.Log("Listeden çýkarýlan Obje Index No : " + objIndex);
            // // playerControl.cupcakePos.position = new Vector3(playerControl.cupcakePos.position.x, playerControl.cupcakePos.position.y, (objIndex * 2) - 1);
            //// Debug.Log(" child count : " + playerControl.cupcakeGO.transform.childCount + " pos holder : " + playerControl.cupcakePos.localPosition);



            // playerControl.cupcakePos.localPosition = new Vector3(0, playerControl.cupcakePos.position.y, gameObject.transform.position.z - 2);

            // playerControl.CupcakeDispersion(objIndex);
            // // playerControl.stack.RemoveAt(objIndex);
            // // gameObject.SetActive(false);


            // // Debug.Log("NO Tirgger Case : " + playerControl.cupcakePos.position);
            // Vibration.Vibrate(50);
            // isNO = true;
        }
       
    }

    public void DistributeToStack(string tagName)
    {
        int objIndex = playerControl.stack.IndexOf(gameObject);
        playerControl.RecreateToStack(objIndex, tagName);
    }

    public void SellStack()
    {
        int objIndex = playerControl.stack.IndexOf(gameObject);
        playerControl.SellToStack(objIndex);
        Debug.Log("objIndex : " + objIndex);
    }

    public void GetIdleAnimEvent()
    {
        EventManager.GamePlayGirlAnim(GirlAnim.Idle, id);
     //   Debug.Log("Baby Idle Anim ID : " + id);
    }

    public void GetWalkAnimEvent()
    {
        EventManager.GamePlayGirlAnim(GirlAnim.Walk, id);
    }

    public void GetEndAnimEvent()
    {
        EventManager.GamePlayGirlAnim(GirlAnim.EndPos, id);
    }

    public void GetHappyAnimEvent()
    {
        EventManager.GamePlayGirlAnim(GirlAnim.Happy, id);
    }

    public void GetDanceAnimEvent()
    {
        EventManager.GamePlayGirlAnim(GirlAnim.Dance, id);
    }

    public void GirlNOTriggerIdleAnim()
    {
        if (epochValue < Epoch.Length)
        {
            Epoch[epochValue].gameObject.SetActive(false);
          //  epochValue++;
            Epoch[epochValue].gameObject.SetActive(true);
            //Epoch[epochValue].gameObject.transform.DOScaleY(1, .5f);
            //   GetUpgradeTicketValue(AccessoryMoney, epochValue, 7);
            //DoScaleFunk();
        }
    }


    //  private int index = 0;
    //private int FindIndex(GameObject obj)
    //{

    //    foreach (var item in playerControl.stack)
    //    {
    //        if (item == obj)
    //        {
    //            return index;
    //        }
    //        index++;

    //    }

    //    return -1;
    //}
}
