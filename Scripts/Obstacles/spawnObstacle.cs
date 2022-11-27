using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacle : MonoBehaviour
{
    [SerializeField] private float spawnTime = 1.5f;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float height;
    private float speed = 7;

    private void Start()
    {
        newObstacle();
        StartCoroutine("spawn");
    }

    private IEnumerator spawn()
    {
        while (true)
        {
            newObstacle();
            if (spawnTime > 1.2f) spawnTime -= 0.02f;
            yield return new WaitForSeconds(spawnTime);
        }
        
    }

    private void newObstacle()
    {
        if(GameObject.FindGameObjectWithTag("Player") && GameObject.FindGameObjectWithTag("Player").GetComponent<birdoManager>().isPlaying)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            newObstacle.GetComponent<moveObstacle>().speed = speed + Random.Range(0.1f, 0.5f);
            Destroy(newObstacle, 12.5f);
        }
    }

}
