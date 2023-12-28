using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicvol_sli;
    [SerializeField] Slider envivol_sli;
    [SerializeField] Slider EQ_A2_sli;
    [SerializeField] Slider EQ_A3_sli;
    [SerializeField] Slider EQ_A4_sli;
    [SerializeField] Slider EQ_A5_sli;
    [SerializeField] Slider highpass_sli;
    [SerializeField] Slider lowpass_sli;

    private void Awake()
    {
        musicvol_sli.onValueChanged.AddListener(set_musicvol);
        envivol_sli.onValueChanged.AddListener(set_envivol);
        EQ_A2_sli.onValueChanged.AddListener(set_EQ_A2);
        EQ_A3_sli.onValueChanged.AddListener(set_EQ_A3);
        EQ_A4_sli.onValueChanged.AddListener(set_EQ_A4);
        EQ_A5_sli.onValueChanged.AddListener(set_EQ_A5);
        highpass_sli.onValueChanged.AddListener(set_highpass);
        lowpass_sli.onValueChanged.AddListener(set_lowpass);
    }
    
    public void reset_effect ()
    {
        set_musicvol(1);
        musicvol_sli.value = 1;
        set_envivol(1);
        envivol_sli.value = 1;
        set_EQ_A2(1);
        EQ_A2_sli.value = 1;
        set_EQ_A3(1);
        EQ_A3_sli.value = 1;
        set_EQ_A4(1);
        EQ_A4_sli.value = 1;
        set_EQ_A5(1);
        EQ_A5_sli.value = 1;
        set_highpass(10);
        highpass_sli.value = 10;
        set_lowpass(22000);
        lowpass_sli.value = 22000;

    }

    void set_musicvol(float value)
    {
        mixer.SetFloat("musicVol", Mathf.Log10(value)*20);
    }

    void set_envivol(float value)
    {
        mixer.SetFloat("enviVol", Mathf.Log10(value) * 20);
    }
    void set_EQ_A2(float value)
    {
        mixer.SetFloat("EQ_A2", value);
    }

    void set_EQ_A3(float value)
    {
        mixer.SetFloat("EQ_A3", value);
    }

    void set_EQ_A4(float value)
    {
        mixer.SetFloat("EQ_A4", value);
    }

    void set_EQ_A5(float value)
    {
        mixer.SetFloat("EQ_A5", value);
    }

    void set_highpass(float value)
    {
        mixer.SetFloat("highpass", value);
    }

    void set_lowpass(float value)
    {
        mixer.SetFloat("lowpass", value);
    }
}
