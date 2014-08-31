using UnityEngine;
using System.Collections;

public class KruziKrozBojeMagla : MonoBehaviour
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
        float hue = 1f;

        while(t<=VremeKruzenja)
        {
            hue = Mathf.Lerp(1f, 0f, t / VremeKruzenja);
            RenderSettings.fogColor = new HSBColor(hue, saturation, brightness).ToColor();
            t += Time.deltaTime;
            yield return 0;
        }

        hue = 0f;

        StartCoroutine("MenjajBoje");
    }
}
