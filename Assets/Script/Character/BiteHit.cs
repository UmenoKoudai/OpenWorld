using UnityEngine;

public class BiteHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CharacterBase>();
        if(player)
        {
            player.Damage(10);
        }
    }
}
