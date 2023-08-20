using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public static HeartDisplay instance;

    [SerializeField]
    private Image imgHeart1, imgHeart2, imgHeart3, imgHeart4, imgHeart5;

    [SerializeField]
    private Sprite sprFull, sprHalf, sprEmpty;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateHpDisplay(float hp)
    {
        imgHeart1.sprite = sprFull;
        imgHeart2.sprite = sprFull;
        imgHeart3.sprite = sprFull;
        imgHeart4.sprite = sprFull;
        imgHeart5.sprite = sprFull;

        if(hp <= 9)
        {
            imgHeart5.sprite = sprHalf;
        }
        if (hp <= 8)
        {
            imgHeart5.sprite = sprEmpty;
        }
        if (hp <= 7)
        {
            imgHeart4.sprite = sprHalf;
        }
        if (hp <= 6)
        {
            imgHeart4.sprite = sprEmpty;
        }
        if (hp <= 5)
        {
            imgHeart3.sprite = sprHalf;
        }
        if (hp <= 4)
        {
            imgHeart3.sprite = sprEmpty;
        }
        if (hp <= 3)
        {
            imgHeart2.sprite = sprHalf;
        }
        if (hp <= 2)
        {
            imgHeart2.sprite = sprEmpty;
        }
        if (hp <= 1)
        {
            imgHeart1.sprite = sprHalf;
        }
        if (hp <= 0)
        {
            imgHeart1.sprite = sprEmpty;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
