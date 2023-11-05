using UnityEngine;

public class NPCB : NPCBase
{
    [SerializeField] GameObject _nameTextObj;

    private void Update()
    {
        if (_nameTextObj)
        {
            var lookForward = _nameTextObj.transform.position - SetUp().Player[0].transform.position;
            _nameTextObj.transform.forward = new Vector3(lookForward.x, 0, lookForward.z);
        }
    }
}
