using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EquipmentLayers
{
	public enum layer { baseLayer, faceLayer, facialHairLayer, scalpLayer, underwearLayer, upperBodyLayer, shirtUpperLayer, shirtLowerLayer, shirtSleeveLowerLayer, shirtSleeveUpperLayer, torsoUpperLayer, torsoLowerLayer, sleeveUpperLayer, sleeveLowerLayer, bracerLayer, wristLayer, gloveLayer, legUpperLayer, legBeltLayer, legLowerLayer, legBootLayer, legFootLayer }
	public layer affectedLayer;
	public Texture2D layerImageMale;
	public Texture2D layerImageFemale;
}