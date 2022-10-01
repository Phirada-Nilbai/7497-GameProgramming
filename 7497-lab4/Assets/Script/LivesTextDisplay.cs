using UnityEngine;
using TMPro;

public class LivesTextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    public void UpdateLives(int lives)
    {
        livesText.text = $"lives: {lives}";
    }
}
