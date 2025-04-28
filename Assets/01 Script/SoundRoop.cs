using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundRoop : MonoBehaviour
{
    [System.Serializable]
    public class SoundInfo
    {
        public AudioClip clip;      // ����� �Ҹ�
        public int playCount = 1;   // ����� Ƚ�� (�⺻ 1��)
    }

    public List<SoundInfo> soundList = new List<SoundInfo>(); // �ν����Ϳ��� �߰��� ����Ʈ

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
