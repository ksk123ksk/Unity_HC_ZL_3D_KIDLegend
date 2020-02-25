using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [Header("玩家資料")]
    public PlayerData dataPlayer;

    public void BuyHp_500()
    {
        dataPlayer.Maxhp += 500;
        dataPlayer.hp = dataPlayer.Maxhp;
    }
    public void BuyAtk_50()
    {
        dataPlayer.atk += 50;
        
    }
    public void LoadLevel()
    {
        dataPlayer.hp = dataPlayer.Maxhp;
        SceneManager.LoadScene(1);
    }

}
