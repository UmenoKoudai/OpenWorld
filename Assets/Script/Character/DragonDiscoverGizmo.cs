using UnityEngine;
using Utils;

public class DragonDiscoverGizmo : MonoBehaviour
{
    [SerializeField]
    Dragon _dragon;

    private void OnDrawGizmos()
    {
        if (_dragon)
        {
            Vector3 drawPos = new Vector3(_dragon.transform.position.x, transform.position.y + 0.5f, _dragon.transform.position.z);
            Gizmos.color = Color.red;
            GizmosExtensions.DrawWireCircle(drawPos, _dragon.DiscoverDistance);
        }
    }
}
