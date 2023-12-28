using UnityEngine;
using UnityEngine.UI;

public class WaveAnimator : MonoBehaviour
{
    public Sprite[] waveSprites; // 您的波形图像数组
    private Image waveImage; // Image组件引用
    private int currentSpriteIndex = 0; // 当前显示的波形图像索引
    private float animationRate = 0.1f; // 动画切换的速率
    private float timer; // 计时器

    void Start()
    {
        waveImage = GetComponent<Image>(); // 获取Image组件
        if (waveSprites.Length > 0)
        {
            waveImage.sprite = waveSprites[currentSpriteIndex]; // 设置初始波形图像
        }
    }

    void Update()
    {
        // 如果波形数组里有多于一个的图像，就执行动画
        if (waveSprites.Length > 1)
        {
            timer += Time.deltaTime;
            if (timer >= animationRate)
            {
                currentSpriteIndex = (currentSpriteIndex + 1) % waveSprites.Length;
                waveImage.sprite = waveSprites[currentSpriteIndex];
                timer = 0f;
            }
        }
    }
}
