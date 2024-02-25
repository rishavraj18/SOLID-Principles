using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Principles
{
    // Interface for switchable devices
    public interface ISwitchable
    {
        void TurnOn();
        void TurnOff();
    }

    // Interface for rechargeable devices
    public interface IRechargeable
    {
        void Recharge();
    }

    //In this improved design, we have separate interfaces for switchable (ISwitchable) and rechargeable (IRechargeable) devices.
    //Now, implementing classes can choose the interfaces that align with their functionalities.
    //For example, a light switch class can implement ISwitchable, and a smartphone class can implement both ISwitchable and IRechargeable.
}
