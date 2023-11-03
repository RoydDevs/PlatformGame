using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of AudioManager in the scene");
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
		{
            Debug.Log("Next song");
            PlayNextSong();
		}
    }

    void PlayNextSong()
	{
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
	}

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
	{
        //Create an emtpy game object
        GameObject tempGO = new GameObject("TempAudio");
        //Set position of the object touched
        tempGO.transform.position = pos;
        //Add Audio source component to the temp game object
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        //Select the clip to play
        audioSource.clip = clip;
        //Select the audio mixer
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        //Play the sound
        audioSource.Play();
        //Destroy the temporary game object after the sound is finished
        Destroy(tempGO, clip.length);
        return audioSource;
	}
}
