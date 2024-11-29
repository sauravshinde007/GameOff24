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
    private bool isGrounded;

    //Plyer Inventory
    private Inventory inventory;
    private ItemWorld itemInRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);


        ItemWorld.SpawnItemWorld(new Vector3(5, -1.55f), new Item { itemType = Item.ItemType.Photo, amount = 1 });
    }

    private void Update()
    {
        //stop player movement if dialogue is playing
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //Pickup the item
        if (itemInRange != null && Input.GetButtonUp("Interact"))
        {
            Debug.Log("Picking up the item");
            inventory.AddItem(itemInRange.GetItem());
            itemInRange.DestroySelf();
            itemInRange = null; // Reset the reference
        }

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