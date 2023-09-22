using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = false;
    private Animator animator;
    private Transform targetChest;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isMoving && targetChest != null)
        {
            // Calculate direction to move towards the selected chest
            Vector3 moveDirection = (targetChest.position - transform.position).normalized;

            // Move the Player
            //transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // Check if the Player has reached the chest
            if (Vector3.Distance(transform.position, targetChest.position) < 0.1f)
            {
                // Player has reached the chest
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == targetChest.gameObject)
        {
            isMoving = false;
            animator.SetBool("isWaving", true);
            Debug.Log("Player reached the chest!");
        }
    }
   

    private void FixedUpdate()
    {
        if(isMoving && targetChest != null)
        {
            if (transform.position.x > targetChest.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
            }
            else if (transform.position.x < targetChest.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
            }

        }
    }

    public void MoveTowardsChest(Transform chestTransform)
    {
        targetChest = chestTransform;
        isMoving = true;
        animator.SetBool("isMoving", true);
        animator.SetBool("isWaving", false);
    }
}
