using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private Text HPText;
    private Text MPText;

    void Start()
    {
        Database.CreatePlayer("Luan", 1, 200, 50, 5, 12);

        instance = this;
    }

    void Update()
    {
        
    }

    public void UpdateHP(int hp)
    {
        HPText.text = hp.ToString();
    }

    public void UpdateMP(int mp)
    {
        MPText.text = mp.ToString();
    }
}
