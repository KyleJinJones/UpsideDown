using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgate : MonoBehaviour
{
    private SpriteRenderer sr=null;
    [SerializeField] private Sprite goalReady=null;
    [SerializeField] private Sprite goalNotReady=null;
    [SerializeField] private PlayerController player=null;

    //Regulates the goal at the end of each level, and determines if the player is able to enter and proceed to the next level
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = goalNotReady;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    private void Update()
    {
        if (player.hasgem)
        {
            sr.sprite = goalReady;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&collision.GetComponent<PlayerController>().hasgem)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
