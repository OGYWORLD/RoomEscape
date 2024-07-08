using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTexture : MonoBehaviour
{
    Renderer rend;
    public Texture textureImage;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.mainTexture = textureImage;
    }
}
