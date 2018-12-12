using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroImpController : MonoBehaviour
{
    //HERO MOVEMENTS\\
    public float heroSpeed;
    public float jumpHeight;

    private Rigidbody2D heroRigidbody;

    //HERO HEALTH\\
    public int currentHealth;
    public int maxHealth = 5;

    //FOR DAMAGE\\


    //CHECKING FOR GORUND\\
    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //JUMPING\\
    public bool doubleJump;
    public int doubleJumpValue;

    //SPRITE ANIMATIONS\\
    private Animator heroAnimator;

    //COLLECTING SOULS\\
    private SoulManager sm;

    //POWER UPS\\
    [Header("Pick Ups")]
    [SerializeField] bool speedBoost;
    [SerializeField] public float boostSpeed;
    [SerializeField] bool walkThroughBoost;
    [SerializeField] Collider2D walkThroughBoostCollider;




    void Start()
    {

        heroRigidbody = GetComponent<Rigidbody2D>();

        //SPRITE ANIMATOR\\
        heroAnimator = GetComponent<Animator>();

        //SETTING THE HEALTH AT START OF GAME\\
        currentHealth = maxHealth;

        //SOULS\\
        sm = GameObject.FindGameObjectWithTag("SoulManager").GetComponent<SoulManager>();
    }


    void FixedUpdate()
    {
       grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        //CHECKING GROUND\\
        if (grounded == true)
        {
            doubleJump = false;
        }

        //JUMPING\\
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, jumpHeight);
            Jump();
           
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
        {
            //heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, jumpHeight);
            Jump();
            doubleJump = true;

        }

        //MOVING FOR BOSS BATTLE\\
        if (Input.GetKey(KeyCode.D))
        {
            heroRigidbody.velocity = new Vector2 (heroSpeed , heroRigidbody.velocity.y);

        }
        

        if (Input.GetKey(KeyCode.A))
        {
            heroRigidbody.velocity = new Vector2(-heroSpeed, heroRigidbody.velocity.y);

        }



        //CHECKING FOR HERO HEALTH\\
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Death();
        }

        //CHECKING FOR SPEED BOOST\\
        if (!speedBoost)
        {
            heroSpeed = heroSpeed;
        }
        else
        if (speedBoost)
        {
            heroSpeed = boostSpeed;
        }


    }

     public void Jump()
    {
        heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, jumpHeight);
    }

    public void Damage(int damage) //reduced health here
    {
        currentHealth -= damage;
    }



    public void Move (float moveInpput)
    {

    }





    void Death()
    {
        //restarting the game\\
        Application.LoadLevel(Application.loadedLevel);
    }

    //HIT BACK FORCE\\
    public IEnumerator hitB(float hitBForce, float hitBPower, Vector3 hitBDirection)
    {
        float timer = 0;

        while( hitBForce > timer )
        {
            timer += Time.deltaTime;
            heroRigidbody.AddForce(new Vector3(hitBDirection.x * -100, hitBPower, transform.position.z));
        }
        yield return 0;
    } //used for hitback




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LostSoul"))
        {
            Destroy(collision.gameObject);
            sm.souls += 1;  //Adding souls to counter
        }

        if (collision.CompareTag("ImpBattleTrigger"))
        {
            Application.LoadLevel(4);
        }


       

        if (collision.gameObject.tag == "ImpBoss")
        {
            Debug.Log("Trigger Boss Anim");
        }

    }
}
