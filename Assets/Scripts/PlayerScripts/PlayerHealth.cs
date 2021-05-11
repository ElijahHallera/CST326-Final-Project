using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider myHealthBar;
    public PlayerMana mana;
    public GameObject deathEffect;
    public GameObject healingEffect;
    public float currentMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        myHealthBar.value = 100;
        currentMaxHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (myHealthBar.value <= 0)
        {
            Camera.main.transform.parent = null;
            DeathEffect();
            SceneManager.LoadScene("Death");
            GameObject.FindWithTag("Player").SetActive(false);
        }
    }

    public void playerHit()
    {
        if (!gameObject.CompareTag("Fireball"))
        {
            myHealthBar.value -= 10;
        }
    }

    public void increasePlayerHealth()
    {
        currentMaxHealth += 10;
    }

    public void playerHealing()
    {
        if (myHealthBar.value < currentMaxHealth)
        {
            GameObject newHealing = (GameObject)Instantiate(healingEffect, transform.position, Quaternion.identity);
            mana.manaHeal();
            Debug.Log("Current Max Health Value " + currentMaxHealth);
            myHealthBar.maxValue = currentMaxHealth;
            myHealthBar.value = currentMaxHealth;
            Debug.Log("Current Health Bar Value is " + myHealthBar.value);
            Destroy(newHealing, 2);
        }
        else
        {
            Debug.Log("Health is already full!");
            myHealthBar.maxValue = currentMaxHealth;
            myHealthBar.value = currentMaxHealth;
        }
    }

    public void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
