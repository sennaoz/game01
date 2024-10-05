void Start()
{
    // Yeni bir yetenek oluştur
    Skill fireball = new Skill("Ateş Topu", "Düşmana ateş topu fırlatır", 20, 1, 5, 100, null);
    Skill heal = new Skill("İyileştirme", "Oyuncunun sağlığını iyileştirir", 30, 1, 3, 150, null);

    // Yetenekleri öğren
    LearnSkill(fireball);
    LearnSkill(heal);

    // Tüm yetenekleri göster
    ShowSkills();
}
