using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpHeight;
    public int maxHealth;

    public SceneManager sceneManager;
    //public Scene scene;

    private bool doubleJumped;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private int playerHealth;

    public Rigidbody2D rb;
    public GameObject player;
    private Animator anim;
    private bool grounded; 
    public float Timer = 0.5f;
    public GameObject bullet1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.playerHealth = maxHealth;
    }

    private void HorizontalMove() 
    {
        float HDirection = Input.GetAxis("Horizontal");

        if (HDirection < 0)
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);   
           // transform.localScale = new Vector2(-0.09, 0.09);
            anim.SetBool("running", true);
        } else if (HDirection > 0)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
           // transform.localScale = new Vector2(1, 1);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        } 
    }

    public void EnableJumpOnFinalScene()
    {
        if (Input.GetKey(KeyCode.W))
        {
            HorizontalMove();
            rb.velocity = new Vector2(0, 5);
        }
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Vector3 temp1 = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.2f, transform.position.z);
            Vector3 temp2 = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.2f, transform.position.z);

            GameObject a = (GameObject)Instantiate(bullet1, temp1, Quaternion.identity);


            a.GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 0.0f) * 5;


            GameObject b = (GameObject)Instantiate(bullet1, temp2, Quaternion.identity);


            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.0f, 0.0f) * 5;
            Timer = 0.5f;
        }

        if (grounded)
        {
            doubleJumped = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        HorizontalMove();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player Health: " + this.playerHealth);
            this.playerHealth--;
            if (this.playerHealth <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }


}

