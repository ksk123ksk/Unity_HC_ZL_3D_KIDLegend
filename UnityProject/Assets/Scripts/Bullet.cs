using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈傷害
    /// </summary>
    public float damage;

    /// <summary>
    /// 有勾選IsTrigger的物件,有偵測碰到其他物件時執行一次
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "鼠王")                         //如果碰到.名稱="鼠王"
        {
            other.GetComponent<Player>().Hit(damage);     //取得<玩家>().受傷(傷害值)
        }
    }
}
