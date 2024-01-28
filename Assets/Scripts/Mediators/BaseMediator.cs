
using Bounce.ViewLayer;

namespace Bounce.MediatorLayer
{
    public class BaseMediator<T> where T : BaseView
    {
        protected T view;
    }
}
