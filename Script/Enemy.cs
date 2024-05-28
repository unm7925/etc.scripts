using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moneyReward = 20;
    [SerializeField] int moneyPenalty = 20;

    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();

    }
    public void RewardMoney()
    {
        if(bank == null) { return; }
        bank.Deposit(moneyReward);
    }
    public void StealMoney()
    {
        if (bank == null) { return; }
        bank.Withdraw(moneyPenalty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
