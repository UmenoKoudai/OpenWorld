public class EndTalk : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.NpcBase.TextContent.text = evl.NpcBase.TalcDeck.Talk;
        evl.NpcBase.Menu.SetActive(false);
        evl.NpcBase.Shortcut.SetActive(true);
    }
}
