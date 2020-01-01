using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class learnarray : MonoBehaviour
{
    public int[] a=new int[5];
    public string[] strings;
    public float[] b;
    public Transform[] Tf;
    public Vector3[] vector;
    public int[] c = { 1, 2 };

    private void Start()
    {
        print(c[0]);
        print(c.Length);
        a[0] = 1;

    }

}
