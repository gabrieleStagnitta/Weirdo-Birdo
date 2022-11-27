using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeBackgroundColor : MonoBehaviour
{
    private float timeLeft;
    private Color targetColor;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private List<Color32> colorList = new List<Color32>() {
        new Color32(255,254,239,255),
        new Color32(167,183,161,255),
        new Color32(185,115,80,255),
        new Color32(202,201,98,255),
        new Color32(127,165,200,255),
        new Color32(127,165,200,255),
        new Color32(255,255,255,255),
        new Color32(147,125,138,255),
    };

    private void Awake()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color32(255, 255, 255,255);
    }

    private void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            sprite.color = targetColor;

            targetColor = colorList[Random.Range(0, colorList.Count)];
            timeLeft = 25.0f;
        }
        else
        {
            sprite.color = Color.Lerp(sprite.color, targetColor, Time.deltaTime / timeLeft);

            timeLeft -= Time.deltaTime;
        }
    }
}
