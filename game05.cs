using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public int playerHealth = 100;  // Oyuncunun canı
    public int enemyHealth = 100;  // Düşmanın canı
    public int playerDamage = 10;  // Oyuncunun verdiği hasar
    public int enemyDamage = 15;  // Düşmanın verdiği hasar

    // Oyuncunun düşmana saldırdığı fonksiyon
    public void PlayerAttack()
    {
        enemyHealth -= playerDamage;  // Düşmana hasar ver
        Debug.Log("Oyuncu saldırdı! Düşmanın canı: " + enemyHealth);

        if (enemyHealth <= 0)
        {
            EnemyDie();  // Düşman öldü
        }
        else
        {
            EnemyAttack();  // Eğer düşman hala yaşıyorsa, o da oyuncuya saldırır
        }
    }

    // Düşmanın oyuncuya saldırdığı fonksiyon
    public void EnemyAttack()
    {
        playerHealth -= enemyDamage;  // Oyuncuya hasar ver
        Debug.Log("Düşman saldırdı! Oyuncunun canı: " + playerHealth);

        if (playerHealth <= 0)
        {
            PlayerDie();  // Oyuncu öldü
        }
    }

    // Düşman öldüğünde çalışacak fonksiyon
    void EnemyDie()
    {
        Debug.Log("Düşman öldü!");
        // Düşman öldüğünde yapılacak işlemler buraya eklenebilir.
    }

    // Oyuncu öldüğünde çalışacak fonksiyon
    void PlayerDie()
    {
        Debug.Log("Oyuncu öldü!");
        // Oyuncu öldüğünde yapılacak işlemler buraya eklenebilir.
    }
}
