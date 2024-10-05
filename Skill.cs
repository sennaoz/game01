using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string skillName; // Yetenek adı
    public string skillDescription; // Yetenek açıklaması
    public int manaCost; // Yetenek kullanımı için gereken mana
    public int skillLevel; // Yetenek seviyesi
    public int maxSkillLevel; // Yetenek için maksimum seviye
    public int experienceRequired; // Yetenek seviyesi atlamak için gereken deneyim puanı
    public Sprite skillIcon; // Yetenek simgesi

    public Skill(string name, string description, int mana, int level, int maxLevel, int xpRequired, Sprite icon)
    {
        skillName = name;
        skillDescription = description;
        manaCost = mana;
        skillLevel = level;
        maxSkillLevel = maxLevel;
        experienceRequired = xpRequired;
        skillIcon = icon;
    }

    // Yetenek seviyesi artırma
    public bool LevelUp(int playerExperience)
    {
        if (skillLevel < maxSkillLevel && playerExperience >= experienceRequired)
        {
            skillLevel++;
            Debug.Log(skillName + " seviyesi arttı! Yeni seviye: " + skillLevel);
            return true;
        }
        else
        {
            Debug.Log(skillName + " seviyesi en üst seviyede ya da yeterli deneyim yok.");
            return false;
        }
    }
}
