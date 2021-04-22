using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Slider myManaBar;
    public PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        myManaBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("HEALING");
            health.playerHealing();
            //Activate Healing spell in Health Manager
        }
    }

    public void manaHeal()
    {
        myManaBar.value -= 25;
    }
}
