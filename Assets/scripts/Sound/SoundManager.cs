using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string backgroundPref = "backgroundPref";
    private int firstPlayInt;
    public Slider BackgroundSlider, SoundEffectsSlider;
    private float backgroundFloat;
    public AudioSource backgroundAudioSource;
    
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            backgroundFloat = .25f;
            BackgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else{
            BackgroundSlider.value = backgroundFloat;
            backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
        }
    }
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(backgroundPref, backgroundFloat);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }
   public void UpdateSound()
   {
    backgroundAudioSource.volume = BackgroundSlider.value;
   }
    
}
