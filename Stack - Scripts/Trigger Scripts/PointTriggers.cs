using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;
using DG.Tweening;
public class PointTriggers : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    [SerializeField] int value;
    [SerializeField] GameObject dollHolder;
   // [SerializeField] GameObject dollStack;
    //public List<GameObject> dollList = new List<GameObject>();
    //int StackHorizontalCount = 3;
    //int StackVerticalCount = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Doll)
        {
            
            if (value < points.Length)
            {
                if (value < 4)
                {
                    other.transform.DOKill();
                    other.transform.SetParent(points[value].transform);
                    other.gameObject.GetComponent<DollController>().GetHappyAnimEvent();
                    other.gameObject.transform.DOLocalMove(Vector3.zero, 1.5f).OnComplete(() => other.gameObject.transform.DOLocalRotate(Vector3.zero, 0.01f).OnComplete(() => other.gameObject.GetComponent<DollController>().GetEndAnimEvent()));
                    value++;
                }
                else
                {
                    //EventManager.GamePlayBodyGuardIdlePos();
                    //DOVirtual.DelayedCall(.45f, () =>
                    //{
                    //    EventManager.GamePlayCameraParent(gameObject, true);
                    //});
                    other.transform.DOKill();
                    other.transform.SetParent(points[value].transform);
                  //  other.gameObject.GetComponent<DollController>().GetHappyAnimEvent();
                    other.gameObject.transform.DOLocalMove(Vector3.zero, 1.5f).OnComplete(() => other.gameObject.transform.DOLocalRotate(Vector3.zero, 0.01f).OnComplete(() => other.gameObject.GetComponent<DollController>().GetDanceAnimEvent()));
                    value++;
                }

            }
           

            if (dollHolder.transform.childCount == 0)
            {               
                DOVirtual.DelayedCall(7.5f, () =>
                {
                    Time.timeScale = 0;
                    GameManager.Instance.SuccessControl();
                });                
            }
        }
        if (other.tag == Tags.Hand)
        {
            if (dollHolder.transform.childCount == 0)
            {
               
                DOVirtual.DelayedCall(7.5f, () =>
                {
                    GameManager.Instance.SuccessControl();
                    Time.timeScale = 0;
                });
            }
        }

        //if (other.tag == Tags.SellDoll)
        //{
        //   // AddBrick(other.gameObject);
        //}
    }

    //public void AddBrick(GameObject brick)
    //{
    //    brick.transform.DOKill();
    //    brick.transform.SetParent(dollStack.transform);
    //    brick.transform.DORotate(Vector3.zero, .5f);
    //    //brick.transform.DOScale(CollectBrickSize, JumpDuration);
    //    Vector3 targetPos = Vector3.zero;
    //    int index = dollList.Count;
    //    targetPos.x = (index % StackHorizontalCount) - (StackHorizontalCount / 2);
    //    targetPos.y = index / (StackHorizontalCount * StackVerticalCount);
    //    targetPos.z = (index / StackHorizontalCount) % (StackVerticalCount);
    //    targetPos.x *=2f;
    //    targetPos.y *=2f;
    //    targetPos.z *=2f;
    //    brick.transform.DOLocalJump(targetPos, 1, 1, .5f).OnComplete(() =>
    //    {
    //        //ParticleSystem particleSystem = brick.transform.GetChild(0).GetComponent<ParticleSystem>();
    //        //particleSystem.gameObject.SetActive(true);
    //        //particleSystem.Play();
    //    });
    //    // onCollectBrickSound?.Invoke();
    //    dollList.Add(brick);
    //}

}
