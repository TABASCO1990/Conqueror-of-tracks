using System;

public class LevelScreen : Screen
{
    public event Action MenuButtonClick;

    public override void OnButtonClick()
    {
        MenuButtonClick?.Invoke();
    }
}
