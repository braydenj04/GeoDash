using UnityEngine;

public class RandomToggle : MonoBehaviour
{
    //sets the chance to appear 0 is never and 1 is always
    [Range(0f, 1f)]
    public float chanceToAppear = 0.7f;

    void Start()
    {
        //generates a random number between 0 and 1, if its not within the chances to appear value it will not spawn in
        if (Random.value > chanceToAppear)
        {
            gameObject.SetActive(false);
        }
    }

}
