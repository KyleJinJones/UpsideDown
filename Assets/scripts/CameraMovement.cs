using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player=null;
    // Handles camera movement, in this case it only moves horizontally to keep up with the player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }


}
