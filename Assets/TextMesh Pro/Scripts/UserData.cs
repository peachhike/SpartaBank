using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    // 유저 이름, 현금, 통장잔액
    public string Name { get; set; }
    public int Cash { get; set; }
    public int BankBalance { get; set; }
    
    // 생성자
    public UserData(string name, int cash, int bankBalance)
    {
        Name = name;
        Cash = cash;
        BankBalance = bankBalance;
    }
}
