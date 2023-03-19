using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 500;

    public static int Hp;
    private int startHp = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
