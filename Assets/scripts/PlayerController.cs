using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] private float speed=5.0f;
    private bool jump=false;
    [SerializeField] private float jumpforce = 6.0f;
    private LayerMask groundmask;
    [SerializeField] private float dashspeed = 30.0f;
    public bool hasgem = false;
    [SerializeField] private float dashlength = .05f;
    private bool dashing = false;
    private float dashtimer=0.0f;
    [SerializeField]private bool alreadydashed = false;
    private float dashingdir = 0;

    //Handles Player Movement and detecting reset commands from the player
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundmask = LayerMask.GetMask("Ground");
    }

    //
    void Update()
    {
        //handles general movement, and jumping utilizing raycasting to determine if player is on the ground
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        rb.velocity = movement;


        //Handles determining if the player is on the ground, Uses two raycasts instead of one to ensure the player is able to reliably jump at edges
        RaycastHit2D groundcheck1 = Physics2D.Raycast(transform.position + new Vector3(.28f, 0, 0), new Vector2(0, -1.0f), 1.1f, groundmask);
        RaycastHit2D groundcheck2 = Physics2D.Raycast(transform.position - new Vector3(.4f, 0, 0), new Vector2(0, -1.0f), 1.1f, groundmask);
        if ((groundcheck1.collider != null && groundcheck1.collider.CompareTag("Ground"))||(groundcheck2.collider != null && groundcheck2.collider.CompareTag("Ground")))
        {
            jump = true;
            alreadydashed = false;
        }
        else
        {
            jump = false;
        }

        //Handles jump inputs from the player and adding momentum to the player
        if (jump&&Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpforce),ForceMode2D.Impulse);
            jump = false;
        }
        flipplayer();
        dash();
        restartlevel();

        
    
    }

    //Restarts the current level if the player hits r
    private void restartlevel()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
        }
    }

   //Handles flipping the player's y value if they are far enough in a direction
   private void flipplayer()
    {
        if (transform.position.y <= -7)
        {
            
            transform.position= new Vector3(transform.position.x, 11.5f, 0);
        }

        if (transform.position.y >= 12)
        {
            transform.position= new Vector3(transform.position.x, -6.5f, 0);
        }
        
    }

    //Handles Dashing by the player in the air. This is ordered last so that it can change the players vertical and horizontal velocities
    private void dash()
    {
        if (!jump)
        {
            if (dashing)
            {
                rb.velocity = new Vector2 (dashingdir * dashspeed,0.0f);
                dashtimer += Time.deltaTime;
                if (dashtimer >= dashlength)
                {
                    dashtimer = 0.0f;
                    dashing = false;
                }
            }

            if (jump==false&&alreadydashed==false&&Input.GetKey(KeyCode.LeftShift)&&Input.GetAxisRaw("Horizontal")!=0)
            {
                dashing = true;
                alreadydashed = true;
                dashingdir = Input.GetAxisRaw("Horizontal");
            }
        }
    }
}
