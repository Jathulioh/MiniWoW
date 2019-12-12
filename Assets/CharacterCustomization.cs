using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct appearances{

	public enum Appearances {SKIN, FACE, HAIR_STYLE, HAIR_COLOR, FACIAL_HAIR, PIERCINGS, EARINGS, EARS, ACCESSORIES, HORNS, MARKINGS, TATTOO, TATTOO_COLOR};
	public Appearances detail;
	public Texture2D[] texturePart;
	public GameObject[] affectedLayer;
	public Material[] affectedPart;

	}

public class CharacterCustomization : MonoBehaviour
{
	public appearances[] appearance;
}
