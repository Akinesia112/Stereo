using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerUI : MonoBehaviour
{
    public AudioSource audioSource; // 指向AudioSource的引用
    public AudioClip[] tracks;      // 存储音乐曲目的数组
    public Slider volumeSlider;     // 音量滑动条
    public RawImage waveformDisplay; // 波形显示的RawImage
    public Image genreImage;        // 音乐类型图片
    public Sprite[] genreSprites;   // 音乐类型的精灵数组
    private int currentTrack = 0;   // 当前播放曲目的索引
    
    /*public class AudioPlayer : MonoBehaviour
    {
        public AudioClip myAudioClip; // 创建一个AudioClip公共变量来引用MP3文件

        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = myAudioClip; // 将AudioClip分配给AudioSource
        }

        public void PlayAudio()
        {
            if (audioSource.clip != null)
            {
                audioSource.Play(); // 播放音频
            }
        }
    }*/
    
    // 播放或暂停音乐
    public void PlayPauseToggle()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
        {
            audioSource.clip = tracks[currentTrack];
            audioSource.Play();
        }
    }

    // 播放下一首曲目
    public void PlayNext()
    {
        currentTrack = (currentTrack + 1) % tracks.Length;
        PlayTrack(currentTrack);
    }

    // 播放上一首曲目
    public void PlayPrevious()
    {
        if (--currentTrack < 0) currentTrack = tracks.Length - 1;
        PlayTrack(currentTrack);
    }

    // 调整音量
    public void AdjustVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // 添加到播放列表
    public void AddToPlayList()
    {
        // 您的播放列表逻辑
    }

    // 退出播放器
    public void ExitPlayer()
    {
        Application.Quit();
    }

    // 播放特定曲目
    private void PlayTrack(int trackIndex)
    {
        audioSource.clip = tracks[trackIndex];
        audioSource.Play();
    }

    // 更新音乐类型图片
    private void UpdateGenreImage(int genreIndex)
    {
        genreImage.sprite = genreSprites[genreIndex];
    }

    // 在这里添加音频可视化的更新逻辑
    private void UpdateWaveformDisplay()
    {
        // 使用AudioVisualizer脚本更新RawImage
    }

    void Start()
    {
        // 初始化音量滑动条
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
        // 可能需要初始化其他组件和值
    }

    void Update()
    {
        // 如果需要在每一帧更新音频可视化
        UpdateWaveformDisplay();
    }
}
