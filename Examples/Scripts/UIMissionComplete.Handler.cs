using UnuGames;

public partial class UIMissionComplete : UIManDialog
{
    #region Fields

    // Your fields here

    #endregion Fields

    #region Built-in Events

    public override void OnShow(params object[] args)
    {
        base.OnShow(args);
    }

    public override void OnShowComplete()
    {
        base.OnShowComplete();
    }

    public override void OnHide()
    {
        base.OnHide();
    }

    public override void OnHideComplete()
    {
        base.OnHideComplete();
    }

    #endregion Built-in Events

    #region Custom implementation

    // Your custom code here
    public void Home()
    {
        HideMe();
        UIMan.Instance.ShowScreen<UIMainMenu>();
    }

    public void Replay()
    {
        HideMe();
        UIMan.Instance.GetHandler<UIGameplay>().Replay();
    }

    #endregion Custom implementation

    #region Override animations

    /* Uncommend this for override show/hide animation of Screen/Dialog use tweening code
	public override IEnumerator AnimationShow ()
	{
		return base.AnimationShow ();
	}

	public override IEnumerator AnimationHide ()
	{
		return base.AnimationHide ();
	}

	public override IEnumerator AnimationIdle ()
	{
		return base.AnimationHide ();
	}
	*/

    #endregion Override animations
}