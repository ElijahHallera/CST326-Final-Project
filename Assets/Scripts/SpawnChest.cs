using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public GameObject treasureChest;

    void Update()
    {
        if (FindObjectOfType<MeleeEnemy>() == null)
        {
            Instantiate(treasureChest, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
