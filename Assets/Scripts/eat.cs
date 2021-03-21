using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour
{

    public GameObject pacoman;

    IEnumerator ecstasy()
    {
        pacoman.GetComponent<Collider2D>().tag = "strong";
        gameObject.GetComponent<Renderer>().enabled = false;
        pacoman.GetComponent<move>().SetSpeed(0.5f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.red;
        if (GameObject.Find("cata")!=null)
            GameObject.Find("cata").GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(4);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        if (GameObject.Find("cata")!=null)
            GameObject.Find("cata").GetComponent<SpriteRenderer>().color = Color.red;
        pacoman.GetComponent<move>().SetSpeed(0.2f);
        pacoman.GetComponent<Collider2D>().tag = "weak";
        Destroy(gameObject);
    }

    IEnumerator beer()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        pacoman.GetComponent<move>().SetSpeed(0.15f);
        pacoman.GetComponent<move>().Inverted(true);
        pacoman.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(4);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        pacoman.GetComponent<move>().SetSpeed(0.2f);
        pacoman.GetComponent<move>().Inverted(false);
        Destroy(gameObject);
    }

    IEnumerator cig()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        pacoman.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = false;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = false;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = false;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = false;
        }
        yield return new WaitForSeconds(4);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.4f);
        pacoman.GetComponent<SpriteRenderer>().color = Color.white;
        foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
        {
            child.GetComponent<Renderer>().enabled = true;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "collider")
        {
            pacoman.GetComponent<move>().incScore();
            int i = 0;
            foreach (Transform child in GameObject.Find("food").GetComponent<Transform>())
            {
                i++;
            }
            Debug.Log(i);
            if (i == 1)
            {
                FindObjectOfType<gameManager>().gameOver(true);
            }

            if (gameObject.name == "ecstasy")
            {
                StartCoroutine("ecstasy");
            }
            else if (gameObject.name == "beer")
            {
                StartCoroutine("beer");
            }
            else if (gameObject.name == "cig")
            {
                StartCoroutine("cig");
            }
            else
                Destroy(gameObject);
        }
    }
}