using strange.extensions.mediation.impl;

public class ClickedOnDetector : EventView
{
    protected bool isMouseOn;
    void OnMouseEnter()
    {
        isMouseOn = true;
    }
    void OnMouseExit()
    {
        isMouseOn = false;
    }
    void OnMouseDown()
    {
        if (isMouseOn)
        {
            dispatcher.Dispatch(EventConstants.ClickedOn);
        }
    }
}
