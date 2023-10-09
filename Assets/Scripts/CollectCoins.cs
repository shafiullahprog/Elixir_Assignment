using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            scoreText.text = "Score: " + score;
            Debug.Log(score);
            Destroy(collision.gameObject);
        }
    }
}
