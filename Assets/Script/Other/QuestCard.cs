using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestCard : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField]
    GameObject _questClearTag;
    [SerializeField]
    GameObject _questSelectTag;
    [SerializeField]
    Text _questContent;
    [SerializeField]
    Image _questImage;

    NowQuest _quest;
    bool _isClear = false;
    Data _questData;
    public Data QuestData { get => _questData; set => _questData = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        _quest.OnClear += OnClear;
        _quest.SetQuestData(_questData);
        _questSelectTag.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //transform.SetAsLastSibling();
    }

    void OnClear()
    {
        _isClear = true;
    }

    private void Awake()
    {
        _quest = FindObjectOfType<NowQuest>();
    }

    void Update()
    {
        if(_isClear)
        {
            _questSelectTag.SetActive(false);
        }
        _questClearTag.SetActive(_isClear);
        _questContent.text = _questData.Content;
        _questImage.sprite = _questData.QuestImage;
    }
}
