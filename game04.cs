using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<string> inventory = new List<string>();  // Envanter listesi

    void Start()
    {
        // Başlangıçta envanterin boş olduğunu göstermek için
        Debug.Log("Envanteriniz boş.");
    }

    // Bir eşya toplandığında çağrılan fonksiyon
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))  // Eğer bir eşya toplandıysa
        {
            string itemName = collision.gameObject.name;  // Eşyanın ismini al
            AddItemToInventory(itemName);  // Envantere ekle
            Destroy(collision.gameObject);  // Eşyayı yok et
        }
    }

    // Eşyayı envantere ekle
    void AddItemToInventory(string item)
    {
        inventory.Add(item);  // Eşyayı listeye ekle
        Debug.Log(item + " envantere eklendi!");
    }

    // Eşyayı kullanma fonksiyonu
    public void UseItem(string item)
    {
        if (inventory.Contains(item))  // Eğer eşya envanterde varsa
        {
            Debug.Log(item + " kullanıldı!");
            inventory.Remove(item);  // Eşyayı envanterden çıkar
        }
        else
        {
            Debug.Log(item + " envanterde bulunmuyor.");
        }
    }

    // Envanteri gösterme fonksiyonu
    public void ShowInventory()
    {
        Debug.Log("Envanterinizdeki eşyalar:");
        foreach (string item in inventory)
        {
            Debug.Log(item);
        }
    }
}
