using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bank
{
    public static event Action OnBankInitialized;
    public static int coins { get { CheckClass(); return bankInteractor.coins;  }}
    public static bool isInitialized { get; private set; }

    private static BankInteractor bankInteractor;

    public static void Initialize(BankInteractor interactor)
    {
        bankInteractor = interactor;
        isInitialized = true;

        OnBankInitialized?.Invoke();
    }

    public static bool IsEnougthCoins(int value)
    {
        CheckClass();
        return bankInteractor.IsEnougthCoins(value);
    }

    public static void AddCoins(object sender, int value)
    {
        CheckClass();
        bankInteractor.AddCoins(sender, value);
    }

    public void Spend(object sender, int value)
    {
        CheckClass();
        bankInteractor.Spend(sender, value);
    }

    private static void CheckClass()
    {
        if (!isInitialized)
        {
            throw new Exception("Bank is not Initialize yet");
        }
    }
}
