using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Life : MonoBehaviour
{
    [SerializeField] UnityEvent<float> onDamageLife;
    [SerializeField] GameObject coin;
    GameManager gameManager;
    public float maxHealth=100f, health = 100f,cooldownTime=1f;
    float cooldown = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void AddDamage(float damage)
    {     
       if (Time.time > cooldown)
       {
            health -= damage;
            onDamageLife?.Invoke(damage);
            cooldown = Time.time + cooldownTime;
       }
    }
    public void CheckHealth()
    {
        if (health <= 0)
        {
            GenerateCoin();
        }
    }

    public Vector2 Get()
    {
        return new Vector2(health, maxHealth);
    }

    public void GenerateCoin()
    {
        if (gameObject.tag == "Enemy" && coin != null)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
