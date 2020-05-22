using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidZoneAutoScreenSize : MonoBehaviour
{
    [Tooltip("Рендер текстура")]
    [SerializeField] private RenderTexture _liquidRenderTexture;
    void Awake()
    {
        _liquidRenderTexture.width = Screen.width;
        _liquidRenderTexture.height = Screen.height;
    }

}
