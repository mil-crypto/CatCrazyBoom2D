using UnityEngine;

    namespace Scriptes
    {
        public class YellowBaloon: Baloon
        {
            [SerializeField] private Transform _centrMass;

            private void Awake()
            {
                CentrMass(_centrMass);
            }
        }
    }