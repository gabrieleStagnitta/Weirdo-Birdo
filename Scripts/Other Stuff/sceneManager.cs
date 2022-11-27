using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{

    [SerializeField] GameObject birdo;
    [SerializeField] GameObject rechargeScreenImage;
    [SerializeField] GameObject credits;

    public void restartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void playAgain()
    {
        StartCoroutine("changeScreen");
    }

    public void closeGame()
    {
        Application.Quit();
    }

    IEnumerator changeScreen()
    {
        byte a = 0;
        GameObject.FindGameObjectWithTag("Canvas").transform.Find("GameOver").gameObject.SetActive(false);
        while (a<255)
        {
            yield return new WaitForSeconds(0.05f);
            a += 15;
            rechargeScreenImage.GetComponent<RawImage>().color = new Color32(0, 0, 0, a);
        }
        if (GameObject.FindGameObjectsWithTag("Obstacles") != null)
        {
            foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacles"))
            {
                Destroy(obstacle);
            }
        }
        bool notSpawned = true;
        while (a > 0)
        {
            yield return new WaitForSeconds(0.05f);
            if (a <= 125 && notSpawned)
            {
                GameObject newBirdo = Instantiate(birdo);
                newBirdo.GetComponent<birdoManager>().startGame();
                notSpawned = false;
            }
            a -= 15;
            rechargeScreenImage.GetComponent<RawImage>().color = new Color32(0, 0, 0, a);
        }
    }
}
