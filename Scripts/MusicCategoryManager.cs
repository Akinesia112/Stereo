using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicCategoryManager : MonoBehaviour
{
    public AudioSource Audio1;
    public AudioSource Audio2;
    public AudioSource Audio3;
    public AudioSource Audio4;
    public AudioSource Audio5;
    public AudioSource Audio6;
    // 定义音乐类别的枚举
    public enum MusicCategory { Country, Jazz, Pop, Rock, Soul, Expression }

    // 用于存储每个音乐类别AudioSource的字典
    private Dictionary<MusicCategory, AudioSource> categoryAudioSources;

    // 当前播放的音乐类别
    private MusicCategory? currentCategoryPlaying = null;

    void Start()
    {
        // 初始化字典
        categoryAudioSources = new Dictionary<MusicCategory, AudioSource>();

        // 为每个类别的音乐添加对应的AudioSource
        categoryAudioSources[MusicCategory.Country] = Audio1/* 指定Country类别的AudioSource */;
        categoryAudioSources[MusicCategory.Jazz] = Audio2/* 指定Jazz类别的AudioSource */;
        categoryAudioSources[MusicCategory.Pop] = Audio3/* 指定Pop类别的AudioSource */;
        categoryAudioSources[MusicCategory.Rock] = Audio4/* 指定Rock类别的AudioSource */;
        categoryAudioSources[MusicCategory.Soul] = Audio5/* 指定Soul类别的AudioSource */;
        categoryAudioSources[MusicCategory.Expression] = Audio6/* 指定Expression类别的AudioSource */;

        // 初始化，所有类别的音乐都未播放
        foreach (var audioSource in categoryAudioSources.Values)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    // 播放指定类别的音乐
    public void PlayMusic(MusicCategory category)
    {
        // 如果当前有其他音乐播放，停止它
        if (currentCategoryPlaying.HasValue && currentCategoryPlaying.Value != category)
        {
            categoryAudioSources[currentCategoryPlaying.Value].Stop();
        }

        // 播放选定类别的音乐
        AudioSource sourceToPlay = categoryAudioSources[category];
        if (!sourceToPlay.isPlaying)
        {
            sourceToPlay.Play();
            currentCategoryPlaying = category; // 更新当前播放的类别
        }
    }

    // 停止所有音乐
    public void StopAllMusic()
    {
        foreach (var source in categoryAudioSources.Values)
        {
            source.Stop();
        }
        currentCategoryPlaying = null;
    }

    // 为每个类别添加播放功能
    public void PlayCountry() => PlayMusic(MusicCategory.Country);
    public void PlayJazz() => PlayMusic(MusicCategory.Jazz);
    public void PlayPop() => PlayMusic(MusicCategory.Pop);
    public void PlayRock() => PlayMusic(MusicCategory.Rock);
    public void PlaySoul() => PlayMusic(MusicCategory.Soul);
    public void PlayExpression() => PlayMusic(MusicCategory.Expression);
}
