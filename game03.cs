using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;  // Oyuncunun puanı
    public int winScore = 10;  // Oyunu kazanmak için gereken puan
    public Text scoreText;  // Puanı göstereceğimiz UI Text elementi
    public GameObject winText;  // Kazandığınızı belirten UI text

    // Başlangıçta puanı ve kazandı text'ini gizle
    void Start()
    {
        scoreText.text = "Score: " + score;
        winText.SetActive(false);
    }

    // Eğer oyuncu bir coin'e çarparsa puan artır
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);  // Coin'i yok et
            score += 1;  // Puanı artır
            scoreText.text = "Score: " + score;  // Puanı güncelle
            
            // Eğer puan istenilen seviyeye ulaştıysa oyunu kazan
            if (score >= winScore)
            {
                WinGame();
            }
        }
    }

    // Oyunu kazandığında çalışacak fonksiyon
    void WinGame()
    {
        winText.SetActive(true);  // Kazandı yazısını göster
        Time.timeScale = 0f;  // Oyunu durdur
    }
}
