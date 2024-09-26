//Düşmanın Oyuncuyu Takip Etmesi
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  // Oyuncu karakteri
    public float moveSpeed = 3f;  // Düşmanın hareket hızı
    public float chaseRange = 5f;  // Takip etme mesafesi
    public float attackRange = 1f;  // Saldırı mesafesi

    private bool isChasing = false;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Eğer oyuncu belirli bir mesafeye girerse, takip başlar
        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // Takip modundaysa, düşman oyuncuya doğru hareket eder
        if (isChasing)
        {
            ChasePlayer();
        }

       
