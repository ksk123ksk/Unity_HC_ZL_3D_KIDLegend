using UnityEngine;

public class learnloop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < 6; i++)
        {
            print(i);
        }
        int j=0;
        while (j < 5)
        {
            j++;
            print(j);
        }
        for(int x = 1;x < 10; x++)
        {
            for(int y = 1; y < 10; y++)
            {
                print(x + "*" + y + "=" + x * y);
            }
        }
    }
}
