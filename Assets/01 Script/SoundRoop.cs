using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundRoop : MonoBehaviour
{
    [System.Serializable]
    public class SoundInfo
    {
        public AudioClip clip;      // 재생할 소리
        public int playCount = 1;   // 재생할 횟수 (기본 1번)
    }

    public List<SoundInfo> soundList = new List<SoundInfo>(); // 인스펙터에서 추가할 리스트

    private AudioSource audioSource;
    private Queue<SoundInfo> soundQueue = new Queue<SoundInfo>();

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        StartCoroutine(PlaySoundsInOrder());
    }

    IEnumerator PlaySoundsInOrder()
    {
        foreach (SoundInfo soundInfo in soundList)
        {
            for (int i = 0; i < soundInfo.playCount; i++)
            {
                audioSource.clip = soundInfo.clip;
                audioSource.Play();
                yield return new WaitForSeconds(soundInfo.clip.length);
            }
        }
    }
}
