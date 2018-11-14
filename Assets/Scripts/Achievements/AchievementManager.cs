using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    public static AchievementManager Instance;

    // Use this for initialization
    void Awake()
    {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);

        // Add achievements to the dictionary
        achievements.Add("SoulEater", new Achievement("SoulEater", "Collect 5 Lost Souls", 5, false));

        achievements.Add("Baby Hunter", new Achievement("Baby Hunter", "Killed your first Boss!", 1, false));

        achievements.Add("Devourer of Souls", new Achievement("Devourer of Souls", "Collect 50 Lost Souls", 50, false)); //setting the number of times

        achievements.Add("The First of Many", new Achievement("The First of Many", "Achieved first achievement", 1, false));

        achievements.Add("Lil' Bunny", new Achievement("Lil' Bunny", "Jumped over 100 times", 101, false));

        achievements.Add("Best at Dying", new Achievement("Best at Dying", "Died over 10 times", 11, false));

        achievements.Add("Completed Tutorial", new Achievement("Completed Tutorial", "Finished the tutorial", 1, false));

        achievements.Add("Novice Hunter", new Achievement("Novice Hunter", "Killed 2 Bosses!", 2, false));
    }

    public Achievement GetAchievement(string key)
    {
        return achievements[key];
    }

    public void SaveAchievement(string title, int value)
    {
        // Find achievement in dictionary
        Achievement achievement = GetAchievement(title);

        if ((achievement.CurrentProgress + value) >= achievement.Goal && achievement.IsUnlocked == false)
        {
            UnlockAchievemnt();
        }

        achievement.CurrentProgress += value;
    }

    public void UnlockAchievemnt()
    {
        Debug.Log("Achievement Unlocked!");
    }
}
