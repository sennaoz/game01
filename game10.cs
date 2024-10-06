void Start()
{
    // Yeni görevler oluştur
    Quest slayDragon = new Quest("Ejderhayı Öldür", "Köyü tehdit eden ejderhayı öldür.", 500, 100);
    Quest gatherHerbs = new Quest("Ot Topla", "Büyücü için 10 ot topla.", 100, 50);

    // Görevleri ekleyin
    AddQuest(slayDragon);
    AddQuest(gatherHerbs);

    // Aktif görevleri göster
    ShowActiveQuests();
}
