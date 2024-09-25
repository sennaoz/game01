//Temel Hareket Mekanikleri
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı
    public float jumpForce = 10f; // Zıplama kuvveti
    private Rigidbody2D rb;
    private bool isGrounded;

    // Start fonksiyonu oyunun başında bir kere çalışır
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update her frame'de bir kez çalışır
    void Update()
    {
        Move(); 
        Jump();
    }

    // Karakterin sağa ve sola hareket etmesini sağlar
    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Karakterin zıplamasını sağlar
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Karakterin zemine çarptığını kontrol eder
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
