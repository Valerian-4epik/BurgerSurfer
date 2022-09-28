using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveProgress
{
    public static int MoneyBalance
    {
        get => PlayerPrefs.GetInt("MoneyBalance");
        set => PlayerPrefs.SetInt("MoneyBalance", value);
    }
}