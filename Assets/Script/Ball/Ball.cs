using Script.Platform;
using UnityEngine;

namespace Script.Ball
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlatformSegment platformSegment))
            {
                other.GetComponentInParent<Platform.Platform>().Break();
            }
        }
    }
}