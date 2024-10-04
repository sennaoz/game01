[System.Serializable]
public class InventorySlot
{
    public Item item; // Bu yuvada bulunan eşya
    public int quantity; // Bu yuvada bulunan eşyanın miktarı

    public InventorySlot(Item newItem, int newQuantity)
    {
        item = newItem;
        quantity = newQuantity;
    }

    // Yuvaya yeni eşya ekleme
    public void AddToSlot(int amount)
    {
        quantity += amount;
    }

    // Eşyayı yuvadan çıkartma
    public void RemoveFromSlot(int amount)
    {
        quantity -= amount;
        if (quantity <= 0)
        {
            ClearSlot();
        }
    }

    // Yuvarı temizleme
    public void ClearSlot()
    {
        item = null;
        quantity = 0;
    }
}
