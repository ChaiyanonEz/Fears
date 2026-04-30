using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ?????????????????????????????????????????

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;

    [Header("Boss Settings")]
    public bool isBoss = false; // ????????? Inspector ??????????????

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (isBoss)
        {
            WinGame();
        }

        Destroy(gameObject);
    }

    void WinGame()
    {
        // ???????????? ?????????? UI Win ?????
        Debug.Log("Boss Defeated! You Win!");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
    }
}
