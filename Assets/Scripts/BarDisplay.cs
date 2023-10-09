using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarDisplay : MonoBehaviour
{
    [SerializeField] Image displayImg;
    private void Reset()
    {
        displayImg = GetComponent<Image>();
    }

    public void Set(Vector2 value)
    {
        if(value.x>0 && value.y>0)
        displayImg.fillAmount = value.x / value.y;
        //Debug.Log("Set bar display: " + value);
    }
}
