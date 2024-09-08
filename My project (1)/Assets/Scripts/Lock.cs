using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject[] UnlockBlocks;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool ShouldOpenDoor = true;
        for (int i = 0; i < UnlockBlocks.Length; i++)
        {
            GameObject block = UnlockBlocks[i];
            if (block.activeInHierarchy == false)
            {
                ShouldOpenDoor = false;
                

            }
            
        }
        if (ShouldOpenDoor == true)
        {
            door.SetActive(false);
        }
    }
}
