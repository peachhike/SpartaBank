using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject depositObject;
    public GameObject mainBtn;
    public GameObject withdrawObject;
    public Button[] backBtn;
    public UserData userData;

    private void Awake()
    {
        backBtn[0].onClick.AddListener(Back);
        backBtn[1].onClick.AddListener(Back);
        userData = new UserData("김주현", 100000, 50000 );
        LoadUserData();
    }

    public void Deposit()
    {
        depositObject.SetActive(true);
        mainBtn.SetActive(false);
    }

    // Update is called once per frame
    public void Withdraw()
    {
        withdrawObject.SetActive(true);
        mainBtn.SetActive(false);
    }
    
    public void Back()
    {
        // mainBtn을 활성화하고 다른 UI 요소들은 비활성화
        mainBtn.SetActive(true);
        depositObject.SetActive(false);
        withdrawObject.SetActive(false);
    }

    public void SaveUserData()
    {
        //변동시 자동저장이 가능하도록 코드 작성
        PlayerPrefs.SetInt("Cash", userData.Cash);  // 현금 저장
        PlayerPrefs.SetInt("BankBalance", userData.BankBalance);  // 잔액 저장
        PlayerPrefs.Save();  // 저장 적용
        Debug.Log("데이터가 자동으로 저장되었습니다.");
    }

    public void LoadUserData()
    {
        //데이터와 UI연동'불러오기' 코드 작성
        if (PlayerPrefs.HasKey("Cash"))
        {
            userData.Cash = PlayerPrefs.GetInt("Cash");  // 저장된 현금 불러오기
        }

        if (PlayerPrefs.HasKey("BankBalance"))
        {
            userData.BankBalance = PlayerPrefs.GetInt("BankBalance");  // 저장된 잔액 불러오기
        }
    }
}
