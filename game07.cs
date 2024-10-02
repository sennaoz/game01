using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Görev sınıfı, her görevi temsil eder
[System.Serializable]
public class Quest
{
    public string questName;  // Görevin adı
    public string questDescription;  // Görevin açıklaması
    public bool isCompleted;  // Görevin tamamlanıp tamamlanmadığını kontrol eder
    public int reward;  // Görevi tamamladığında alınacak ödül

    // Görev tamamlanma kontrolü
    public void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log(questName + " görevi tamamlandı! Ödül: " + reward);
    }
}

public class QuestSystem : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();  // Oyuncunun görev listesi
    public int playerExperience = 0;  // Oyuncunun kazandığı deneyim puanı

    void Start()
    {
        // Başlangıçta görevlerin durumunu kontrol et
        foreach (Quest quest in questList)
        {
            if (quest.isCompleted)
            {
                Debug.Log(quest.questName + " görevi zaten tamamlanmış.");
            }
            else
            {
                Debug.Log(quest.questName + " görevi bekleniyor.");
            }
        }
    }

    // Yeni bir görevi oyuncuya ekler
    public void AddQuest(Quest newQuest)
    {
        questList.Add(newQuest);
        Debug.Log(newQuest.questName + " görevi alındı!");
    }

    // Görevi tamamladığında çağrılır
    public void CompleteQuest(string questName)
    {
        foreach (Quest quest in questList)
        {
            if (quest.questName == questName && !quest.isCompleted)
            {
                quest.CompleteQuest();
                playerExperience += quest.reward;  // Ödülü oyuncuya verir
                Debug.Log("Oyuncunun yeni deneyimi: " + playerExperience);
                return;
            }
        }
        Debug.Log(questName + " görevi bulunamadı ya da zaten tamamlanmış.");
    }

    // Tüm görevleri listeleme fonksiyonu
    public void ShowAllQuests()
    {
        Debug.Log("Görevler Listesi:");
        foreach (Quest quest in questList)
        {
            string status = quest.isCompleted ? "Tamamlandı" : "Tamamlanmadı";
            Debug.Log(quest.questName + ": " + status);
        }
    }

    // Görev durumunu kontrol etme (eğer bir düşmanı öldürmek, bir nesneyi toplamak gibi bir görevse)
    public bool IsQuestCompleted(string questName)
    {
        foreach (Quest quest in questList)
        {
            if (quest.questName == questName && quest.isCompleted)
            {
                return true;
            }
        }
        return false;
    }
}
