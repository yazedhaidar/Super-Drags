using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    public string axis = "Horizontal";
    public float speed;
    public float jump;
    private bool Grounded;
    private int count = 0;
    public bool isEnd;

 
    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float HorizontalInput = Input.GetAxis(axis);
      
        playerRb.velocity = new Vector2(HorizontalInput * speed , playerRb.velocity.y);
        
        if (HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (HorizontalInput < -0.01f) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
       
        if(Input.GetKeyDown(KeyCode.Space) && count <= 2 && Grounded)
        {
            count += 1;

            jumping();
          
        }
    

        if (isEnd)
        {
            playerRb.velocity = Vector2.zero;
            playerAnim.SetBool("Walk", false);
        }
       
            playerAnim.SetBool("Walk", HorizontalInput != 0);
        
       
        playerAnim.SetBool("Grounded", Grounded);

    }

    private void jumping()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jump);
        playerAnim.SetTrigger("Jump");
       
        if (count >= 2) 
        {
            Grounded = false;
        }
            
       
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            count = 0;
            Grounded = true;
        }
    }
}
