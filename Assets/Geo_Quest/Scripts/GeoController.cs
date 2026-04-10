using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GeoController : MonoBehaviour
{

    [Header("Movement")]

    public int speed = 5;

    public float jumpForce = 4f;

    public string Next_Level = "Geo_Quest_Scene_2";



    [Header("Ground Detection")]

    public Transform groundCheck;

    public float checkRadius = 0.2f;

    public LayerMask whatIsGround;

    private bool isGrounded;



    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;



    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Add this line to stop the rolling:
        rb.freezeRotation = true;
    }



    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // ADD THIS LINE:
            spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        // ALSO ADD THIS LINE AT THE BOTTOM OF UPDATE:
        HandleColorSwap();
        // 1. Detect ground first
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // 2. Get Input
        float xInput = Input.GetAxis("Horizontal");

        // 3. APPLY HORIZONTAL MOVEMENT
        // We set the velocity here...
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        // 4. APPLY JUMP (Must come AFTER or be combined)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // This overrides the Y velocity we just set above
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }



    void HandleColorSwap()
    {
        // If 1, 2, or 3 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Set to a random bright color
            spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Death"))

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);



        if (collision.CompareTag("Finish"))

            SceneManager.LoadScene(Next_Level);

    }

}