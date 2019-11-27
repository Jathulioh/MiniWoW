using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Inventory : MonoBehaviour
{
	[Header("Equipped Items")]
	public Equipment head		= null;
	public Equipment neck		= null;
	public Equipment shoulder	= null;
	public Equipment back		= null;
	public Equipment chest		= null;
	public Equipment shirt		= null;
	public Equipment tabard		= null;
	public Equipment wrist		= null;
	public Equipment hands		= null;
	public Equipment waist		= null;
	public Equipment legs		= null;
	public Equipment feet		= null;
	public Equipment ring1		= null;
	public Equipment ring2		= null;
	public Equipment trinket1	= null;
	public Equipment trinket2	= null;
	public Equipment mainhand	= null;
	public Equipment offhand	= null;

	private Equipment currentHead = null;
	private Equipment currentNeck = null;
	private Equipment currentShoulder = null;
	private Equipment currentBack = null;
	private Equipment currentChest = null;
	private Equipment currentShirt = null;
	private Equipment currentTabard = null;
	private Equipment currentWrist = null;
	private Equipment currentHands = null;
	private Equipment currentWaist = null;
	private Equipment currentLegs = null;
	private Equipment currentFeet = null;
	private Equipment currentRing1 = null;
	private Equipment currentRing2 = null;
	private Equipment currentTrinket1 = null;
	private Equipment currentTrinket2 = null;
	private Equipment currentMainhand = null;
	private Equipment currentOffhand = null;

	[Header("Null Texture")]
	public Texture2D alpha;
	[Header("Layer Positions")]
	public RawImage baseLayer				= null;
	public RawImage faceLayer				= null;
	public RawImage facialHairLayer			= null;
	public RawImage scalpLayer				= null;
	public RawImage underwearLayer			= null;
	public RawImage upperBodyLayer			= null;
	public RawImage shirtUpperLayer			= null;
	public RawImage shirtLowerLayer			= null;
	public RawImage shirtSleeveLowerLayer	= null;
	public RawImage shirtSleeveUpperLayer	= null;
	public RawImage torsoUpperLayer			= null;
	public RawImage torsoLowerLayer			= null;
	public RawImage sleeveLowerLayer		= null;
	public RawImage sleeveUpperLayer		= null;
	public RawImage bracerLayer				= null;
	public RawImage wristLayer				= null;
	public RawImage gloveLayer				= null;
	public RawImage legUpperLayer			= null;
	public RawImage legBeltLayer			= null;
	public RawImage legLowerLayer			= null;
	public RawImage legBootLayer			= null;
	public RawImage LegFootLayer			= null;

	// Start is called before the first frame update
	void Start()
    {
		ClothingLayers();
    }

    // Update is called once per frame
    void Update()
    {
		ClothingLayers();
    }

	void ClothingLayers()
	{
		if (chest != currentChest)
		{
			CheckLayers(chest);
			currentChest = chest;
		}
		if (legs != currentLegs)
		{
			CheckLayers(legs);
			currentLegs = legs;
		}
	}

	void CheckLayers(Equipment item)
	{
		for (int  i = 0;  i < item.layers.Length;  i++)
		{
			if (item.layers[i].affectedLayer == EquipmentLayers.layer.torsoLowerLayer)
			{
				torsoLowerLayer.texture = item.layers[i].layerImageMale;
			}
			//else { torsoLowerLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.torsoUpperLayer)
			{
				torsoUpperLayer.texture = item.layers[i].layerImageMale;
			}
			//else { torsoUpperLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.sleeveLowerLayer)
			{
				sleeveLowerLayer.texture = item.layers[i].layerImageMale;
			}
			//else { sleeveLowerLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.sleeveUpperLayer)
			{
				sleeveUpperLayer.texture = item.layers[i].layerImageMale;
			}
			//else { sleeveUpperLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.legLowerLayer)
			{
				legLowerLayer.texture = item.layers[i].layerImageMale;
			}
			//else { torsoLowerLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.legUpperLayer)
			{
				legUpperLayer.texture = item.layers[i].layerImageMale;
			}
			//else { torsoUpperLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.legBeltLayer)
			{
				legBeltLayer.texture = item.layers[i].layerImageMale;
			}
			//else { sleeveLowerLayer.texture = alpha; }
			else if (item.layers[i].affectedLayer == EquipmentLayers.layer.legBootLayer)
			{
				legBootLayer.texture = item.layers[i].layerImageMale;
			}
			//else { sleeveUpperLayer.texture = alpha; }
		}
	}
			 
}			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 