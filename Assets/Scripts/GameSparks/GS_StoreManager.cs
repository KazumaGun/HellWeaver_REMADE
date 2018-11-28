using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import the gamesparks namespaces
using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

/*-----------------------------------------------------
 * 
 * Class: GS_StoreManager
 * 
 * Description: Handles in app purchasing
 * 
 * Author: 
 * 
 * Last Edited: 
 * 
 * ---------------------------------------------------*/


public class GS_StoreManager : MonoBehaviour
{

    public static GS_StoreManager instance = null;
    private long? currencyAmount = 0;
    private bool hasGood = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    public long? GetCurrencyAmount(string name)
    {
        // Account Details Request
        // https://docs.gamesparks.com/api-documentation/request-api/player/accountdetailsrequest.html
        new AccountDetailsRequest()
        .Send((response) =>
        {
            if(!response.HasErrors)
            {
                //get curreny ammount
                currencyAmount = response.Currencies.GetLong(name);
            }
            else
            {
                Debug.Log("No currency information available");
            }
        });


        return currencyAmount;
    }



    public bool HasGood(string name) //player must have item
    {
        // Account Details Request
        // https://docs.gamesparks.com/api-documentation/request-api/player/accountdetailsrequest.html
        new AccountDetailsRequest()
        .Send((response) =>
    {
        if (!response.HasErrors)
        {
            GSData virtualGoods = response.VirtualGoods;
            hasGood = virtualGoods.ContainsKey(name);
        }
        else
        {
            hasGood = false;
        }



    });
        return hasGood;
    }




        public void PurchaseGood(string name)
    {
        // BuyVirtualGoodsRequest
        // https://docs.gamesparks.com/api-documentation/request-api/store/buyvirtualgoodsrequest.html

        new BuyVirtualGoodsRequest()
        .SetCurrencyShortCode("Soul")
        .SetQuantity(1)
        .SetShortCode(name)
        .Send((response) => 
        {
            if(!response.HasErrors)
            {
                Debug.Log(name + " Has been purchased! ");
            }
            else
            {
                Debug.Log(name + " Has not been purchased!");
            }
        });

    }




    public void ConsumeGood(string name)
    {
        // Consume goods request
        // https://docs.gamesparks.com/api-documentation/request-api/store/consumevirtualgoodrequest.html

        new ConsumeVirtualGoodRequest()
        .SetQuantity(1)
        .SetShortCode(name)
        .Send((response) => 
        {
            //GSData scriptData = response.ScriptData;

            if (!response.HasErrors)
            {
                Debug.Log(name + " Has been consumed! ");
            }
            else
            {
                Debug.Log(name + " Has not been consume!");
            }
        });

    }





    void CreditPlayer(int amount)
    {
        // Log event request
        // https://docs.gamesparks.com/api-documentation/request-api/player/logeventrequest.html

        new LogEventRequest()
        .SetEventKey("CreditPlayer")
        .SetEventAttribute("amount" , amount)
        .Send((response) => 
        {
            if(!response.HasErrors)
            {
                Debug.Log("PLayer credited" + amount);
                Debug.Log("Current currency amount is : " + GetCurrencyAmount("Soul"));
            }
            else
            {
                Debug.Log("Player not credited " + amount);
            }
        });



    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            PurchaseGood("Health");
            Debug.Log(" Currency Amount " + GetCurrencyAmount("Soul"));

            
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(HasGood("Health"));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ConsumeGood("Health");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            CreditPlayer(20);
        }
    }
}
