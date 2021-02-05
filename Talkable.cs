using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Talkable : Interactable
{
    public Sprite enterChat;
    public Sprite closeChat;

    private SpriteRenderer sr;
    private bool isChatting;

    public override void Interact()
    {
        if (isChatting)
        {
            sr.sprite = closeChat;
        }
        else
        {
            sr.sprite = enterChat;
        }
        isChatting = !isChatting;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closeChat;
    }


}
