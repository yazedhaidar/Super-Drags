using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent onTrigger;
    public UnityEvent<Collider2D> onTriggerWithCollision;

    public UnityEvent<GameObject> onTriggerWithGameObject;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            onTrigger?.Invoke();
            onTriggerWithCollision?.Invoke(collision);
            onTriggerWithGameObject?.Invoke(collision.gameObject);
        }
        

    }
}
