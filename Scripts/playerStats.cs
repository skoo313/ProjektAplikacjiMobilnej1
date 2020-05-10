using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        healthBar.ResetHP(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        healthBar.SetHP(HP);
    }
}
