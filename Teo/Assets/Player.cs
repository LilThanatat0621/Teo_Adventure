using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip runSound, jumpSound, fireSound, dashSound, crawlSound, deathSound, spawnSound, warpSound;
    private AudioSource aSource;
    // AudioSource = source;
    public float speed = 1f;
    public float jumpSpeed = 9f;
    public float maxSpeed = 10f;
    public float jumpPower = 20f;
    public bool IsGround;
    BoxCollider2D A, B;
    public float jumpRate = 1f;
    public float nextJumpPress = 0.0f;
    public float fireRate = 0.3f;
    private float nextFire = 0.0f;

    private Rigidbody2D rigidbody2d;
    private Physics2D physics2d;
    private Animator anim;
    public LayerMask groundLayers;
    GameLogic control;
    bool walking = false;
    public GameObject HitArea;
    public int healthBar = 100;
    bool dash = false;
    public double nowSpeed = 0;
    float dashSpeed = 0;
    bool live = true;
    bool isSit = false;
    void Start()
    {
        control = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        BoxCollider2D[] temp = gameObject.GetComponents<BoxCollider2D>();
        A = temp[0];
        B = temp[1];
        aSource.clip = spawnSound;
        if (!aSource.isPlaying)
        {
            aSource.Play();
        }
    }
    public void Sit()
    {
        if(!isSit)StartCoroutine(WaitStand());
        isSit = true;
    }
    IEnumerator WaitStand()
    {
        yield return new WaitForSeconds(1);
        isSit = false;
    }
    void Update()
    {
        Vector3 NewSizeCollder = new Vector3(this.GetComponent<SpriteRenderer>().bounds.size.x / transform.localScale.x, this.GetComponent<SpriteRenderer>().bounds.size.y / transform.localScale.y, this.GetComponent<SpriteRenderer>().bounds.size.z / transform.localScale.z);
        A.size = NewSizeCollder;
        // B.size = NewSizeCollder;
        anim.SetBool ("Grounded", false);

        anim.SetFloat("Speed", (float)nowSpeed);
        anim.SetBool("Dash", dash);
        anim.SetBool("Sit", isSit);
        
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        IsGround = (rigidbody2d.velocity.y < -3);
        anim.SetBool("Grounded", !IsGround);

            anim.SetBool("Jump", false);
        
        if (state.IsName("Jump"))
        {
            aSource.clip = jumpSound;
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        if (state.IsName("Attack"))
        {
            aSource.clip = fireSound;
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        if (state.IsName("Dash"))
        {
            aSource.clip = dashSound;
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        if (state.IsName("Death"))
        {
            aSource.clip = deathSound;
            if (!aSource.isPlaying && live)
            {
                aSource.Play();
                live = false;
                control.isGameOver = true;
            }
        }
        if (state.IsName("Run"))
        {
             IsGround = true;
            aSource.clip = runSound;
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        // anim.SetBool ("Attack", false);

        // anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetFloat("Speed", (float)1);
            transform.eulerAngles = new Vector2(0, 180);

        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetFloat("Speed", (float)1);
            transform.eulerAngles = new Vector2(0, 0);

        }
        if (nowSpeed >= 1)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (walking && nowSpeed <= 1)
        {

            nowSpeed += 0.2;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.P))
        {
            Firez();
        }

        if (Input.GetKey(KeyCode.K))
        {

            Dash();

        }
        if (Input.GetKey(KeyCode.S))
        {

            Sit();

        }
        if (dash && dashSpeed <= 7)
        {
            dashSpeed += 0.5f;
        }
        if (dash && dashSpeed >= 7)
        {
            dashSpeed = 0;
            dash = false;

        }
        // if(!anim.GetBool ("ToDash"))
        transform.Translate(Vector2.right * dashSpeed * Time.deltaTime);
        if (nowSpeed >= 0 && !walking) nowSpeed -= 0.1;
        // anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

        walking = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    public void Jump()
    {
        if (Time.time > nextJumpPress)
        {
            anim.SetBool("Jump", true);
            nextJumpPress = Time.time + jumpRate;
            rigidbody2d.AddForce((Vector2.up * jumpPower) * jumpSpeed);
        }
        

    }
    
    public void Dash()
    {
        // transform.Translate(Vector2.right * speed );
        anim.SetBool("ToDash", true);
    }
    public void ToDash()
    {
        dash = true;
        anim.SetBool("ToDash", false);
    }
    public void Firez()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // Debug.Log ("Fire");
            anim.SetBool("Attack", true);
        }
    }
    public void Fire(float Degree)
    {

        Instantiate(HitArea, new Vector3(transform.position.x + 10, transform.position.y + 10, transform.position.z), Quaternion.Euler(0, 0, Degree));
        anim.SetBool("Attack", false);
    }
    public void Walk()
    {

        walking = true;
    }

    public void Fires()
    {
        if (anim.GetBool("Attack"))
        {
            if (transform.rotation.y == 0) Instantiate(HitArea, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
            else Instantiate(HitArea, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        }
        anim.SetBool("Attack", false);
    }
    public void Die()
    {

        anim.SetTrigger("Death");

        // RectTransform rectTransform = GetComponent<RectTransform> ();
        // rectTransform.Rotate (new Vector3 (0, 0, 90));

        // StartCoroutine (WaitDeath ());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.name == "Redar"){
        // 	anim.SetBool("Grounded",true);
        if (other.gameObject.name == "coin(Clone)")
        {
            //+Health,score
            Debug.Log("coin");
            control.GetItems();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == "Enemy(Clone)")
        {
            //-Health
            control.CrashFire();

            healthBar -= 20;

            if (healthBar <= 0)
            {
                healthBar = 0;
                StartCoroutine(WaitDeath());
            }
        }
        else if (other.gameObject.name == "danger" || other.tag == "Danger")
        {
            Die();
            // StartCoroutine (WaitDeath ());
        }

    }

    // void OnTriggerExit2D (Collider2D other) {

    //  	if (other.gameObject.name == "Redar"){
    //   anim.SetBool("Grounded",false);
    // 	 }

    // }

    IEnumerator WaitDeath()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(2);
        // RectTransform rectTransform = GetComponent<RectTransform> ();
        // rectTransform.Rotate (new Vector3 (0, 0, 90));
        control.isGameOver = true;
    }
    void OnGUI()
    {
        GUI.backgroundColor = Color.red;
        GUI.Button(new Rect(Screen.width - (Screen.width - 65),
                12, (healthBar / 2),
                20),
            "");
    }

}