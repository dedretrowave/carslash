using System;
using System.Collections.Generic;
using Core.Player.Skin.Components;
using Core.Shops.SkinShop.Components;
using Newtonsoft.Json;

namespace Core.Shops.SkinShop.Model
{
    public class SkinShopModel
    {
        private SkinDataSet _skins = new();

        public SkinShopModel(SkinShopSettings settings)
        {
            //TODO: ADD SAVE
            Dictionary<SkinPlace, int> places = settings.Places;
            
            foreach ((SkinPlace place, int price) in places)
            {
                SkinData data = new(
                    place.Skin,
                    price
                    );
                
                _skins.Add(data);
            }
        }

        public void MarkPurchased(Skin skin)
        {
            SkinData data = GetData(skin);
            data.MarkPurchased();
        }

        public void MarkSelected(Skin skin)
        {
            _skins.ForEach(skin => skin.Unselect());
            SkinData data = GetData(skin);
            data.Select();
        }

        public int GetPrice(Skin skin)
        {
            return GetData(skin).Price;
        }

        public bool GetIsPurchased(Skin skin)
        {
            return GetData(skin).IsPurchased;
        }

        private SkinData GetData(Skin skin)
        {
            return _skins.Find(skinData => skinData.Skin.Equals(skin));
        }
    }

    [Serializable]
    internal class SkinData
    {
        private Skin _skin;
        private int _price;
        private bool _isPurchased;
        private bool _isSelected;

        public Skin Skin => _skin;
        public int Price => _price;
        public bool IsPurchased => _isPurchased;
        public bool IsSelected => _isSelected;

        [JsonConstructor]
        public SkinData(Skin skin, int price, bool isPurchased = false)
        {
            _skin = skin;
            _price = price;
            _isPurchased = isPurchased;
        }

        public void MarkPurchased()
        {
            _isPurchased = true;
        }

        public void Select()
        {
            _isSelected = true;
        }

        public void Unselect()
        {
            _isSelected = false;
        }
    }

    [Serializable]
    internal class SkinDataSet
    {
        private List<SkinData> _skins;

        [JsonConstructor]
        public SkinDataSet(List<SkinData> data)
        {
            _skins = new(data);
        }

        public SkinDataSet()
        {
            _skins = new();
        }

        public void Add(SkinData skin)
        {
            _skins.Add(skin);
        }

        public SkinData Find(Predicate<SkinData> callback)
        {
            return _skins.Find(callback);
        }

        public void ForEach(Action<SkinData> callback)
        {
            _skins.ForEach(callback);
        }
    }
}