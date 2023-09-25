using UnityEngine;

namespace Economics.Money
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _moneyPrefab;
        
        [SerializeField] private int _minMoney;
        [SerializeField] private int _maxMoney;

        [SerializeField] private float _axisSpreadMin = -2;
        [SerializeField] private float _axisSpreadMax = 3;

        public void Spawn()
        {
            int money = Random.Range(_minMoney, _maxMoney);

            for (int i = 0; i < money; i++)
            {
                Vector3 position = new(
                    Random.Range(_axisSpreadMin, _axisSpreadMax),
                    2f,
                    Random.Range(_axisSpreadMin, _axisSpreadMax));
                
                Instantiate(_moneyPrefab, transform.position + position, Quaternion.identity);
            }
        }
    }
}