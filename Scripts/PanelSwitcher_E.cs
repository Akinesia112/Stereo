using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher_E : MonoBehaviour
{
    // 定义所有的Jazz Panel
    public GameObject Jazz_1;
    public GameObject Jazz_2;
    public GameObject Jazz_3;

    public Button Button_Next; // Next按钮
    public Button Button_Back; // Back按钮

    private GameObject[] allJazzPanels; // 存储所有Jazz Panel的数组
    private int currentIndex = 0; // 当前显示的Jazz Panel索引

    void Start()
    {
        // 初始化所有Jazz Panel数组
        allJazzPanels = new GameObject[] { Jazz_1, Jazz_2, Jazz_3};

        // 添加按钮事件监听器
        Button_Next.onClick.AddListener(ShowNextPanel);
        Button_Back.onClick.AddListener(ShowPreviousPanel);

        // 初始化界面显示
        UpdatePanelVisibility();
    }

    void ShowNextPanel()
    {
        if (currentIndex < allJazzPanels.Length - 1)
        {
            currentIndex++;
            UpdatePanelVisibility();
        }
    }

    void ShowPreviousPanel()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdatePanelVisibility();
        }
    }

    void UpdatePanelVisibility()
    {
        // 遍历所有Panel，根据currentIndex激活或禁用
        for (int i = 0; i < allJazzPanels.Length; i++)
        {
            allJazzPanels[i].SetActive(i == currentIndex);
        }
    }
}
