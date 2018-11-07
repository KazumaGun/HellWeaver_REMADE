using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //HERO MOVEMENTS\\
    public float heroSpeed;
    public float jumpForce;

    private Rigidbody2D heroRigidbody;

    //HERO HEALTH\\
    public int currentHealth;
    public int maxHealth = 5;

    //FOR DAMAGE\\


    //CHECKING FOR GORUND\\
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //JUMPING\\
    private int doubleJump;
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
        //JMUPING AND MOVING\\
        doubleJump = doubleJumpValue;
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
        heroRigidbody.velocity = new Vector2(heroSpeed, heroRigidbody.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    }





    void Update()
    {
        //CHECKING GROUND\\
        if (isGrounded == true)
        {
            doubleJump = doubleJumpValue;
        }
        //JUMPING\\
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && doubleJump > 0)
        {
            heroRigidbody.velocity = Vector2.up * jumpForce;
            doubleJump--;
        }
        else
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && doubleJump == 0 && isGrounded == true)
        {
            heroRigidbody.velocity = Vector2.up * jumpForce;

        }
        heroAnimator.SetFloat("Speed", heroRigidbody.velocity.x);
        heroAnimator.SetBool("Grounded", isGrounded);

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





    //SPEED BOOST\\
    public IEnumerator SpeedBoost()
    {
        Debug.Log("SPEED BOOST");
        speedBoost = true;
        yield return new WaitForSeconds(4);
        speedBoost = false;

        //ACHIEVEMENTS\\
        Achievement achievement = AchievementManager.Instance.GetAchievement("Baby Hunter");
        Debug.Log("The Baby Hunter achievement goal is : " + achievement.Goal);
    }

    //WALK THROUGH WALLS BOOST\\
    public IEnumerator WalkThroughBoost()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        walkThroughBoost = true;
        yield return new WaitForSeconds(7);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        walkThroughBoost = false;
    }



    public void Damage(int damage) //reduced health here
    {
        currentHealth -= damage;
    }









    void Death()
    {
        //restarting the game\\
        Application.LoadLevel(Application.loadedLevel);
    }

    /*public IEnumerator hitB(float hitBForce, float hitBPower, Vector3 hitBDirection)
    {
        float timer = 0;

        while( hitBForce > timer )
        {
            timer += Time.deltaTime;
            heroRigidbody.AddForce(new Vector3(hitBDirection.x * -100, hitBPower, transform.position.z));
        }
        yield return 0;
    }*/ //used for hitback




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


        if (gameObject.tag == "SpeedBoost")
        {


        }

    }
}
