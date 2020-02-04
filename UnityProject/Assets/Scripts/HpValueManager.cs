﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HpValueManager : MonoBehaviour
{
    private Image hpBar;
    private Text hpText;
    private RectTransform hprect;

    private void Start()
    {
        hpBar = transform.GetChild(1).GetComponent<Image>();
        hpText = transform.GetChild(2).GetComponent<Text>();
        hprect = transform.GetChild(2).GetComponent<RectTransform>();

    }
    private void Update()
    {
        FixedAngle();
    }
    /// <summary>
    /// 固定角度
    /// </summary>
    private void FixedAngle()
    {
        transform.eulerAngles = new Vector3(40, 0, 0);
    }
    /// <summary>
    /// 血量顯示
    /// </summary>
    /// <param name="hpCurrent">目前血量</param>
    /// <param name="hpMax">最大血量</param>
    public void SetHp(float hpCurrent, float hpMax)
    {
        hpBar.fillAmount = hpCurrent / hpMax;
    }
    /// <summary>
    /// 傷害值顯示
    /// </summary>
    /// <param name="value">數值</param>
    /// <param name="mark">正負號</param>
    /// <param name="color">顏色</param>
    public IEnumerator ShowValue(float value,string mark,Color color)
    {
        hpText.text = mark + value;                     //更新文字
        color.a = 0;                                    //透明度=0 
        hpText.color = color;                           //更新顏色
        hprect.anchoredPosition = Vector2.up * 70;

        for(int i = 0; i < 30; i++)
        {
            hpText.color += new Color(0, 0, 0, 0.05f);  //遞增透明度
            hprect.anchoredPosition += Vector2.up * 5;
            yield return new WaitForSeconds(0.01f);     //等待
        }
        hpText.color = new Color(0, 0, 0, 0);
    }
}
