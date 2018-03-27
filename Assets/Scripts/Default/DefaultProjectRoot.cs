using strange.extensions.context.impl;

public class DefaultProjectRoot : ContextView
{
    void Awake()
    {
        //Instantiate the context, passing it this instance.
        context = new DefaultContext(this);
    }
}
