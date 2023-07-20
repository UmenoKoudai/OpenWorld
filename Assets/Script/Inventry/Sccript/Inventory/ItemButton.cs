using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : Evaluator, IPointerClickHandler
{
    ItemState _myItem;
    public ItemState MyItem { get => _myItem; set => _myItem = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        Evaluator evl = SetUp();
        if (_myItem.Ability != null)
        {
            _myItem.Target.TargetSet(SetUp());
            if (_myItem.Condition.All(x => x.Check(SetUp())))
            {
                _myItem.Ability.Use(SetUp());
                Inventory.Instance.ItemCountDown(_myItem.ItemID);
            }
        }
    }
    private void Awake()
    {
        _myItem = new ItemState(-1, default, 0, null);
    }
    void Update()
    {
        GetComponent<Image>().sprite = _myItem.ItemImage;
        GetComponentInChildren<Text>().text = _myItem.ItemCount.ToString();
    }
}
