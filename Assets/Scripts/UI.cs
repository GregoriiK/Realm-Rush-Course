using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldAmount;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    void Update()
    {
        goldAmount.text = "Gold: " + bank.CurrentBalance.ToString();        
    }
}
