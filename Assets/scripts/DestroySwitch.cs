using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySwitch : MonoBehaviour
{
    [SerializeField] private GameObject destroyed= null;

    //Similar to Normal switches, but destroys a gameobject in the world when triggered rather than instantiating one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(destroyed);
        }
    }
}
