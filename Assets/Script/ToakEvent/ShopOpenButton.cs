public class ShopOpenButton : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.NpcBase.TextContent.text = evl.NpcBase.TalcDeck.Talk;
        evl.NpcBase.Menu.SetActive(true);
        evl.NpcBase.Shortcut.SetActive(false);
    }
}
