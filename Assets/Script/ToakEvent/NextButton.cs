public class NextButton : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.NpcBase.TextContent.text = evl.NpcBase.TalcDeck.Talk;
    }
}
