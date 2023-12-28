using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayPauseController : MonoBehaviour
{
    public Button Button_Play; // 播放按钮
    public Button Button_Stop; // 暂停按钮
    public VideoPlayer videoPlayer; // VideoPlayer组件

    void Start()
    {
        // 确保按钮和VideoPlayer都已在Inspector中设置
        if (Button_Play == null)
        {
            Debug.LogError("Button_Play not set in the inspector");
            return;
        }
        if (Button_Stop == null)
        {
            Debug.LogError("Button_Stop not set in the inspector");
            return;
        }
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer not set in the inspector");
            return;
        }

        // 为播放按钮添加事件监听器
        Button_Play.onClick.AddListener(PlayVideo);

        // 为暂停按钮添加事件监听器
        Button_Stop.onClick.AddListener(StopVideo);
    }

    // 开始播放视频
    void PlayVideo()
    {
        if (!videoPlayer.isPlaying)
        {
            Debug.Log("Video played");
            videoPlayer.Play();
        }
    }

    // 暂停视频
    void StopVideo()
    {
        if (videoPlayer.isPlaying)
        {
            Debug.Log("Video paused");
            videoPlayer.Pause();
        }
    }
}
