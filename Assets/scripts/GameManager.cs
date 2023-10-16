using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager: MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Action<int> OnLevelUp;
    public Action<int> OnPlayerHealthChange;

    private int currentLevel = 1;
    private int playerHealth = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseLevel()
    {
        currentLevel++;
        OnLevelUp?.Invoke(currentLevel);
    }

    public void DecreasePlayerHealth(int amount)
    {
        playerHealth -= amount;
        OnPlayerHealthChange?.Invoke(playerHealth);
    }
}
