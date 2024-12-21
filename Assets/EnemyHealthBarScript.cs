using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthBarScript : MonoBehaviour
{
    Image healthBar;
    private float maxHealth = 100f;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (health < 30f)
        {
            healthBar.color = new Color32(154, 23, 6, 255);
        }

        if (health > 30f)
        {
            healthBar.color = new Color32(14, 104, 5, 255);
        }
    }

    public void ReduceHealth()
    {
        health -= 10f;
    }
}
