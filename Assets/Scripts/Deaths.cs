using UnityEngine;
using TMPro;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private TMP_Text deathText;

    private void Update()
    {
        deathText.text = "Deaths: " + GameManager.Instance.deathCount;
    }
}