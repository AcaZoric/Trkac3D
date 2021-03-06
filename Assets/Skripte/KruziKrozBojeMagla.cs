﻿using UnityEngine;
using System.Collections;

public class KruziKrozBojeMagla : MonoBehaviour
{
    public float BrzinaKruzenja = 0.1f;
    public float saturation = 1f;
    public float brightness = 1f;
    public float hue = 0f;
    //radi samo na FOG efektu, ovo je izmenjena KruziKrozBojeMaterijal.cs
	void Update()
    {
        hue += BrzinaKruzenja * Time.deltaTime;

        while (hue>1f)
        {
            hue -= 1f;
        }
        while (hue < 0f)
        {
            hue += 1f;
        }
        RenderSettings.fogColor = new HSBColor(hue, saturation, brightness).ToColor();
    }
}
