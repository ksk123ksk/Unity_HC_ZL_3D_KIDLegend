using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSkill : MonoBehaviour
{
    [Header("技能圖片模糊與正常")]
    public Sprite[] RandomImage;
    public Sprite[] SkillImage;
    [Header("捲動速度"),Range(0.001f,3f)]
    public float speed=0.1f;
    private Image Images;
    private Button button;
    private AudioSource aud;
    private Text textSkill;
    private string[] nameSkills = { "連續射擊", "正向箭", "背向箭", "側向箭", "血量提升", "攻擊提升", "攻速提升", "爆擊提升" };
    private GameObject panelSkill;
    private GameObject bg;
    private int index;
    [Header("音效")]
    public AudioClip soundScroll;
    public AudioClip soundGetSkill;

    

    private void Start()
    {
        Images = GetComponent<Image>();
        button = GetComponent<Button>();
        aud= GetComponent<AudioSource>();
        textSkill = transform.GetChild(0).GetComponent<Text>();
        panelSkill = GameObject.Find("隨機技能");
        bg= GameObject.Find("選擇背景");
        button.onClick.AddListener(ChooseSkill);
        StartCoroutine(ImageChoose());
    }
    private void ChooseSkill()
    {
        panelSkill.SetActive(false);                                //隱藏隨機技能物件  
        bg.SetActive(false);                                        //關閉半透明背景
        print("玩家選取的技能為" + nameSkills[index]);              //紀錄玩家選取的技能
    }

    public IEnumerator ImageChoose()
    {
        button.interactable = false;                                //按鈕取消點選
        for (int j = 0; j < Random.Range(1, 5); j++)
        {
            for (int i = 0; i < RandomImage.Length; i++)            //技能滾動
            {
                Images.sprite = RandomImage[i];
                aud.PlayOneShot(soundScroll, 0.2f);

                yield return new WaitForSeconds(speed);             //延遲時間
            }
        }
        index = Random.Range(0, SkillImage.Length);                 //隨機
        Images.sprite = SkillImage[index];                          //技能圖片
        aud.PlayOneShot(soundGetSkill, 0.8f);
        textSkill.text = nameSkills[index];                         //技能名稱
        button.interactable = true;                                 //按鈕恢復點選
    }




}
