using System;
using UnityEngine;

namespace Gamekit3D
{
    [Serializable]
    public partial class Damageable : MonoBehaviour
    {
        [Serializable]
        public struct DamageMessage
        {
            public MonoBehaviour damager;
            public int amount;
            public Vector3 direction;
            public Vector3 damageSource;
            public bool throwing;

            public bool stopCamera;
        }
    } 
}
