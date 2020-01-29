using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config
    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached reference 
    Level level;
    GameSession gameStatus;

    //state variables
    [SerializeField] int timesHit; // only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        // each block will "count" itself at the start of play
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
        Destroy(gameObject);
        gameStatus.AddToScore();
        level.BlockDestroyed();
    }
    private void HandleHit()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();

    }
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else 
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }

    }
}
