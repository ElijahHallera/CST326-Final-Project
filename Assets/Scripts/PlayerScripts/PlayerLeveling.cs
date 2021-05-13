using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLeveling : MonoBehaviour
{

    [SerializeField]  public Text playerLevel;
    public int currentLevel = 1;

    //leveling system start
    public int requiredEXP = 50;
    public int currentEXP = 0;

    //Stamina, Health, Mana Managers
    public PlayerHealth health;
    public PlayerMana mana;
    public PlayerStamina stamina;
    public AudioSource audioSource;
    public AudioClip LevelUpSound;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel.text = currentLevel.ToString();
        playerLevel.color = Color.white;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            levelUP();
        }
    }

    public void refreshLevel()
    {
        playerLevel.GetComponent<Text>().text = currentLevel.ToString();
        playerLevel.color = Color.white;
    }

    public void levelUP()
    {
        audioSource.PlayOneShot(LevelUpSound);
        currentLevel++;
        Debug.Log("LEVEL UP, YOU'RE NOW LVL: " + currentLevel);
        health.increasePlayerHealth();
        health.playerHealing();
        mana.fillMana();
        stamina.fillStamina();
        refreshLevel();
    }

    public void gainExperience()
    {
        currentEXP += 10;
        checkEXP();
    }

    public void checkEXP()
    {
        Debug.Log(currentEXP + " / " + requiredEXP);
        if(currentEXP >= requiredEXP)
        {
            currentEXP -= requiredEXP;
            requiredEXP += 20;
            Debug.Log("New EXP Milestone " + requiredEXP);
            levelUP();
        }
    }
}
