using UnityEngine.Audio;
using UnityEngine;

namespace RHTMGame
{
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public float volume;
        public float pitch;
        public bool loop;

        public AudioSource source;
    }
}
