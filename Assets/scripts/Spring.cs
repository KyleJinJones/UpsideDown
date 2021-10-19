using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float springforce=30;

    //Gives the Player a large boost in upward momentum when stepped on
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springforce), ForceMode2D.Impulse);
    }
}
