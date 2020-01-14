using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;
    

    private Animator ani;
    private NavMeshAgent nav;
    private Transform Player;


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

    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        Vector3 posPlayer = Player.position;
        posPlayer.y = transform.position.y;
        transform.LookAt(posPlayer);            //看向玩家
        ani.SetBool("跑步開關", true);
        nav.SetDestination(Player.position);
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        
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
