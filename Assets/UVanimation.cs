using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVanimation : MonoBehaviour
{

    public float scrollSpeed = .5f;
    string textureName = "_MainTex";
    
    float offset;


    private void LateUpdate()
    {

        offset += scrollSpeed * Time.deltaTime;

        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 1);
        }
        
    }
}
