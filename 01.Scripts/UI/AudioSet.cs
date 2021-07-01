using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSet : MonoBehaviour
{
    public Slider Volum;
    public AudioSource BGM;

    float backVol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backVol",1f);
        Volum.value = backVol;
        BGM.volume = Volum.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundCheck();
    }

    public void SoundCheck()
    {
        BGM.volume = Volum.value;

        backVol =  Volum.value;
        PlayerPrefs.SetFloat("backVol",backVol);
    }
}
