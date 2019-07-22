using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdsManager : MonoBehaviour
{

    public static AdsManager instance;

    private string gameId = "1234567";

    private string videoAds = "video";

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {

            instance = this;
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            gameId = "3216080";
        else if (Application.platform == RuntimePlatform.Android)
            gameId = "3216081";

        Monetization.Initialize(gameId, false); //bool para testes. false = ativado p/ monetizar
    }

    public void MoneyTime()
    {

        if (Monetization.IsReady(videoAds))

        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoAds) as ShowAdPlacementContent;

            if (ad != null)
            {
                //Time.timeScale = 0;
                ad.Show();

                Firebase.Analytics.FirebaseAnalytics.LogEvent("adsPlayed");
            }
        }
    }
}
