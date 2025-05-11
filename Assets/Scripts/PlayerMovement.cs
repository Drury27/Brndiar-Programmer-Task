using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    public float inertia;
    [HideInInspector] public float inertiaModifier;

    public float runSpeed;
    public float defaultGravity;

    Rigidbody2D thisBody;
    SpriteRenderer thisSprite;
    Animator anim;

    void Start()
        {
        thisBody = GetComponent<Rigidbody2D>();
        thisSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        }


    void Update()
        {
        // Grab input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Flip sprite based on movement direction
        if (horizontalInput > 0f)
            thisSprite.flipX = false;
        if (horizontalInput < 0f)
            thisSprite.flipX = true;

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
    }
