using System;
using UnityEngine;

namespace Game
{
    public class DataHolder : MonoBehaviour, IController
    {
        public float CurrentSpeed { get; set; }
        public int CurrentCoins { get; set; }

        public event Action<int> AddingCoins;
        public event Action<float> SetedSpeed;

        public void AddCoins()
        {
            CurrentCoins++;
            print(CurrentCoins);
            AddingCoins?.Invoke(CurrentCoins);
        }

        public void SetSpeed()
        {
            
            SetedSpeed?.Invoke(CurrentSpeed);
        }
    }
}
