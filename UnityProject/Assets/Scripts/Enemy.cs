using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;

    

    private Animator ani;
    private NavMeshAgent nav;
    private Transform Player;
    private float timer;
    private HpValueManager hpValueManager;


    private void Start()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = data.speed;
        nav.stoppingDistance = data.stopDistance;

        Player = GameObject.Find("鼠王").transform;
        hpValueManager = GetComponentInChildren<HpValueManager>();  //尋找子物件
    }
    private void Update()
    {
        Move();
    }
    /*摺疊 Ctrl+M+O
      展開 Ctrl+M+L*/
    /// <summary>
    /// 等待
    /// </summary>
    private void Wait()
    {
        ani.SetBool("跑步開關", false);
        timer += Time.deltaTime;

        if (timer >= data.cd)
        {
            Attack();
        }
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        Vector3 posPlayer = Player.position;
        posPlayer.y = transform.position.y;
        transform.LookAt(posPlayer);            //看向玩家
        
        nav.SetDestination(Player.position);

        if (nav.remainingDistance < data.stopDistance)
        {
            Wait();
        }
        else
        {
            ani.SetBool("跑步開關", true);
        }
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    //protected 保護:允許子類別存取，禁止外部類別存取
    //virtual 虛擬:允許子類別複寫
    protected virtual void Attack()
    {
        ani.SetTrigger("攻擊觸發");
        timer = 0;
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
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
}
