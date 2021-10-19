using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject spawned=null;
    [SerializeField] private Vector3 spawnloc=new Vector3(0,0,0);

    //Instatiates a gameobject at the given location when the trigger is activated by the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(spawned, spawnloc, Quaternion.identity);
        }
    }

}
