using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;
    //직접 입력 금액도 연동되도록 ui설정 필요
    public void Start()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        balanceText.text = gameManager.userData.BankBalance.ToString();
        cashText.text = gameManager.userData.Cash.ToString();
    }

    public TMP_InputField depositInputField;
    public void DepositCustomAmount()
    {
        if (int.TryParse(depositInputField.text, out int amount))
        {
            Deposit(amount);
        }
    }
    // 예금 금액 버튼을 누르면 현금과 잔액 값이 연동됨(ui) 현금은- 잔액은+
    public void Deposit(int cash)
    {
        if (cash > 0 && cash <= gameManager.userData.Cash)  // 입금 금액이 유효한지 확인
        {
            gameManager.userData.Cash -= cash;  // 현금에서 입금액 차감
            gameManager.userData.BankBalance += cash;  // 잔액에 입금액 추가
            UpdateUI();  // UI 갱신
            gameManager.SaveUserData();
        }
        //
        else
        {
            Debug.Log("입금 금액이 잘못되었습니다.");
        }
    }

    // 출금은 예금과 반대로 작성하면 됨
    public void Withdraw(int cash)
    {
        if (cash > 0 && cash <= gameManager.userData.BankBalance)  // 출금 금액이 유효한지 확인
        {
            gameManager.userData.Cash += cash;  // 현금에 출금액 추가
            gameManager.userData.BankBalance -= cash;  // 잔액에서 출금액 차감
            UpdateUI();  // UI 갱신
            gameManager.SaveUserData();
        }
        else
        {
            Debug.Log("출금 금액이 잘못되었습니다.");
        }
    }
}
