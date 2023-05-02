using CounterScripts;

public class OptionsView : BaseView
{
    private void Start()
    {
        GameInput.Instance.OnPauseAction += (_, _) => Hide();
    }
}
