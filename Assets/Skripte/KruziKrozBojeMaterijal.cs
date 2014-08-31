using UnityEngine;
using System.Collections;

public class KruziKrozBojeMaterijal : MonoBehaviour
{
    public float VremeKruzenja = 30f;
    public float saturation = 1f;
    public float brightness = 1f;

	void Start ()
    {
        StartCoroutine("MenjajBoje");
	}

	IEnumerator MenjajBoje()
    {
        float t = 0f;
        float hue = 0f;

        while(t<=VremeKruzenja)
        {
            hue = Mathf.Lerp(0f, 1f, t / VremeKruzenja);
            renderer.material.color = new HSBColor(hue, saturation, brightness).ToColor();
            t += Time.deltaTime;
            yield return 0;
        }

        hue = 1f;

        StartCoroutine("MenjajBoje");
    }
}
