using Combat.Weapon.Views;
using Core.Shops.SkinShop;
using UnityEditor;

[CustomPropertyDrawer(typeof(PlacePointWeaponDictionary))]
public class PlacePointWeaponDictionaryUI : SerializableDictionaryPropertyDrawer {}
[CustomPropertyDrawer(typeof(SkinPlacePriceDictionary))]
public class SkinPlacePriceDictionaryUI : SerializableDictionaryPropertyDrawer {}