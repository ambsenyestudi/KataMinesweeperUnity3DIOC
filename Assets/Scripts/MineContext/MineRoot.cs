using strange.extensions.context.impl;

public class MineRoot : ContextView
{
    void Awake()
    {
        //Instantiate the context, passing it this instance.
        context = new MineContext(this);
    }
}