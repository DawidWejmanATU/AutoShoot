using UnityEngine;

public class NewSceneSoundSc : MonoBehaviour
{
    private static readonly string backgroundPref = "backgroundPref";
    private float backgroundFloat;
    public AudioSource backgroundAudioSource;
    void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
        backgroundAudioSource.volume = backgroundFloat;
    }
}
