using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation.Samples;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] float damageValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            var life = other.gameObject.GetComponent<Life>();
            if (life != null)
            {
                life.AddDamage(damageValue);
                var lifeHealthbar = life.GetComponentInChildren<BarDisplay>();
                lifeHealthbar.Set(life.Get());
            }
            Destroy(gameObject);
        }
    }
}
