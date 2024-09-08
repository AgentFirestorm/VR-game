using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBlock : MonoBehaviour
{


    public GameObject[] Blocks;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < Blocks.Length; i++)
        {
            GameObject block = Blocks[i];
            if (block.activeInHierarchy)
            {
                print("Block Toggled");
                block.SetActive(false);

            }
            else
            {
                print("Block Untoggled");
                block.SetActive(true);

            }
        }



    }
}
