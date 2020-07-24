using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class SoundHelper
    {
        private static Dictionary<string, AudioClip> _audios;
        private static AudioSource _audioSource;

        public static void Load()
        {
            _audioSource = Object.FindObjectOfType<AudioSource>();

            _audios = new Dictionary<string, AudioClip>();

            foreach (var audio in Resources.LoadAll<AudioClip>("Sounds/"))
            {
                _audios.Add(audio.name, audio);
            }
        }

        public static void Play(Audios selected)
        {
            var name = selected == Audios.Beep ? "beep" :
                selected == Audios.Peep ? "peep" :
                "plop";

            _audioSource.PlayOneShot(_audios[name]);
        }

        public enum Audios
        {
            Beep,
            Peep,
            Plop
        }
    }
}
