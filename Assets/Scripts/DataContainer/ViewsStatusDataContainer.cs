using Bounce.EventSystem;
using Bounce.Utilities;
using Bounce.DataModel;

namespace Bounce.DataLayer
{
    public class ViewsStatusDataContainer : IGameServices
    {
     




       

        // To set SFX type View
        private SFXType _sFXType;

        public bool IsMusicSettingChange
        {
            set
            {
                if (value)
                {
                    EventManager.Instance.InvokeEvent(ViewsStatusEventsKey.OnChangeInMusicSetting);
                }
            }
        }

        public bool QuitGameButtonClicked
        {
            set
            {
                if (value)
                {
                    EventManager.Instance.InvokeEvent(ViewsStatusEventsKey.OnClickQuitGame);
                }
            }
        }
        public SFXType SFXType
        {
            get => _sFXType;

            set
            {
                _sFXType = value;
                EventManager.Instance.InvokeEvent(ViewsStatusEventsKey.OnSFXUpdate);
            }
        }

    }
}

