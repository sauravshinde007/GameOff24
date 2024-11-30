using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck; // Reference to a ground check point
    [SerializeField] private float groundCheckRadius = 0.2f; // Radius for ground detection
    [SerializeField] private LayerMask groundLayer; // Define what counts as ground

    [Header("Inventory")]
    [SerializeField] private UI_Inventory uiInventory;

    // To track the clue the player can interact with
    //private Clue clueInRange;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private bool isGrounded;
    private float moveInput;

    //Plyer Inventory
    private Inventory inventory;
    private ItemWorld itemInRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

    }

    private void Update()
    {
        //stop player movement if dialogue is playing
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        // Horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //Pickup the item
        if (itemInRange != null && Input.GetButtonUp("Interact"))
        {
            Debug.Log("Picking up the item");
            inventory.AddItem(itemInRange.GetItem());
            itemInRange.DestroySelf();
            itemInRange = null; // Reset the reference
        }

        PlayerAnimations();

    }

    private void FixedUpdate()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            itemInRange = itemWorld; // Save reference to the item
        }

    }

    private void PlayerAnimations()
    {
        if(moveInput > 0)
        {
            anim.SetBool("Walk", true);
            sr.flipX = false;
        }else if (moveInput < 0)
        {
            anim.SetBool("Walk", true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }


    private void OnDrawGizmos()
    {
        // Visualize ground check in the editor
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}