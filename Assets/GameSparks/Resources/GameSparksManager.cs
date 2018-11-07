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
 * Class: GameSparksManager
 * 
 * Description: Singleton handles GameSpark services. 
 * Currently handling device regristration and authentification.
 * 
 * Author: Matthew K. Greene
 * 
 * Last Edited: 11/6/2018
 * 
 * ---------------------------------------------------*/

public class GameSparksManager : MonoBehaviour {

    public static GameSparksManager instance = null;

    // User info
    [SerializeField]
    private string displayName; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        GameSparks.Core.GS.GameSparksAvailable += GsServiceHandler; //event handler to call the service handler
	}
	
    /// <summary>
    /// Checks if the service is running befor authenticating the device
    /// </summary>
    /// <param name="available"></param>
    public void GsServiceHandler(bool available)
    {
        if(!available)
        {
            Debug.Log("GS Service Lost....");
        }
        else
        {
            AuthenticateDevice(); 
        }
    }

    /// <summary>
    /// Authenticates this device with GameSparks
    /// </summary>
    public void AuthenticateDevice()
    {
        // https://docs.gamesparks.com/api-documentation/request-api/authentication/deviceauthenticationrequest.html
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .SetDisplayName(displayName)
            .Send((response) =>
            {
                if(!response.HasErrors)
                {
                    Debug.Log("Device has been authenticated....");
                }
                else
                {
                    Debug.Log("Error authenticating device....");
                }

            });  
    }
}
