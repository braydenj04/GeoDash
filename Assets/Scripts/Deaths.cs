using UnityEngine;
using TMPro;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private TMP_Text deathText;

    private void Update()
    {
        //this gets the deathcount number from game manager and displays it in death text
        deathText.text = "Deaths: " + GameManager.Instance.deathCount;
    }
}