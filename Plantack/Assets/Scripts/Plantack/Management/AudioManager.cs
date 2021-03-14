using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plantack.Management
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private int startAmountSounds;
        [SerializeField] private GameObject audioGameObject;

        public static AudioManager instance;
        private List<AudioSource> _audioSourcesPool = new List<AudioSource>();


        private void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            instance = this;
            if (transform.parent == null)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            for (int i = 0; i < startAmountSounds; i++)
            {
                InstantiateAudioSource(i);
            }
        }


        public void PlaySound(AudioClip clip, Vector3 pos, float pitch = 1.0f, bool loop = false)
        {
            AudioSource audioSource = FirstAvailableAudioSource();
            audioSource.clip = clip;
            audioSource.transform.position = pos;
            audioSource.pitch = pitch;
            audioSource.loop = loop;
            audioSource.Play();
        }

        private AudioSource InstantiateAudioSource(int i)
        {
            GameObject audioSourceGO = Instantiate(audioGameObject, transform);
            audioSourceGO.name = "Audio Source " + i;
            AudioSource audioSource = audioSourceGO.GetComponent<AudioSource>();
            _audioSourcesPool.Add(audioSource);
            return audioSource;
        }

        private AudioSource FirstAvailableAudioSource()
        {
            foreach (AudioSource audioSource in _audioSourcesPool)
            {
                if (!audioSource.isPlaying)
                {
                    return audioSource;
                }
            }

            return InstantiateAudioSource(_audioSourcesPool.Count);
        }
    }
}