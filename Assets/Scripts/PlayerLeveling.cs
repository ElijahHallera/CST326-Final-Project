using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLeveling : MonoBehaviour
{

    public Text playerLevel;
    public int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel.text = currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
