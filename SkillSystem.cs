using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public List<Skill> availableSkills = new List<Skill>(); // Oyuncunun öğrenebileceği yetenekler
    public int playerMana = 100; // Oyuncunun sahip olduğu mana miktarı
    public int playerExperience = 500; // Oyuncunun sahip olduğu deneyim puanı

    // Yeni bir yetenek ekleme
    public void LearnSkill(Skill newSkill)
    {
        availableSkills.Add(newSkill);
        Debug.Log(newSkill.skillName + " öğrenildi!");
    }

    // Yetenek kullanma
    public void UseSkill(string skillName)
    {
        Skill skillToUse = FindSkill(skillName);
        if (skillToUse != null && skillToUse.manaCost <= playerMana)
        {
            playerMana -= skillToUse.manaCost;
            Debug.Log(skillToUse.skillName + " kullanıldı! Kalan mana: " + playerMana);
        }
        else if (skillToUse != null && skillToUse.manaCost > playerMana)
        {
            Debug.Log("Yeterli mana yok!");
        }
        else
        {
            Debug.Log(skillName + " yeteneği bulunamadı.");
        }
    }

    // Yetenek seviyesi artırma
    public void LevelUpSkill(string skillName)
    {
        Skill skillToLevelUp = FindSkill(skillName);
        if (skillToLevelUp != null)
        {
            skillToLevelUp.LevelUp(playerExperience);
        }
    }

    // Yetenek arama
    public Skill FindSkill(string skillName)
    {
        foreach (Skill skill in availableSkills)
        {
            if (skill.skillName == skillName)
            {
                return skill;
            }
        }
        return null;
    }

    // Tüm yetenekleri gösterme
    public void ShowSkills()
    {
        Debug.Log("Öğrenilen Yetenekler:");
        foreach (Skill skill in availableSkills)
        {
            Debug.Log(skill.skillName + " - Seviye: " + skill.skillLevel + "/" + skill.maxSkillLevel);
        }
    }
}
