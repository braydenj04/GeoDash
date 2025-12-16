using UnityEngine;

public class RandomToggle : MonoBehaviour
{
    [Range(0f, 1f)]
    public float chanceToAppear = 0.7f;

    void Start()
    {
        if (Random.value > chanceToAppear)
        {
            gameObject.SetActive(false);
        }
    }

}
