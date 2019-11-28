using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
	public enum itemType {Armour, Consumable, Container, Gem, Key, Miscellaneous, Money, Reagent, Recipe, Projectile, Quest, Quiver, TradeGoods, Weapon};
	public enum itemQuality {Poor, Common, Uncommon, Rare, Epic, Legendary, Artifact, Hairloom};

	public Texture2D itemIcon;
	public string itemName;
	public string itemDescription;
	public bool stackable;
	public int maxStackSize;
	public int currentItemStack;

}
