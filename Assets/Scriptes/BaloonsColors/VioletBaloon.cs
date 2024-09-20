using UnityEngine;

namespace Scriptes
{
    public class VioletBaloon: Baloon
    {
        [SerializeField] private Transform _centrMass;

        private void Awake()
        {
            CentrMass(_centrMass);
        }
    }
}