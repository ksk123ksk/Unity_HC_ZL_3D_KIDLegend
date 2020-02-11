using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject skill;        //隨機技能(遊戲物件)
    public GameObject objLight;     //光(遊戲物件)
   
    [Header("是否自動顯示技能")]
    public bool autoShowSkill;      
    [Header("是否自動開門")]
    public bool autoOpenDoor;
    [Header("復活介面,復活按鈕")]
    public GameObject panelRevival;
    public Button btnRevival;
    // Start is called before the first frame update
    private Animator aniDoor;       //開啟門(動畫)
    private Image imgCross;
    private AdManager adManager;    //廣告管理器

    void Start()
    {
        aniDoor = GameObject.Find("門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();

        if (autoShowSkill) ShowSkill();                                 //如果是顯示技能呼叫顯示技能方法
                
        if (autoOpenDoor) Invoke("OpenDoor", 6);                        //如果是自動開門延遲呼叫開門方法

        adManager = FindObjectOfType<AdManager>();                        //透過類行尋找物件<廣告管理器>
        btnRevival.onClick.AddListener(adManager.ShowADRevival);        //按鈕.點擊.增加監聽者(廣告管理器.顯示復活廣告)
    }

    private void ShowSkill()
    {
        skill.SetActive(true);
    }

    private void OpenDoor()
    {
        objLight.SetActive(true);
        aniDoor.SetTrigger("開門觸發");
    }

    public IEnumerator NextLevel()
    {
        for(int i=0;i<20 ;i++)
        {
            imgCross.color += new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("關卡2");
    }
    /// <summary>
    /// 顯示復活畫面
    /// </summary>
    /// <returns></returns>
    public IEnumerator ShowRevival()
    {
        panelRevival.SetActive(true);
        Text textSecond = panelRevival.transform.GetChild(1).GetComponent<Text>();

        for(int i = 3; i > 0; i--)
        {
            textSecond.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void HideRevival()
    {
        StopCoroutine(ShowRevival());
        panelRevival.SetActive(false);
    }
    
}
