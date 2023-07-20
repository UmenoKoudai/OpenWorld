using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Attack : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        CharacterBase myself = GetComponentInParent<CharacterBase>();
        CharacterBase opponent = other.GetComponent<CharacterBase>();
        if(opponent && myself && opponent.name != myself.name)
        {
            int damage = myself.Attack - opponent.Defense > 0 ? myself.Attack - opponent.Defense : 0;
            Debug.Log($"{opponent.name}Ç…{damage}É_ÉÅÅ[ÉWó^Ç¶ÇΩ");
            opponent.Damage(damage);
        }
    }
}
