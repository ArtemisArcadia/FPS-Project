using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndulateMaterial : MonoBehaviour
{

    Material material;
    Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        float shininess = Mathf.PingPong(Time.time, 1.0F);
        material.SetFloat("_NormalMap", shininess);
    }
}
