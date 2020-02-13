using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈傷害
    /// </summary>
    public float damage;
    /// <summary>
    /// 是否為玩家的武器,true玩家的,false敵人的
    /// </summary>
    public bool player;

    /// <summary>
    /// 有勾選IsTrigger的物件,有偵測碰到其他物件時執行一次
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!player && other.name == "鼠王")                         //如果碰到.名稱="鼠王"
        {
            other.GetComponent<Player>().Hit(damage);     //取得<玩家>().受傷(傷害值)
            Destroy(gameObject);
        }
        if (player && other.tag == "enemy")                         //如果碰到.名稱="鼠王"
        {
            other.GetComponent<Enemy>().Hit(damage);     //取得<玩家>().受傷(傷害值)
            Destroy(gameObject);
        }
    }
}
