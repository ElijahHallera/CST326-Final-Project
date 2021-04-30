using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Slider myManaBar;
    public PlayerHealth health;
    public PlayerMovement fireballMechanics;

    // Start is called before the first frame update
    void Start()
    {
        myManaBar.value = 100;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (myManaBar.value > 0)
            {
                Debug.Log("HEALING");
                health.playerHealing();
            } else
            {
                Debug.Log("Out of Mana");
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (myManaBar.value >= 50)
            {
                Debug.Log("FIREBALL");
                fireballMechanics.MakeFireball();
                manaFire();
            } else
            {
                Debug.Log("Out of Mana");
            }
        }
    }

    public void manaHeal()
    {
        myManaBar.value -= 25;
    }

    public void manaFire()
    {
        myManaBar.value -= 50;
    }
}
