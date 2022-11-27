using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacle : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
