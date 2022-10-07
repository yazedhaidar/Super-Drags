using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float CurrHealth { get; private set; }
    private Animator Anim;


    // Start is called before the first frame update
    void Awake()
    {
        CurrHealth = startingHealth;
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void takeDamage(float _damage)
    {
        CurrHealth = Mathf.Clamp(CurrHealth -_damage, 0, startingHealth);
        if (Anim.gameObject.tag == "Player")
        {
            if (CurrHealth > 0)
            {
                Anim.SetTrigger("Hurt");
            }
            else
            {
                Anim.SetTrigger("Die");

                GetComponent<PlayerMovement>().enabled = false;


            }
        }

        if (Anim.gameObject.tag == "Enemy" || Anim.gameObject.tag == "Move Enemy") 
        {
           
            if (CurrHealth <= 0)
            {
              
                Anim.SetTrigger("died");
                GetComponent<EnemyMelee>().enabled = false;
            }
        
        }
     
    }

    public void addHealth(float _value)
    {
        CurrHealth = Mathf.Clamp(CurrHealth + _value, 1, startingHealth);
      

    }

    public void setStatus()
    {
        GameManager.instance.isDie = true;
    }
}
