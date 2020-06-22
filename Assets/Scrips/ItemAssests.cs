using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssests : MonoBehaviour
{
    public static ItemAssests instance
    {
        get; private set;
    }

    private void Awake()
    {
        instance = this;
    }


    public Transform pfItemWorld;

    public Sprite coinSprite;
    public Sprite swordSprite;
}
