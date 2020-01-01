using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learncoroutine : MonoBehaviour
{
    public IEnumerator Test()
    {
        print("執行");
        yield return new WaitForSeconds(2);
        print("2秒");
    }
    public Transform mouse;
    public IEnumerator Big()
    {
        for(int i = 0; i < 5; i++)
        {
            mouse.localScale += Vector3.one;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void Start()
    {
        StartCoroutine(Test());
        StartCoroutine(Big());
    }
}
