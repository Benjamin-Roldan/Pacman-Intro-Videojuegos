using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Animacion : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[0];
    public float TimeA = 0.25f;
    public int FrameA;
    public bool loop = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), TimeA, TimeA);
    }

    private void Advance()
    {
        if (!spriteRenderer.enabled) {
            return;
        }

        FrameA++;

        if (FrameA >= sprites.Length && loop) {
            FrameA = 0;
        }

        if (FrameA >= 0 && FrameA < sprites.Length) {
            spriteRenderer.sprite = sprites[FrameA];
        }
    }

    public void Restart()
    {
        FrameA = -1;

        Advance();
    }

}