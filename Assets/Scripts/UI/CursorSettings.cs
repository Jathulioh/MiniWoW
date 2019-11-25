using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{

	public Texture2D pointer;

    // Start is called before the first frame update
    void Start()
    {
		Cursor.SetCursor(pointer, Vector2.zero, CursorMode.ForceSoftware);
    }

}
