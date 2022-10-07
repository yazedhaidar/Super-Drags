using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsTrigger : MonoBehaviour
{
    

    [SerializeField] private GameObject trap;

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void activateTrap()
    {
        trap.SetActive(true);
        trap.GetComponent<MovingTraps>().hit = false;
        gameObject.SetActive(false);

    }

  
}
