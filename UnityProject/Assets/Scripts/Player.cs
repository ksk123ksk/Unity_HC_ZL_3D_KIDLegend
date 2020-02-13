using UnityEngine;
using System.Linq;      //引用查詢API Min.Max與ToList

public class Player : MonoBehaviour
{
    [Header("速度"), Range(0, 1500)]
    public float speed = 1.5f;
    [Header("玩家資料")]
    public PlayerData data;
    [Header("子彈")]
    public GameObject bullet;

    private Rigidbody rig;
    private FixedJoystick joystick;
    private Animator ani;            // 動畫控制器元件
    private Transform target;        // 目標物件
    private LevelManager levelManager;
    private HpValueManager hpValueManager;
    private Vector3 posBullet;
    private float timer;
    private Enemy[] enemys;
    private float[] enemysDis;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();  // 動畫控制器 = 取得元件<動畫控制器>()
        joystick = GameObject.Find("虛擬搖桿").GetComponent<FixedJoystick>();
        //target = GameObject.Find("目標").GetComponent<Transform>();
        target = GameObject.Find("目標").transform;
        levelManager = FindObjectOfType<LevelManager>();            //透過類行尋找物件
        hpValueManager = GetComponentInChildren<HpValueManager>();  //尋找子物件
    }

    // 固定更新：一秒執行 50 次 - 處理物理行為
    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "轉場觸發")
        {
            StartCoroutine(levelManager.NextLevel());
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        rig.AddForce(h * speed, 0, v * speed);

        ani.SetBool("跑步開關", v != 0 || h != 0);  // 動畫控制器.設定布林值("參數名稱"，布林值)

        Vector3 pos = transform.position;                               // 玩家做標 = 變形.座標
        target.position = new Vector3(pos.x + h, 0.3f, pos.z + v);      // 目標.座標 = 新 三維向量(玩家.X + 水平，0.3f，玩家.Z + 垂直)

        //transform.LookAt(target); // 這會吃土

        Vector3 posTarget = new Vector3(target.position.x, transform.position.y, target.position.z);    // 目標座標 = 新 三維向量(目標.X，玩家.Y，目標.Z)
        transform.LookAt(posTarget);                                                                    // 玩家變形.看著(目標座標)

        if (v == 0 && h == 0) Attack();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收玩家給予的傷害值</param>
    public void Hit(float damage)
    {
        if (ani.GetBool("死亡開關")) return;
        data.hp -= damage;
        hpValueManager.SetHp(data.hp, data.Maxhp);//角色受傷血量顯示
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));//啟動協程(腳本.協程(傷害,正負號,顏色))
        if (data.hp <= 0) Dead();//角色死亡
       

    }
    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        enabled = false;                            //關閉腳本

        StartCoroutine(levelManager.ShowRevival());
    }

    public void Revival()
    {
        ani.SetBool("死亡開關", false);
        enabled = true;                             //開啟腳本
        data.hp = data.Maxhp;
        hpValueManager.SetHp(data.hp, data.Maxhp);
        levelManager.HideRevival();
    }
    private void Attack()
    {
        if (timer < data.cd)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            ani.SetTrigger("攻擊觸發");
            //取得所有敵人
            enemys = FindObjectsOfType<Enemy>();
            //取得所有敵人距離
            enemysDis = new float[enemys.Length];                                                                      //距離陣列 = 新的 浮點數陣列[數量]  
            for (int i = 0; i < enemys.Length; i++)
            {
                enemysDis[i] = Vector3.Distance(transform.position, enemys[i].transform.position);                     //距離陣列 = 三維向量.距離(A,B)
            }
            //判斷最近與面向
            float min = enemysDis.Min();                                                                               //距離陣列 = 最小值
            int index = enemysDis.ToList().IndexOf(min);                                                                  //距離陣列.轉為清單().取得資料的編號(資料)
            Vector3 enemyPos = enemys[index].transform.position;
            enemyPos.y = transform.position.y;
            transform.LookAt(enemyPos);

            //生成子彈
            posBullet = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
            Vector3 angle = transform.eulerAngles;                                                                      //三維向量 玩家角度 = 變形.歐拉角度(0~360度)
            Quaternion qua = Quaternion.Euler(angle.x + 180, angle.y, angle.z);                                         //四元角度 = 四元.歐拉()-歐拉轉為四元角度
            GameObject temp = Instantiate(bullet, posBullet, qua);                                                      //生成(物件,座標,角度)
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletPower);
            temp.AddComponent<Bullet>();
            temp.GetComponent<Bullet>().damage = data.atk;
            temp.GetComponent<Bullet>().player = true;


        }
    }
    private void OnDrawGizmos()
    {
        //圖示.顏色
        Gizmos.color = Color.red;
        //子彈作標=飛龍.座標+飛龍前方*Z+飛龍上方*Y
        posBullet = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
        //圖示.繪製球體(中心點,半徑)
        Gizmos.DrawSphere(posBullet, 0.1f);
    }
}
