using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator anim;
    public int goldAmt = 50;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(InventoryItems.key == true)
            {
                anim.SetTrigger("open");
                InventoryItems.gold += goldAmt;
                goldAmt = 0;
            }
        }

    }

      private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(InventoryItems.key == true)
            {
                anim.SetTrigger("close");
            }
        }

    }

    public void DestroyChest()
    {
        Destroy(gameObject);
    }
}
