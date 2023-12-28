using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicPlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Text songTitleText;
    public Image albumCoverImage;
    public Sprite[] albumCovers; // 假设您有专辑封面的数组

    private int currentTrackIndex = 0; // 当前播放的曲目索引
    private AudioClip[] musicTracks; // 您的音乐曲目数组

    void Start()
    {
        // 初始化音乐播放器
        LoadMusicTracks();
        UpdateUI();
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void NextTrack()
    {
        // 切换到下一曲目
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        audioSource.clip = musicTracks[currentTrackIndex];
        PlayMusic();
        UpdateUI();
    }

    public void PreviousTrack()
    {
        // 切换到上一曲目
        if (currentTrackIndex - 1 < 0)
        {
            currentTrackIndex = musicTracks.Length - 1;
        }
        else
        {
            currentTrackIndex--;
        }
        audioSource.clip = musicTracks[currentTrackIndex];
        PlayMusic();
        UpdateUI();
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volumeSlider.value) * 20);
    }

    private void LoadMusicTracks()
    {
        // 加载音乐曲目到musicTracks数组中
    }

    private void UpdateUI()
    {
        // 更新界面元素
        songTitleText.text = musicTracks[currentTrackIndex].name;
        albumCoverImage.sprite = albumCovers[currentTrackIndex];
    }
}
