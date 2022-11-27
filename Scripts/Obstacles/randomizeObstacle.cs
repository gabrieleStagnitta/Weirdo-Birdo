using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeObstacle : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
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

    private void Start()
    {
        this.GetComponentInChildren<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        this.GetComponentInChildren<SpriteRenderer>().color = colorList[Random.Range(0, colorList.Count)];
    }

}
