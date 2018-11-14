using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTest : MonoBehaviour
{

    void Start()
    {
        /*
        Achievement achievement = new Achievement();
        Debug.Log(achievement.Title);

        Achievement newAchievement = new Achievement("Apple Finder", "Find 12 apples", 12, false);
        Debug.Log(newAchievement.Title);
        */

        Achievement achievement = AchievementManager.Instance.GetAchievement("SoulEater");
        Debug.Log("The Soul Eater achievement goal is : " + achievement.Goal);   //can put under pick up tiems scripts.



        Achievement achievement2 = AchievementManager.Instance.GetAchievement("Baby Hunter");
        Debug.Log("The Baby Hunter achievement goal is : " + achievement.Goal);


        Achievement achievement3 = AchievementManager.Instance.GetAchievement("Devourer of Souls");
        Debug.Log("The Devourer of Souls achievement goal is : " + achievement.Goal);



        Achievement achievement4 = AchievementManager.Instance.GetAchievement("The First of Many");
        Debug.Log("The First of Many achievement goal is : " + achievement.Goal);


        Achievement achievement5 = AchievementManager.Instance.GetAchievement("Lil' Bunny");
        Debug.Log("The Lil' Bunny achievement goal is : " + achievement.Goal);


        Achievement achievement6 = AchievementManager.Instance.GetAchievement("Best at Dying");
        Debug.Log("The Best at Dying achievement goal is : " + achievement.Goal);


        Achievement achievement7 = AchievementManager.Instance.GetAchievement("Completed Tutorial");
        Debug.Log("The Completed Tutorial achievement goal is : " + achievement.Goal);


        Achievement achievement8 = AchievementManager.Instance.GetAchievement("Novice Hunter");
        Debug.Log("The Novice Hunter achievement goal is : " + achievement.Goal);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Achievement achievement = AchievementManager.Instance.GetAchievement("SoulEater");
            AchievementManager.Instance.SaveAchievement("SoulEater", 1);
            //FOR CLOUD\\   
            GS_AchievementManager.instance.UpdateAchievement("SoulEater", 1);
            GS_AchievementManager.instance.LoadAchievements();

        }

        //TO REMOVE ACHIEVEMENT DEBUGGING PURPOSES\\
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GS_AchievementManager.instance.RemoveAchievement("SoulEater");
        }




        if (Input.GetMouseButtonDown(1))
        {
            //Achievement achievement2 = AchievementManager.Instance.GetAchievement("Baby Hunter");
            //AchievementManager.Instance.SaveAchievement("Baby Hunter", 1);
            GS_AchievementManager.instance.UpdateAchievement("Baby Hunter", 1);
        }





        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Achievement achievement3 = AchievementManager.Instance.GetAchievement("Devourer of Souls");
            AchievementManager.Instance.SaveAchievement("Devourer of Souls", 1);
        }





        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Achievement achievement4 = AchievementManager.Instance.GetAchievement("The First of Many");
            AchievementManager.Instance.SaveAchievement("The First of Many", 1);
        }





        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Achievement achievement5 = AchievementManager.Instance.GetAchievement("Lil' Bunny");
            AchievementManager.Instance.SaveAchievement("Lil' Bunny", 1);
        }



        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Achievement achievement6 = AchievementManager.Instance.GetAchievement("Best at Dying");
            AchievementManager.Instance.SaveAchievement("Best at Dying", 1);
        }


        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Achievement achievement7 = AchievementManager.Instance.GetAchievement("Completed Tutorial");
            AchievementManager.Instance.SaveAchievement("Completed Tutorial", 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Achievement achievement8 = AchievementManager.Instance.GetAchievement("Novice Hunter");
            AchievementManager.Instance.SaveAchievement("Novice Hunter", 1);
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("SoulEater");
            PlayerPrefs.DeleteKey("Baby Hunter");
            PlayerPrefs.DeleteKey("Devourer of Souls");
            PlayerPrefs.DeleteKey("The First of Many");
            PlayerPrefs.DeleteKey("Lil' Bunny");
            PlayerPrefs.DeleteKey("Best at Dying");
            PlayerPrefs.DeleteKey("Completed Tutorial");
            PlayerPrefs.DeleteKey("Novice Hunter");
        }
    }
}
