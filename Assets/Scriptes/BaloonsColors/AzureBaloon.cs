using UnityEngine;

namespace Scriptes
{
    public class AzureBaloon: Baloon
    {
        [SerializeField] private Transform _centrMass;

        private void Awake()
        {
            CentrMass(_centrMass);
        }
    }
}