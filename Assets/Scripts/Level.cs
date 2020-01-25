using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // only serialized for debugging

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
}
