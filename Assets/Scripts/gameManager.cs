using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject UI;
    public float delay = 2f;

    public void gameOver(bool win)
    {
        if (win)
        {
            UI.GetComponent<Animator>().SetBool("win", true);
        }
        else
        {
            UI.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }

}
