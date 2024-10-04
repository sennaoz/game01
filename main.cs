void Start()
{
    // Yeni bir eşya oluştur
    Item healthPotion = new Item("Sağlık İksiri", "50 sağlık kazandırır", null, true, 5);
    Item sword = new Item("Kılıç", "Bir saldırı silahı", null, false, 1);

    // Envantere ekleyin
    AddItem(healthPotion, 3);  // 3 adet sağlık iksiri ekle
    AddItem(sword, 1);  // 1 adet kılıç ekle
}
