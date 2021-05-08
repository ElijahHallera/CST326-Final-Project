using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<PlayerLeveling>().currentLevel == 5)
        {
            Debug.Log("Barrier is now gone!");
            Destroy(this.gameObject);
        }
    }
}
