using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour {

    public void LoadStartMenu()
    {
        GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject canva in canvas)
        {
            canva.SetActive(false);
        }
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 20, Camera.main.transform.position.y, Camera.main.transform.position.z);
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 20, Camera.main.transform.position.y, Camera.main.transform.position.z);
        GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");
        foreach(GameObject canva in canvas)
        {
            canva.SetActive(false);
        }
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(float secound)
    {
        yield return new WaitForSeconds(secound);
       Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 20, Camera.main.transform.position.y, Camera.main.transform.position.z);
        GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");
        foreach (GameObject canva in canvas)
        {
            canva.SetActive(false);
        }
        SceneManager.LoadScene("Game Over");
    }
}
