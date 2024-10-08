using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();  // Envanterdeki eşyalar listesi
    public int maxInventorySize = 20;  // Envanterde taşınabilecek maksimum eşya sayısı

    // Eşya ekleme
    public void AddItem(Item newItem)
    {
        // Envanterde aynı eşyadan varsa ve biriktirilebilirse miktarını artır
        Item existingItem = FindItem(newItem.itemName);
        if (existingItem != null && newItem.isStackable)
        {
            existingItem.itemQuantity += newItem.itemQuantity;
            Debug.Log(newItem.itemQuantity + " adet " + newItem.itemName + " envantere eklendi. Toplam: " + existingItem.itemQuantity);
        }
        // Envanterde yoksa yeni eşya ekle
        else
        {
            if (inventoryItems.Count < maxInventorySize)
            {
                inventoryItems.Add(newItem);
                Debug.Log(newItem.itemName + " envantere eklendi.");
            }
            else
            {
                Debug.Log("Envanter dolu! " + newItem.itemName + " eklenemedi.");
            }
        }
    }

    // Eşya kullanma
    public void UseItem(string itemName)
    {
        Item itemToUse = FindItem(itemName);
        if (itemToUse != null && itemToUse.itemQuantity > 0)
        {
            itemToUse.UseItem();
            itemToUse.itemQuantity--;

            // Eşya miktarı sıfırsa envanterden çıkar
            if (itemToUse.itemQuantity == 0)
            {
                inventoryItems.Remove(itemToUse);
                Debug.Log(itemToUse.itemName + " tükendi ve envanterden çıkarıldı.");
            }
        }
        else
        {
            Debug.Log(itemName + " envanterde yok ya da miktarı sıfır.");
        }
    }

    // Eşya arama
    public Item FindItem(string itemName)
    {
        foreach (Item item in inventoryItems)
        {
            if (item.itemName == itemName)
            {
                return item;
            }
        }
        return null;
    }

    // Envanteri gösterme
    public void ShowInventory()
    {
        Debug.Log("Envanterdeki Eşyalar:");
        foreach (Item item in inventoryItems)
        {
            Debug.Log(item.itemName + " - Miktar: " + item.itemQuantity);
        }
    }
}
