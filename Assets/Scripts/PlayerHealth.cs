using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider myHealthBar;
    public PlayerMana mana;

    // Start is called before the first frame update
    void Start()
    {
        myHealthBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(myHealthBar.value <= 0)
        {
            Camera.main.transform.parent = null;
            GameObject.FindWithTag("Player").SetActive(false);
        }
    }

    public void playerHit()
    {
        myHealthBar.value -= 10;
    }

    public void playerHealing()
    {
        if(myHealthBar.value < 100)
        {
            mana.manaHeal();
            myHealthBar.value = 100;
        } else
        {
            Debug.Log("Health is already full!");
        }
    }
}
