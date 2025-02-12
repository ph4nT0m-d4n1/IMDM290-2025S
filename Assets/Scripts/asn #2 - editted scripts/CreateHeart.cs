// UMD IMDM290 
// Instructor: Myungin Lee
// This tutorial introduces a way to draw spheres and align them in a circle with colors.

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CreateHeart : MonoBehaviour
{
    GameObject[] spheres; //array to hold our spheres
    static int numSphere = 100; //number of spheres we wanna create
    Vector3[] initPos; 
    Vector3[] newScale;

    void Start()
    {
        spheres = new GameObject[numSphere]; //creating a reference for 100 gameObjects
        initPos = new Vector3[numSphere]; //creating a reference for each sphere's initial position;
        newScale = new Vector3[numSphere];

        // love is in the air ...
        for (int i = 0; i < numSphere; i++){
            float t = i * (2 * Mathf.PI / numSphere); //normalizing t
            
            //heart shape equation
            float x = Mathf.Sqrt(2) * Mathf.Pow(Mathf.Sin(t), 3);
            float y = -Mathf.Pow(Mathf.Cos(t), 3) - Mathf.Pow(Mathf.Cos(t), 2) + 2 * Mathf.Cos(t);
            float z = 0f;

            initPos[i] = new Vector3(x, y, z);
            newScale[i] = new Vector3 (-0.25f, -0.25f, -0.25f);
            
            // Draw primitive elements:
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.CreatePrimitive.html
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            spheres[i].transform.position = initPos[i];
            spheres[i].transform.localScale = newScale[i];

            // Get the renderer of the spheres and assign colors.
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(hue, 1f, 1f); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }
}
