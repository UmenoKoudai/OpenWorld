using Unity.VisualScripting;

public class ShopOpenButton : IButton
{
    public void ButtonEffect(Evaluator evl)
    {
        evl.OpenMenu();
    }
}
