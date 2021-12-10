using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeToBlack : MonoBehaviour
{
    [SerializeField] private Material material;
    //[SerializeField] private Renderer model;
    private void Start()
    {
        Color color = material.color;
        color.a = 0;
        material.color = color;
    }
}
