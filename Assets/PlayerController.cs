using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private enum State { idle, running, jumping, falling };
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherrytext;
    [SerializeField] private Text Gameover;
    string line;
    string [] movesArray= new string[3];
    string moves;
    string myFilePath, filename;
    public int x;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        filename = "data.txt";
        myFilePath = Application.dataPath + "/" + filename;
        x = 0;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            cherries += 1;
            cherrytext.text = cherries.ToString();
        }
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Gameover.text = "GAME OVER";

        }
    }
 
    // Update is called once per frame
    void Update()

    {
        StreamReader reader = new StreamReader(myFilePath);
        while((line = reader.ReadLine()) != null){
            int y;
            int.TryParse(line, out y);
            print(y);
            print(x);
            Movement(y,x);
            velocityState();
            anim.SetInteger("state", (int)state);
            x = x + 1;

        }



        /* movesArray = File.ReadAllLines(myFilePath);
         foreach(string line in movesArray)
         {
             print(line);
         }*/

    }
    private void Movement(int y,int x)
    {
        //float hdirection = Input.GetAxis("Horizontal");
        if (x%2==1 && y>0)
        {
            rb.velocity = new Vector2(+5, rb.velocity.y);

        }

        else if (x%2==1 && y<0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            // transform.localScale = new Vector2(-1, 1);
        }


        else if (x%5==0 && y>10)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jumping;
        }

    }
    private void velocityState()
    {
        if (state == State.jumping)
        {
            if(rb.velocity.y< 0.1f)
            {
                state = State.falling;
            }
        }
        else if(state ==State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
