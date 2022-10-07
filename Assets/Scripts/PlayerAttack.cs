using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer =Mathf.Infinity;
    private Animator Anim;
    private PlayerMovement playerMovement;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
        Anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && cooldownTimer > attackCooldown) 
        {
            Shoot();
            
        }
        cooldownTimer += Time.deltaTime;
       
    }

    private void Shoot()
    {
        Anim.SetTrigger("Shoot");
        SoundManager.instance.FireSfx();
        cooldownTimer = 0;

        fireballs[checkFireball()].transform.position = firePoint.position;
        fireballs[checkFireball()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int checkFireball()
    {
        for (int i = 0; i <= fireballs.Length; i++) 
        {
            if(!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
