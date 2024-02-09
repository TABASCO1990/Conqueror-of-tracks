using System;

public class StartScreen : Screen
{
    public event Action PlayButtonClick;

    public override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
