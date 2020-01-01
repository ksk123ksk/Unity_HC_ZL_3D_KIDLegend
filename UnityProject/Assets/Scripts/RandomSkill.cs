using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSkill : MonoBehaviour
{
    [Header("技能圖片模糊與正常")]
    public Sprite[] RandomImage;
    public Sprite[] SkillImage;
    private Image Images;
    private Button button;
    

    private void Start()
    {
        Images = GetComponent<Image>();
        button = GetComponent<Button>();
        
        StartCoroutine(ImageChoose());
    }
    public IEnumerator ImageChoose()
    {
        button.interactable = false;
        for(int i = 0; i < 16; i++)
        {
            Images.sprite = RandomImage[i];
            yield return new WaitForSeconds(0.2f);
        }
        Images.sprite = SkillImage[Random.Range(0, 7)];
        button.interactable = true;
    }




}
