using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorDoGame : MonoBehaviour
{
    public static int totalNumberOfBlocks;
    public static int destroyedNumberOfBlocks;
    public Image stars;
    public GameObject canvas;
    public static GerenciadorDoGame instancia;
    public Bola ball;
    public Plataforma plataform;

    private void Awake()
    {
        instancia = this;
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            canvas.SetActive(false);
            destroyedNumberOfBlocks = 0;
        }
    }

    public void finishGame ()
    {
        stars.fillAmount = (float)(destroyedNumberOfBlocks) / totalNumberOfBlocks;
        canvas.SetActive(true);
        plataform.enabled = false;
        Destroy(ball.gameObject);
    }

    public void changeScene (string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void closeApplication()
    {
        Application.Quit();
    }
}
