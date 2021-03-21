using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{

    public GameObject UI;

    public void ButtonClicked()
    {
        UI.GetComponent<Animator>().SetBool("clicked", true);
        Invoke("loadGame", 1.8f);
    }

    void loadGame()
    {
        SceneManager.LoadScene("Main");
    }

}
