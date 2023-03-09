using Scripts.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.WayPoints
{
    public class StagePoint : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyes;
        [SerializeField] private PlayerMovingComponent _playerMoving;

        private const int _index = 0;

        public void RemoveFromList()
        {
            _enemyes.RemoveAt(_index);
            if (_enemyes.Count == 0)
                _playerMoving.SetNextPoint();
        }
    }
}