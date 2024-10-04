using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(); // Tüm envanter yuvaları
    public int maxInventorySize = 20; // Envanterin maksimum kapasitesi

    // Envantere eşya ekleme
    public bool AddItem(Item newItem, int amount)
    {
        // Eğer eşya stackable (birikmeli) ise
        if (newItem.isStackable)
        {
            InventorySlot existingSlot = FindItemInInventory(newItem);
            if (existingSlot != null)
            {
                // Mevcut yuvaya eşyayı ekleyin
                existingSlot.AddToSlot(amount);
                Debug.Log(newItem.itemName + " envantere eklendi. Mevcut miktar: " + existingSlot.quantity);
                return true;
            }
        }

        // Eğer yuvada yer yoksa yeni bir slot aç
        if (inventorySlots.Count < maxInventorySize)
        {
            inventorySlots.Add(new InventorySlot(newItem, amount));
            Debug.Log(newItem.itemName + " yeni yuvaya eklendi.");
            return true;
        }

        Debug.Log("Envanter dolu! " + newItem.itemName + " eklenemedi.");
        return false; // Envanter doluysa ekleme başarısız olur
    }

    // Envanterdeki bir eşyayı kullanma
    public void UseItem(Item itemToUse)
    {
        InventorySlot slot = FindItemInInventory(itemToUse);
        if (slot != null && slot.quantity > 0)
        {
            slot.RemoveFromSlot(1);
            Debug.Log(itemToUse.itemName + " kullanıldı. Kalan miktar: " + slot.quantity);
        }
        else
        {
            Debug.Log(itemToUse.itemName + " envanterde bulunamadı ya da miktar 0.");
        }
    }

    // Envanterde bir eşyanın olup olmadığını kontrol etme
    public InventorySlot FindItemInInventory(Item searchItem)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.item.itemName == searchItem.itemName)
            {
                return slot;
            }
        }
        return null;
    }

    // Envanteri gösterme
    public void ShowInventory()
    {
        Debug.Log("Envanter Listesi:");
        foreach (InventorySlot slot in inventorySlots)
        {
            Debug.Log(slot.item.itemName + " - Miktar: " + slot.quantity);
        }
    }
}
