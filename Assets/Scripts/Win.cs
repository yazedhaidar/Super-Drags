using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

  
   
    private void setStatus()
    {
        GameManager.instance.isWin = true;
    }

    public void win(GameObject go)
    {
        Anim.SetTrigger("Win");
        go.GetComponent<PlayerMovement>().isEnd = true;

    }
}
