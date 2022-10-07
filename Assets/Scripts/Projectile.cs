using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private bool enemyHit;
    private Animator Anim;
    private BoxCollider2D boxCollider;
 
    private float projectile_lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime *direction;
     
            transform.Translate(movementSpeed, 0, 0);
    
        
        projectile_lifetime += Time.deltaTime;

        if (projectile_lifetime > 2)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Move Enemy")
        {
            collision.GetComponent<Health>().takeDamage(1f);
        
         
        }

        else
        {
            return;
        }
        hit = true;
        boxCollider.enabled = false;
        Anim.SetTrigger("Explode");
        SoundManager.instance.ExplosionSfx();
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void setDirection(float projectile_direction)
    {
       
        projectile_lifetime = 0;
        direction = projectile_direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != projectile_direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
      
    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }
    private void Active()
    {
        gameObject.SetActive(true);
    }
}
