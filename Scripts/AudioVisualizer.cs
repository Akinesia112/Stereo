using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject spectrumBarPrefab; // 频谱条预制体
    public int numberOfBars = 64;        // 频谱条数量
    private GameObject[] spectrumBars;   // 频谱条数组
    private float[] spectrumData;        // 频谱数据

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spectrumData = new float[numberOfBars];
        spectrumBars = new GameObject[numberOfBars];

        // 创建频谱条
        for (int i = 0; i < numberOfBars; i++)
        {
            GameObject bar = Instantiate(spectrumBarPrefab);
            bar.transform.SetParent(transform);
            bar.transform.localPosition = new Vector3(i * 0.1f, 0, 0); // 设置位置
            spectrumBars[i] = bar;
        }
    }

    void Update()
    {
        // 获取频谱数据
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // 更新频谱条的缩放来反映频谱数据
        for (int i = 0; i < numberOfBars; i++)
        {
            float scaleY = spectrumData[i] * 20; // 根据频谱数据调整大小
            scaleY = Mathf.Clamp(scaleY, 0.1f, 10); // 限制最小和最大大小
            spectrumBars[i].transform.localScale = new Vector3(0.1f, scaleY, 0.1f);
        }
    }
}
