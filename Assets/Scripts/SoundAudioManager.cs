using UnityEngine;
using System.Linq;

public class SoundAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioData[] _datas;

    public static SoundAudioManager Instance;

    private void OnEnable()
    {
        if (Instance != null)
            throw new System.InvalidOperationException();

        Instance = this;
    }

    public void PlaySound(AudioData.Kind kind)
    {
        var sound = _datas
            .ToList()
            .Find(data => data.AudioKind == kind);

        if (sound == null)
            throw new System.InvalidOperationException();

        if(!sound.Source.isPlaying)
            sound.Source.Play();
    }


    public void StopSound(AudioData.Kind kind)
    {
        var sound = _datas
            .ToList()
            .Find(data => data.AudioKind == kind);

        if (sound == null)
            throw new System.InvalidOperationException();

        if(sound.Source.isPlaying)
             sound.Source.Stop();
    }



    [System.Serializable]
    public class AudioData
    {
        [SerializeField]
        private AudioSource _source;

        [SerializeField]
        private Kind _kind;

        public AudioSource Source => _source;
        public Kind AudioKind => _kind;

        public enum Kind
        {
            Movement, 
            Repairing,
            ReparationDone,
            Arrival
        }
    }
}
