using System;

namespace CTTManagement.DataModel.ZatsTests.Enums
{
    [Serializable]
    public enum Libraries
    {
        NoLib = 0,
        ControllerStaticLib = 1,
        ControllerPortableLib = 2,
        SlaveEnhancedLib = 3,
        SlaveLib = 4,
        InstallerLib = 5,
        SlaveRoutingLib = 6,
        ControllerBridgeLib = 7,
        DoorLockKeyPad = 8,
        PowerStrip = 9,
        SensorPIR = 10,
        SwitchOnOff = 11,
        WallController = 12,
        Noise0Term = 13,
        LEDBulb = 14,
        ZnifferPTI = 15,
    }
}
