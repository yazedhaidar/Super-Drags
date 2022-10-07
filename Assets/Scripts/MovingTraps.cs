using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTraps : MonoBehaviour
{
    [SerializeField] private string trapName;
    [SerializeField] private float damage;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    public bool hit;
    private CircleCollider2D cirlceCollider;
    private Rigidbody2D rb;
    private float count;
    private int hitCount;

    // Start is called before the first frame update
    void Start()
    {
       
        cirlceCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
            
        
    }

    // Update is called once per frame
    void Update()
    {
        cirlceCollider.enabled = true;
        
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;

        if (trapName.ToLower() == "saw"  ) 
        {
            cirlceCollider.gameObject.transform.position += Vector3.left * movementSpeed;
            count += Time.deltaTime;
            if (count > 2f)
            {
                anim.SetTrigger("Hit");
                count = 0;
            }
            
        }

        if (trapName.ToLower() == "ball" )
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            
        }
    }
 
    public void ballAnimation()
    {
        anim.SetTrigger("Boom");
    }

    public void sawAnimation()
    {
        anim.SetTrigger("Hit");
    }

    public void ballTrap(GameObject go)
    {
        hit = true;
        cirlceCollider.enabled = false;
       
        hitCount++;
        if (hitCount == damage)
        {
            go.GetComponent<Health>().takeDamage(damage);
            SoundManager.instance.TakeDamageSfx();
        }
    }

    public void sawTrap(GameObject go)
    {
        hit = true;
        cirlceCollider.enabled = false;
     
        hitCount++;
        if (hitCount == damage)
        {
            go.GetComponent<Health>().takeDamage(damage);
            SoundManager.instance.TakeDamageSfx();
        }
    }
    private void deactive()
    {
        
        gameObject.SetActive(false);
    }
  




}
