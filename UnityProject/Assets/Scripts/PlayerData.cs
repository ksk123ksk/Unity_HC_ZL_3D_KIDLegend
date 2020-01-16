using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "玩家資料", menuName = "夜影/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量"), Range(200, 10000)]
    public float hp;

    public float Maxhp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
