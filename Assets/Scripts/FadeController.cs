using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;

    public IEnumerator FadeInRoutine()
    {
        Color startColor = fadeImage.color;
        Color endColor = Color.black;
        float t = 0;
        while (t <= 1.0f)
        {
            t += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }        
    }

    public IEnumerator FadeOutRoutine()
    {
        Color startColor = fadeImage.color;
        Color endColor = new Color(0,0,0,0);
        float t = 0;
        while (t <= 1.0f)
        {
            t += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
    }
}
