using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "怪物資料", menuName="夜影/怪物資料")]
public class EnemyData : ScriptableObject
{
    [Header("移動速度"), Range(0, 10)]
    public float speed;
    [Header("血量"), Range(100, 5000)]
    public float hp;
    [Header("攻擊力"), Range(10, 1000)]
    public float atk;
    [Header("冷卻時間"), Range(1, 10)]
    public float cd;
    [Header("停止距離"), Range(1, 100)]
    public float stopDistance;

    [Header("近距離攻擊")]
    public float attackY;
    public float attackLength;
    public float attackDelay;

    [Header("遠距離攻擊前方位移")]
    public float attackZ;

    [Header("遠距離子彈速度"), Range(0, 5000)]
    public int bulletPower;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
