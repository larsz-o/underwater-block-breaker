using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level; // cached reference 

    private void Start ()
    {
        level = FindObjectOfType<Level>();
        // each block will "count" itself at the start of play
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
        Destroy(gameObject);
    }
}
