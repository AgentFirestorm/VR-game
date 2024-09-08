using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBlock : MonoBehaviour
{
    public GameObject[] Blocks;
    private int CurrentIndex;
    // Start is called before the first frame update
    void Start()
    {
        CurrentIndex = 0;
        int lengthofarray = Blocks.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject block = Blocks[CurrentIndex];
        block.SetActive(false);
        CurrentIndex += 1;
        if(CurrentIndex >= Blocks.Length)
        {
            CurrentIndex = 0;
        }
        block = Blocks[CurrentIndex];
        block.SetActive(true);
    }
}
