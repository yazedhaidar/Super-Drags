using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
     private float direction;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D bound;
 
    [SerializeField] private float distanceCollider;
    private float cooldownTimer=Mathf.Infinity;

    private Animator anim;
    private Health playerHealth;
    private bool isMoving;
    private float count =0;

    // Start is called before the first frame update
    void Start()
    {
        Active();
        anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.gameObject.tag=="Move Enemy")
        {
            MoveEnemy();
            count += Time.deltaTime;
        }
        
        cooldownTimer += Time.deltaTime;
        if(checkPlayer())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;

                anim.SetTrigger("MeleeAttack");
                SoundManager.instance.SwingSfx();
            }
        }

       
        anim.SetBool("Moving", isMoving);
       


    }

    private bool checkPlayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, 
            new Vector3(boxCollider.bounds.size.x *range,boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        if (hit.collider)
        {
            isMoving = false;
            playerHealth = hit.transform.GetComponent<Health>();
        }
           

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(checkPlayer())
        {
            playerHealth.takeDamage(damage);
            SoundManager.instance.TakeDamageSfx();
        }
    }

    private void MoveEnemy()
    {
        direction = Mathf.Sign(transform.localScale.x);
       
        float movementSpeed = speed * Time.deltaTime;
        if (direction < 0)
        {
            transform.Translate(-movementSpeed, 0, 0);
        }
        else if (direction > 0)
        {
            transform.Translate(movementSpeed, 0, 0);
        }
        isMoving = true;
        if (count > 1.5f)
        {
            changeDir();
            count = 0;

        }
    }
    private void changeDir()
    {
      
            isMoving = false;
            if (direction < 0) 
            {
                
                transform.localScale = Vector3.one;
            }
            else if(direction > 0)
            {
                
                transform.localScale = new Vector3(-1, 1, 1);
               
            }
        
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
