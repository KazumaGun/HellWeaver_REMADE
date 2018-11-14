using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Core;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class PlayerStatsScript : MonoBehaviour
{

    public static PlayerStatsScript instance = null;

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
        GameSparks.Api.Messages.AchievementEarnedMessage.Listener += PlayerStatsMessageHandler;
    }

    /// <summary>
    /// Calls UpdateAchievement event on cloud with params
    /// </summary>
    /// <param name="name"></param>
    /// <param name="amount"></param>
    public void UpdatePlayerStats(string name, int amount)
    {
        // Call Cloud Event
        // SetEventKey : This is the name of the event to call
        // SetEventAttribute : Sets the attribute when calling
        new LogEventRequest()
        .SetEventKey("UpdatePlayerStats")
        .SetEventAttribute("name", name)
        .SetEventAttribute("amount", amount)
        .Send((response) => {
            GSData scriptData = response.ScriptData;
        });
    }

    /// <summary>
    /// Loads achievements into player prefs
    /// </summary>
    //https://docs.gamesparks.com/getting-started/using-cloud-code/unity-cloud-code.html#saving-player-data
    public void LoadPlayerStats()
    {
        new LogEventRequest()
            .SetEventKey("LoadPlayerStats")
            .Send((response) => {
                if (!response.HasErrors)
                {
                    GSData scriptData = response.ScriptData;
                    Debug.Log("PlayerStats progress: " + scriptData.GetInt("JUMPS")); //ALLOWING THE PLAYER TO UNLOCK A TOTAL OF 4 JUMPS?

                    //assign that value to the achievemetns in the player prefs
                    //save it client side
                }
                else
                {

                }
            });
    }

    void PlayerStatsMessageHandler(GameSparks.Api.Messages.AchievementEarnedMessage _message)
    {
        Debug.Log("Awarded stat - EXTRA JUMP: " + _message);
    }
}

