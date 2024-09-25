//fare ile fırlatma
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float launchForce = 10f;  // Fırlatma kuvveti
    private Rigidbody2D rb;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Top başlangıçta hareket etmesin
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Fareye tıklandığında
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Başlangıç noktası
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0)) // Fare bırakıldığında
        {
            if (isDragging)
            {
                endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Bitiş noktası
                direction = startPoint - endPoint; // Fırlatma yönü
                rb.isKinematic = false;  // Topu serbest bırak
                rb.AddForce(direction * launchForce, ForceMode2D.Impulse); // Topu fırlat
                isDragging = false;
            }
        }
    }

    // Fare ile çekme çizgisini çizer
    void OnDrawGizmos()
    {
        if (isDragging)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPoint, Camera.main.ScreenToWorldPoint(Input.mousePosition)); // Çekme yönü çizgisi
        }
    }
}
