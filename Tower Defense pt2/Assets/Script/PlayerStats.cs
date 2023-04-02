using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 500;

    public static int Hp;
    public int startHp = 10;

    public static int Rounds;
    
    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Hp = startHp;
        Rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
