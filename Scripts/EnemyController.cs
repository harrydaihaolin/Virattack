using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private int enemyHealth;
    private HitSystem hitSystem;
    public Rigidbody2D rb;
    public SceneManager sceneManager;

    public int maxHealth;
    public float damagePoints;


    public bool right = false;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        this.enemyHealth = maxHealth;
    }

    private void AddDamage()
    {
        if (hitSystem.enemyOnHit())
            this.enemyHealth--;
    }

    private void KillEnemy()
    {
        if (this.enemyHealth == 0)
        {
            // set the gravity for enemy object
            this.rb.gravityScale = 1;   
        }
    }

    void OnCollosionEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KillEnemy();
        }
    }


    private void Update()
    {
       // patrol... 
    }



}
