using UnityEngine;
using UnityEngine.Advertisements;       //引用廣告API

//C#繼承僅限一個
//C#介面無線多個
//介面interface,介面都是I開頭
//IUnityAdsListener 廣告監聽者:監聽玩家看廣告的行為
public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string googleID = "3459593";            //google play 廣告ID
    private string placementRevival = "revival";    //廣告名稱
    private Player player;

    private void Start()
    {
        Advertisement.Initialize(googleID, true);   //廣告.初始化(廣告ID,是否開啟測試)
        Advertisement.AddListener(this);
        player = FindObjectOfType<Player>();
    }
    /// <summary>
    /// 顯示復活廣告
    /// </summary>
    public void ShowADRevival()
    {
        if (Advertisement.IsReady(placementRevival))    //如果.廣告準備完畢(廣告名稱)
        {
            Advertisement.Show(placementRevival);       //顯示廣告(廣告名稱)
        }
    }

    //廣告準備完成
    public void OnUnityAdsReady(string placementId)
    {

    }  
    //廣告錯誤
    public void OnUnityAdsDidError(string message)
    {

    }
    //廣告開始
    public void OnUnityAdsDidStart(string placementId)
    {

    }
    //廣告播放完畢
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == placementRevival)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    print("失敗");
                    break;
                case ShowResult.Skipped:
                    print("略過");
                    break;
                case ShowResult.Finished:
                    print("完成");
                    player.Revival();
                    break;
            }
        }
    }
}
