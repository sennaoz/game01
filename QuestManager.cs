using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests = new List<Quest>();  // Aktif görevler listesi
    public int playerExperience = 0;  // Oyuncunun sahip olduğu deneyim puanı
    public int playerGold = 0;  // Oyuncunun sahip olduğu altın miktarı

    // Yeni görev ekle
    public void AddQuest(Quest newQuest)
    {
        activeQuests.Add(newQuest);
        Debug.Log(newQuest.questName + " görevi alındı!");
    }

    // Görevi tamamlama
    public void CompleteQuest(string questName)
    {
        Quest questToComplete = FindQuest(questName);
        if (questToComplete != null && !questToComplete.isCompleted)
        {
            questToComplete.CompleteQuest();
            playerExperience += questToComplete.experienceReward;
            playerGold += questToComplete.goldReward;
            Debug.Log("Deneyim: " + playerExperience + ", Altın: " + playerGold);
        }
        else if (questToComplete != null && questToComplete.isCompleted)
        {
            Debug.Log(questName + " zaten tamamlanmış.");
        }
        else
        {
            Debug.Log(questName + " görevi bulunamadı.");
        }
    }

    // Görev arama
    public Quest FindQuest(string questName)
    {
        foreach (Quest quest in activeQuests)
        {
            if (quest.questName == questName)
            {
                return quest;
            }
        }
        return null;
    }

    // Aktif görevleri göster
    public void ShowActiveQuests()
    {
        Debug.Log("Aktif Görevler:");
        foreach (Quest quest in activeQuests)
        {
            string status = quest.isCompleted ? "Tamamlandı" : "Devam Ediyor";
            Debug.Log(quest.questName + " - " + status);
        }
    }
}
