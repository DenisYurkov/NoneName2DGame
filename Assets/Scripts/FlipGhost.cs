using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGhost : MonoBehaviour
{
    [Header("Ghost Flip Settings")]
    public SpriteRenderer ghost;
    public float timeForFlip = 25f;

    private void Update()
    {
        Invoke("Flip", timeForFlip);
    }

    private void Flip()
    {
        ghost.flipX = true;
    }
}
