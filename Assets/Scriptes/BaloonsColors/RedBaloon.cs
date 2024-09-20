using UnityEngine;

namespace Scriptes
{
    public class RedBaloon : Baloon
    {
        [SerializeField] private Transform _centrMass;

        private void Update()
        {
            CentrMass(_centrMass);
        }
    }
}
