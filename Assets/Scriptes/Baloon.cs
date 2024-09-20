using UnityEngine;

namespace Scriptes
{
    public class Baloon : MonoBehaviour
    {
        protected void CentrMass(Transform centrMass)
        {
            GetComponent<Rigidbody2D>().centerOfMass = centrMass.localPosition;
        }
    }
}