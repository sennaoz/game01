using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName; // Eşyanın adı
    public string itemDescription; // Eşyanın açıklaması
    public Sprite itemIcon; // Eşyanın görsel ikonu
    public bool isStackable; // Eşyanın birikip birikmeyeceğini kontrol eder (örn. iksirler birikir, silahlar birikmez)
    public int maxStackSize = 1; // Maksimum birikme miktarı (eğer stackable ise)

    public Item(string name, string description, Sprite icon, bool stackable, int maxStack)
    {
        itemName = name;
        itemDescription = description;
        itemIcon = icon;
        isStackable = stackable;
        maxStackSize = maxStack;
    }
}
