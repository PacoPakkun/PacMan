﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cataMove : MonoBehaviour
{

    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, waypoints[cur].position) > 0.1f)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else
        {
            cur = (cur + 1) % waypoints.Length;
        }

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacoman")
        {
            if (co.tag == "weak")
            { 
                FindObjectOfType<gameManager>().gameOver(false);
                Destroy(co.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
