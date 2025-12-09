using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private const float Speed = 8;

    void Update()
    {
        transform.Translate((Vector3) new Vector2(x: Speed * Time.deltaTime, y: 0));
    }
}
