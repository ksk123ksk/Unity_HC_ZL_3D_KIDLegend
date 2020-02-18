using UnityEngine;

public class Item : MonoBehaviour
{
    /// <summary>
    /// 是否過關，過關時就前往玩家的位置
    /// </summary>
    [HideInInspector]       //在屬性面板隱藏
    public bool pass;

    [Header("道具音效")]
    public AudioClip sound;

    private Transform player;
    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        player = GameObject.Find("鼠王").transform;
        HandleCollision();
    }
    private void Update()
    {
        GOTOPlayer();
    } 
    /// <summary>
    /// 控制忽略碰撞
    /// </summary>
    private void HandleCollision()
    {
        Physics.IgnoreLayerCollision(10, 8);
        Physics.IgnoreLayerCollision(10, 9);

    }
    private void GOTOPlayer()
    {
        if (pass)
        {
            Physics.IgnoreLayerCollision(10, 10);
            transform.position = Vector3.Lerp(transform.position, player.position, 0.8f * Time.deltaTime * 20);

            if (Vector3.Distance(transform.position, player.position) < 1f && !aud.isPlaying)
            {
                aud.PlayOneShot(sound,0.3f);
                Destroy(gameObject, 0.3f);
            }
        }
    }
}



