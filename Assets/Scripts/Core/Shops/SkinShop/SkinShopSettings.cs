using System;
using System.Collections.Generic;
using Core.Shops.SkinShop.Components;
using UnityEngine;

namespace Core.Shops.SkinShop
{
    [Serializable]
    public class SkinShopSettings
    {
        [SerializeField] private SkinPlacePriceDictionary _placesWithPrices;

        public Dictionary<SkinPlace, int> Places => new(_placesWithPrices);
    }
    
    [Serializable]
    public class SkinPlacePriceDictionary : SerializableDictionary<SkinPlace, int> {}
}