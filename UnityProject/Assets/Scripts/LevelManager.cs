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
    [Header("復活介面")]
    public GameObject panelRevival;
    // Start is called before the first frame update
    private Animator aniDoor;       //開啟門(動畫)
    private Image imgCross;         

    void Start()
    {
        aniDoor = GameObject.Find("門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();

        if (autoShowSkill) ShowSkill();

        if (autoOpenDoor) Invoke("OpenDoor", 6);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
