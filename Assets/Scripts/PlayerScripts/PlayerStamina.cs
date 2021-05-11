using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public Slider myStaminaBar;
    private WaitForSeconds regenerationTick = new WaitForSeconds(0.1f);
    private Coroutine regeneration;
    public PlayerMovement movement;

    public bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        myStaminaBar.value = 1000;
    }

    // Update is called once per frame
    void Update()
    {

        if (myStaminaBar.value > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                running = true;
            }
        }
        else
        {
            Debug.Log("Not Enough Stamina");
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                running = false;
                movement.playerWalking();
                Debug.Log("WALKING");
            }
            running = false;
            movement.playerWalking();
        }

        if(running == true)
        {
            wereSprinting();
        }
    }


    private IEnumerator RegenerateStamina() {

        yield return new WaitForSeconds(2);

        while(myStaminaBar.value < 1000)
        {
            myStaminaBar.value += 10;
            yield return regenerationTick;
        }
        regeneration = null;
    }

    public void wereSprinting()
    {

        if (myStaminaBar.value > 0)
        {
            movement.playerSprinting();

            myStaminaBar.value -= 2;

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                running = false;
                movement.playerWalking();
            }

            if (regeneration != null)
            {
                StopCoroutine(regeneration);
            }

            regeneration = StartCoroutine(RegenerateStamina());
            Debug.Log("Sprinting");
        }
        else
        {
            Debug.Log("Not Enough Stamina");
            running = false;
        }
    }

    public void fillStamina()
    {
        myStaminaBar.value = 1000;
    }
}
