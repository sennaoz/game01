using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;  // Görevin adı
    public string questDescription;  // Görevin açıklaması
    public bool isCompleted;  // Görevin tamamlanıp tamamlanmadığını belirler
    public int experienceReward;  // Görev tamamlandığında kazanılacak deneyim puanı
    public int goldReward;  // Görev tamamlandığında kazanılacak altın miktarı

    public Quest(string name, string description, int xpReward, int goldReward)
    {
        questName = name;
        questDescription = description;
        isCompleted = false;
        experienceReward = xpReward;
        goldReward = goldReward;
    }

    // Görev tamamlandığında ödül ver
    public void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log(questName + " görevi tamamlandı! Ödüller: " + experienceReward + " XP, " + goldReward + " Altın.");
    }
}
