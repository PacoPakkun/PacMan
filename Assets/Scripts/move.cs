using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public int score = 0;
    Vector2 dest = Vector2.zero;
    int direction = 1; //1 right, -1 left, 2 up, -2 down
    int newdirection = 1;
    Vector2 up = new Vector2(0, 1.15f);
    Vector2 right = new Vector2(1.15f, 0);
    bool inverted = false;

    public void incScore()
    {
        score++;
    }

    public int getScore()
    {
        return score;
    }

    public void SetSpeed(float sp)
    {
        speed = sp;
    }

    public void Inverted(bool inv)
    {
        inverted = inv;
    }

    bool valid(Vector2 dir)
    {
        bool ok;
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        ok = hit.collider == GetComponent<Collider2D>();

        pos = new Vector2(transform.position.x - 0.5f, transform.position.y);
        hit = Physics2D.Linecast(pos + dir, pos);
        if (ok == true)
            ok = hit.collider == GetComponent<Collider2D>();

        pos = new Vector2(transform.position.x + 0.5f, transform.position.y);
        hit = Physics2D.Linecast(pos + dir, pos);
        if (ok == true)
            ok = hit.collider == GetComponent<Collider2D>();

        pos = new Vector2(transform.position.x, transform.position.y - 0.5f);
        hit = Physics2D.Linecast(pos + dir, pos);
        if (ok == true)
            ok = hit.collider == GetComponent<Collider2D>();

        pos = new Vector2(transform.position.x, transform.position.y + 0.5f);
        hit = Physics2D.Linecast(pos + dir, pos);
        if (ok == true)
            ok = hit.collider == GetComponent<Collider2D>();

        return ok;
    }

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        gameObject.GetComponent<Collider2D>().tag = "weak";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);


        if (inverted)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                newdirection = -2;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                newdirection = 2;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                newdirection = 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                newdirection = -1;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                newdirection = 2;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                newdirection = -2;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                newdirection = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                newdirection = 1;
            }
        }

        if (newdirection == 2 && valid(up))
        {
            direction = newdirection;
        }
        if (newdirection == 1 && valid(right))
        {
            direction = newdirection;
        }
        if (newdirection == -2 && valid(-up))
        {
            direction = newdirection;
        }
        if (newdirection == -1 && valid(-right))
        {
            direction = newdirection;
        }


        if (direction == 2 && valid(up))
            dest = (Vector2)transform.position + Vector2.up;
        if (direction == 1 && valid(right))
            dest = (Vector2)transform.position + Vector2.right;
        if (direction == -2 && valid(-up))
            dest = (Vector2)transform.position - Vector2.up;
        if (direction == -1 && valid(-right))
            dest = (Vector2)transform.position - Vector2.right;

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

    }
}
