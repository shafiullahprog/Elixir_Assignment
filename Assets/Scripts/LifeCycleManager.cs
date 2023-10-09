using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LifeCycleManager : MonoBehaviour
{
    [SerializeField] UnityEvent onLife0;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void CheckHealth(Vector2 health)
    {
        if (health.x <= 0)
        { 
            //onLife0?.Invoke();
            gameManager.GameOver();
        }  
    }

}
