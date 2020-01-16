using UnityEngine;
using System.Collections;


public class EnemyNear : Enemy
{
    //override 複寫:複寫父類別有virtual的成員
    protected override void Attack()
    {
        //父類別原本的敘述或演算法
        base.Attack();
        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(data.attackDelay);

        RaycastHit hit;//區域變數 碰撞資訊:用來存放射線打到的物件

        //out 參數修飾詞:保存方法的資訊在區域變數內
        //物理.射線(起點,方向,碰撞資訊,長度)

        if (Physics.Raycast(transform.position + Vector3.up * data.attackY, transform.forward, out hit, data.attackLength))
        {
            hit.collider.GetComponent<Player>().Hit(data.atk);
        }
    }

    //繪製圖示:只會在場景顯示,供開發者觀看
    private void OnDrawGizmos()
    {
        //圖示.顏色=顏色      
        Gizmos.color = Color.red;
        //圖示.繪製射線(起點,方向*長度)
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY, transform.forward * data.attackLength);
    }
}
