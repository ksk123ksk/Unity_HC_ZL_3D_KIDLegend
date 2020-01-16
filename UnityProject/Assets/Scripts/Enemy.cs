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


    private void Start()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = data.speed;
        Player = GameObject.Find("鼠王").transform;
        nav.stoppingDistance = data.stopDistance;

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
    private void Hit(float damage)
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
}
