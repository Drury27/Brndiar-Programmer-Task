using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    float horizontalInput;
    float verticalInput;

    public float inertia;
    float inertiaModifier;

    public float runSpeed;
    public float defaultGravity;

    bool flipped;

    Rigidbody2D thisBody;
    SpriteRenderer[] playerSprites;
    Animator anim;

    void Start()
        {
        thisBody = GetComponent<Rigidbody2D>();
        playerSprites = GetComponentsInChildren<SpriteRenderer>(true);
        anim = GetComponent<Animator>();
        }


    void Update()
        {
        // Grab input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Flip sprites based on movement direction
        if (horizontalInput > 0f)
            {
            flipped = false;
            }
        if (horizontalInput < 0f)
            {
            flipped = true;
            }
        foreach (var sprite in playerSprites)
            {
            sprite.flipX = flipped;
            }

        anim.SetBool("Running", (Input.GetAxisRaw("Horizontal") != 0) ? true : false);
        }


    private void FixedUpdate()
        {
        // Calculate inertia
        inertiaModifier += inertia * horizontalInput;
        inertiaModifier = Mathf.Clamp(inertiaModifier, -1, 1);

        // Kill inertia if no key is being held
        if (horizontalInput == 0
            || (inertiaModifier < 0 && horizontalInput > 0)
            || (inertiaModifier > 0 && horizontalInput < 0))
            {
            inertiaModifier = 0;
            }

        // Apply gravity
        thisBody.gravityScale = defaultGravity;

        // Apply movement
        thisBody.linearVelocity = new Vector2(runSpeed * inertiaModifier, thisBody.linearVelocity.y);
        }
    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.CompareTag("Goal"))
            {
            SceneManager.LoadScene(1);
            }
        }
    }
