using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject skill;        //隨機技能(遊戲物件)
    public GameObject objLight;     //光(遊戲物件)
   
    [Header("是否自動顯示技能")]
    public bool autoShowSkill;      
    [Header("是否自動開門")]
    public bool autoOpenDoor;
    // Start is called before the first frame update
    private Animator aniDoor;       //開啟門(動畫)

    void Start()
    {
        aniDoor = GameObject.Find("門").GetComponent<Animator>();

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
    // Update is called once per frame
    void Update()
    {
        
    }
}
