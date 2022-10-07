using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public float duration;
    private float timer;

    private void Update()
    {
        timer = timer - Time.deltaTime < 0 ? 0 : timer - Time.deltaTime;
        
    }
    public void invisblePickups(Collider2D player)
    {
       
        if(player.tag=="Player")
        {
            timer = duration;
            StartCoroutine(blinking(player));
            player.gameObject.tag = "Untagged";
        }
    }

    private IEnumerator blinking(Collider2D p)
    {
        SpriteRenderer sr = p.gameObject.GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;
        Color blinkColor = defaultColor;
        blinkColor.a = 0.3f;

        while (timer > 0)
        {
            sr.color = blinkColor;
            yield return new WaitForSeconds(0.2f);
            sr.color = defaultColor;
            yield return new WaitForSeconds(0.2f);

        }
        sr.color = defaultColor;
        p.gameObject.tag = "Player";
    }

    public void SpeedPickup(GameObject go)
    {
        if (go.tag == "Player")
        {
            timer = duration;
            go.GetComponent<PlayerMovement>().speed += 5;
            StartCoroutine(speed(go));
           
          
        }
        
    }

    private IEnumerator speed(GameObject p)
    {
       yield return new WaitForSeconds(timer);
        p.GetComponent<PlayerMovement>().speed -= 5;
    }


}
