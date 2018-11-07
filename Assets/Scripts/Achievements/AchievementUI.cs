using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{

    // Achievement info
    public string title;
    public Sprite lockedSprite;
    public Sprite achievementSprite;

    private AchievementManager achievementManager;
    private Achievement achievement;

    // Use this for initialization
    void LateUpdate()
    {   //ALLOWS CLICKING TO START RIGHT AWAY\\
        achievementManager = AchievementManager.Instance;
        achievement = achievementManager.GetAchievement(title);

        if (achievement.IsUnlocked)
            transform.Find("AchievementImage").GetComponent<Image>().sprite = achievementSprite;
        else
            transform.Find("AchievementImage").GetComponent<Image>().sprite = lockedSprite;

        transform.Find("TitleText").GetComponent<Text>().text = achievement.Title;
        transform.Find("DescriptionText").GetComponent<Text>().text = achievement.Description;
        transform.Find("ProgressText").GetComponent<Text>().text = achievement.CurrentProgress + "/" + achievement.Goal;
    }

}
