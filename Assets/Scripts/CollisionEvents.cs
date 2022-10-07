using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvents : MonoBehaviour
{
    public UnityEvent onCollision;
    public UnityEvent<GameObject> onCollisionWithGameObject;
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onCollision?.Invoke();
            onCollisionWithGameObject?.Invoke(collision.gameObject);
        }
        else
        {
            onCollision?.Invoke();
        }
    }
}
