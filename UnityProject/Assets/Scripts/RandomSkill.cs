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
        button.onClick.AddListener(ChooseSkill);
        StartCoroutine(ImageChoose());
    }
    private void ChooseSkill()
    {
        panelSkill.SetActive(false);
    }

    public IEnumerator ImageChoose()
    {
        button.interactable = false;
        for (int j = 0; j < Random.Range(1, 5); j++)
        {
            for (int i = 0; i < RandomImage.Length; i++)
            {
                Images.sprite = RandomImage[i];
                aud.PlayOneShot(soundScroll, 0.2f);

                yield return new WaitForSeconds(speed);
            }
        }
        int r = Random.Range(0, SkillImage.Length);
        Images.sprite = SkillImage[r];
        aud.PlayOneShot(soundGetSkill, 0.8f);
        textSkill.text = nameSkills[r];
        button.interactable = true;
    }




}
