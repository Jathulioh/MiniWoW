using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    void LateUpdate()
    {
		gameObject.transform.rotation = Quaternion.Euler(90, 0, -90);
    }
}
