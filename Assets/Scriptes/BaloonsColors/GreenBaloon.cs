using UnityEngine;

namespace Scriptes
{
    public class GreenBaloon : Baloon
    {
        [SerializeField] private Transform _centrMass;

        private void Awake()
        {
            CentrMass(_centrMass);
        }
    }
}

