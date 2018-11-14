using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Core;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

/*-----------------------------------------------------
 * 
 * Class: GS_AchievementManager
 * 
 * Description: Handles cloud achievement Updating and Loading (ToDo: Saving?) 
 * 
 * Author: Matthew K. Greene
 * 
 * Last Edited: 11/7/2018
 * 
 * ---------------------------------------------------*/

public class GS_AchievementManager : MonoBehaviour
{

    public static GS_AchievementManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GameSparks.Api.Messages.AchievementEarnedMessage.Listener += AchievementMessageHandler;
    }

    /// <summary>
    /// Calls UpdateAchievement event on cloud with params
    /// </summary>
    /// <param name="name"></param>
    /// <param name="amount"></param>
    public void UpdateAchievement(string name, int amount)
    {
        // Call Cloud Event
        // SetEventKey : This is the name of the event to call
        // SetEventAttribute : Sets the attribute when calling
        new LogEventRequest()
        .SetEventKey("UpdateAchievement")
        .SetEventAttribute("name", name)
        .SetEventAttribute("amount", amount)
        .Send((response) => {
            if (!response.HasErrors)
            {
                GSData scriptData = response.ScriptData;
                Debug.Log("Event ran");
            }
            else
            {
                Debug.Log("Problem with server event");
            }
        });
    }

    /// <summary>
    /// Loads achievements into player prefs
    /// </summary>
    //https://docs.gamesparks.com/getting-started/using-cloud-code/unity-cloud-code.html#saving-player-data
    public void LoadAchievements()
    {
        new LogEventRequest()
            .SetEventKey("LoadAchievements")
            .Send((response) => {
                if (!response.HasErrors)
                {
                    GSData scriptData = response.ScriptData;
                    Debug.Log("SoulEater progress: " + scriptData.GetInt("SoulEater"));

                    //assign that value to the achievemetns in the player prefs
                    //save it client side
                }
                else
                {

                }
            });
    }

    public void RemoveAchievement(string name)
    {
        Debug.Log("Clicked");
        new LogEventRequest()
            .SetEventKey("RemoveAchievement")
            .SetEventAttribute("name", name)
            .Send((response) => { //is there a response coming back?
                if (!response.HasErrors)
                {
                    GSData scriptData = response.ScriptData; //script data coming back from response
                    Debug.Log(name + " achievement removed"); //the current value of the achievement
                    Debug.Log(name + " progress: " + scriptData.GetInt(name));
                }
                else
                {
                    Debug.Log("Remove achievement was not called on the server.");
                }
            });
    }

    void AchievementMessageHandler(GameSparks.Api.Messages.AchievementEarnedMessage _message)
    {
        Debug.Log("Awarded achievement \n: " + _message);
    }
}
