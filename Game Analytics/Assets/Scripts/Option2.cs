using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    public Button targetButton;
    public Color newColor = Color.red;

    private void Start()
    {
        if (targetButton == null)
        {
            Debug.LogError("Target Button is not assigned!");
            return;
        }

        // Add the onClick listener
        targetButton.onClick.AddListener(ChangeColor);
    }

    private void ChangeColor()
    {
        ColorBlock colors = targetButton.colors;
        colors.normalColor = newColor;
        colors.highlightedColor = newColor;
        colors.pressedColor = newColor;
        colors.selectedColor = newColor;
        targetButton.colors = colors;

        AnalyticsManager.Instance.Option2();
    }
}

