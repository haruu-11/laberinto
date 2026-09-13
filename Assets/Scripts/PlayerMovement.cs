
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 5f;

//    private Rigidbody2D rb;
//    private Animator animator;
//    private SpriteRenderer spriteRenderer;

//    private Vector2 movement;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//        spriteRenderer =
//            GetComponent<SpriteRenderer>();
//    }

//    void Update()
//    {
//        movement.x =
//            Input.GetAxisRaw("Horizontal");

//        movement.y =
//            Input.GetAxisRaw("Vertical");

//        animator.SetBool(
//            "isWalking",
//            movement != Vector2.zero
//        );

//        // mirar izquierda/derecha
//        if (movement.x < 0)
//        {
//            spriteRenderer.flipX = true;
//        }
//        else if (movement.x > 0)
//        {
//            spriteRenderer.flipX = false;
//        }
//    }

//    void FixedUpdate()
//    {
//        rb.MovePosition(
//            rb.position +
//            movement * speed * Time.fixedDeltaTime
//        );
//    }
//}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    private bool squishing = false;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalScale = transform.localScale;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetBool(
            "isWalking",
            movement != Vector2.zero
        );

        // mirar izquierda/derecha
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;
    }

    void FixedUpdate()
    {
        Vector2 nextPos =
            rb.position +
            movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(nextPos);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")
            && !squishing)
        {
            StartCoroutine(Squish());
        }
    }

    IEnumerator Squish()
    {
        squishing = true;

        transform.localScale =
            new Vector3(
                originalScale.x * 1.4f,
                originalScale.y * 0.6f,
                originalScale.z
            );

        yield return new WaitForSeconds(0.12f);

        transform.localScale = originalScale;

        squishing = false;
    }
}