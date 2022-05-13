using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constans;

public class Bullet : MonoBehaviour
{
    public float damage;
    [SerializeField] GameObject smashVFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Enemy)
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            smashVFX.SetActive(true);
            Destroy(gameObject,.25f);
        }
    }
}
