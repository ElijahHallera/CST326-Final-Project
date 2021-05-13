using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : MonoBehaviour
{
    public bool isOpen;
    public bool playerInRange;
    private Animator anim;
    public PlayerHealth health;
    private float delayBeforeLoading = 3f;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
                Debug.Log("Opening Chest");
            } else
            {
                ChestAlreadyOpen();
                Debug.Log("Already Opened");
            }
        }
        if (isOpen)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed > delayBeforeLoading)
            {
                health.myHealthBar.value = 0;
            }
        }
    }

    public void OpenChest()
    {
        isOpen = true;
        anim.SetBool("opened", true);
    }

    public void ChestAlreadyOpen()
    {
        if (!isOpen)
        {
            isOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = false;
        }
    }
}
