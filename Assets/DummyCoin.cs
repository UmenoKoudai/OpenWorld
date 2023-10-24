using UnityEngine;

public class DummyCoin : MonoBehaviour
{
    void Start()
    {
        Invoke("CoinCreate", 0.6f);
    }

    public void CoinCreate()
    {
        Instantiate(Resources.Load<GameObject>("GoldCoin"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
