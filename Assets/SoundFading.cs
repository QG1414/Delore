using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundFading : MonoBehaviour
{

    public static IEnumerator FadeInCoroutine(AudioSource audioSource, float duration, float startVolume ,float endVolume)
    {
        float currentTime = 0;
        audioSource.volume = startVolume;

        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, endVolume, currentTime/duration);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator FadeInCoroutine(AudioSource[] audioSource, float duration, float startVolume, float endVolume)
    {
        float currentTime = 0;

        foreach(AudioSource audios in audioSource)
        {
            audios.volume = startVolume;
        }

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            foreach (AudioSource audios in audioSource)
            {
                audios.volume = Mathf.Lerp(startVolume, endVolume, currentTime / duration);
            }
            yield return null;
        }
        yield break;
    }

}
