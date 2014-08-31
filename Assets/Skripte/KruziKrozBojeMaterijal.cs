using UnityEngine;
using System.Collections;

public class KruziKrozBojeMaterijal : MonoBehaviour
{
    public string SvojstvoBoja = "_Color";
    public float BrzinaKruzenja = 0.1f;
    public float saturation = 1f;
    public float brightness = 1f;
    public float hue = 0f;

    void Update()
    {
        hue += BrzinaKruzenja * Time.deltaTime;

        while (hue > 1f)
        {
            hue -= 1f;
        }
        while (hue < 0f)
        {
            hue += 1f;
        }

        renderer.material.SetColor(SvojstvoBoja, new HSBColor(hue, saturation, brightness).ToColor());
    }
}
