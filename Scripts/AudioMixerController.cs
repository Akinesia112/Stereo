using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer audioMixer; // 指向您的音频混音器
    public Slider volumeSlider;   // 指向您的音量滑动条

    void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = 1.0f; // 初始化滑动条的值
            volumeSlider.onValueChanged.AddListener(SetVolume); // 添加滑动条变更事件的监听器
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); // 设置音频混音器的音量
    }
}
