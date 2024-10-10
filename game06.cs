using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Karakterin yatay hareket hızı
    public float jumpForce = 10f;  // Zıplama kuvveti
    private bool isGrounded = false;  // Karakterin yerde olup olmadığını kontrol eder

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Karakterin Rigidbody bileşenine erişim
        spriteRenderer = GetComponent<SpriteRenderer>();  // Karakterin sprite'ını kontrol etmek için
    }

    void Update()
    {
        // Karakterin sağa veya sola hareket etmesini sağlar
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Karakterin yönünü, hareket ettiği yöne göre çevirir
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }




        // Zıplama kontrolü, oyuncu yer ile temas halindeyken zıplar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;  // Zıpladığında, artık havada olduğunu gösterir
        }
    }

    // Karakterin yere temas ettiğini kontrol eden fonksiyon
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Eğer zemin ile temas ederse
        {
            isGrounded = true;  // Karakterin tekrar zıplayabileceğini gösterir
        }
    }
}
