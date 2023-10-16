using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI enemiesDestroyedText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI levelText;

    private int enemiesDestroyed = 0;
    private Player player;
    public float timer = 0f;
    private int currentLevel = 1;
    private float levelUpTime = 10f;


    private void Start()
    {
        levelText.text = "Nivel: " + currentLevel;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        UpdateUI();
        UpdateLevel();
    }
    void UpdateUI()
    {
        enemiesDestroyedText.text = "Enemigos Destruidos: " + enemiesDestroyed;
        playerHealthText.text = "Vida del Jugador: " + player.playerHealth;
    }

    void UpdateLevel()
    {
        timer += Time.deltaTime;
        if (timer >= levelUpTime)
        {
            currentLevel++;
            levelText.text = "Nivel: " + currentLevel;
            timer = 0f;
            if (currentLevel == 10)
            {
                Debug.Log("Ganaste!");
            }
        }
    }

    public void IncrementEnemiesDestroyed()
    {
        enemiesDestroyed++;
    }
}
