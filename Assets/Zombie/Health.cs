using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Health : MonoBehaviour
{
    private static Health _instance;
    public static Health Instance { get { return _instance; } }

    private TextMeshProUGUI scoreLabel;
    private float health = 1.0f;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        scoreLabel = GetComponent<TextMeshProUGUI>();
        UpdateHealthLabel();
    }

    public void UpdateHealthLabel()
    {
        scoreLabel.text = health.ToString();
    }

    public void AddHealth(float amount)
    {
        health += amount;
        UpdateHealthLabel();
    }

    public void SubtractHealth(float amount)
    {
        health -= amount;
        UpdateHealthLabel();
    }
}
