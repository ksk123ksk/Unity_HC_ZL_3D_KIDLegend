﻿using UnityEngine;
using System.Collections;

public class EnemyFar : Enemy
{
    [Header("子彈")]
    public GameObject bullet;

    private Vector3 posBullet;

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(CreateBullet());     //啟動協程
    }

    private IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(data.attackDelay);      //等待
        //子彈作標=飛龍.座標+飛龍前方*Z+飛龍上方*Y
        posBullet = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
        GameObject temp = Instantiate(bullet, posBullet, transform.rotation);     //生成(物件,座標,角度)
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletPower);

        temp.AddComponent<Bullet>();
        temp.GetComponent<Bullet>().damage = data.atk;
        temp.GetComponent<Bullet>().player = false;
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
