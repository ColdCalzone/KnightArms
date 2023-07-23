using MonoMod.Utils;
using System.Collections.Generic;
using Quintessential;

public static class Parts {
    public enum KnightArmDirection {
        None,
        Left,
        Right,
    }
    
    public static Dictionary<class_139, class_139> KnightArmIncrement = new Dictionary<class_139, class_139>();
    public static Dictionary<class_139, class_139> KnightArmDecrement = new Dictionary<class_139, class_139>();
    
    public static class_139 MonoKnightArmLeft = new class_139() 
    {
        /*ID*/field_1528 = "knight-arm",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("A single arm and gripper, with a bend.", string.Empty),
        /*Cost*/field_1531 = 20,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[1]
        {
            HexRotation.R0
        },
        field_1536 = true,
        field_1551 = enum_149.SimpleArm,
    };
    public static class_139 BisexualKnightArmLeft = new class_139() 
    {
        /*ID*/field_1528 = "biknight-arm",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("An assembly of two arms and grippers, with a bend.", string.Empty),
        /*Cost*/field_1531 = 30,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[2]
        {
            HexRotation.R0,
            HexRotation.R180,
        },
        field_1536 = true,
        field_1551 = enum_149.MultiArms,
    };
    public static class_139 TriKnightArmLeft = new class_139() 
    {
        /*ID*/field_1528 = "triknight-arm",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("An assembly of three arms and grippers, with a bend.", string.Empty),
        /*Cost*/field_1531 = 30,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[3]
        {
            HexRotation.R0,
            HexRotation.R120,
            HexRotation.R240,
        },
        field_1536 = true,
        field_1551 = enum_149.MultiArms,
    };
    public static class_139 HexKnightArmLeft = new class_139() 
    {
        /*ID*/field_1528 = "hexknight-arm",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("An assembly of six arms and grippers, with a bend.", string.Empty),
        /*Cost*/field_1531 = 30,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[6]
        {
            HexRotation.R0,
            HexRotation.R60,
            HexRotation.R120,
            HexRotation.R180,
            HexRotation.R240,
            HexRotation.R300,
        },
        field_1536 = true,
        field_1551 = enum_149.MultiArms,
    };

    public static class_139 MonoKnightArmRight = new class_139() 
    {
        /*ID*/field_1528 = "knight-arm-right",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("A single arm and gripper, with a bend.", string.Empty),
        /*Cost*/field_1531 = 20,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[1]
        {
            HexRotation.R0
        },
        field_1536 = true,
        field_1551 = enum_149.SimpleArm,
    };
    public static class_139 BisexualKnightArmRight = new class_139() 
    {
        /*ID*/field_1528 = "biknight-arm-right",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("An assembly of two arms and grippers, with a bend.", string.Empty),
        /*Cost*/field_1531 = 30,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[2]
        {
            HexRotation.R0,
            HexRotation.R180,
        },
        field_1536 = true,
        field_1551 = enum_149.MultiArms,
    };
    public static class_139 TriKnightArmRight = new class_139() 
    {
        /*ID*/field_1528 = "triknight-arm-right",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("An assembly of three arms and grippers, with a bend.", string.Empty),
        /*Cost*/field_1531 = 30,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[3]
        {
            HexRotation.R0,
            HexRotation.R120,
            HexRotation.R240,
        },
        field_1536 = true,
        field_1551 = enum_149.MultiArms,
    };
    public static class_139 HexKnightArmRight = new class_139() 
    {
        /*ID*/field_1528 = "hexknight-arm-right",
        /*Name*/field_1529 = class_134.method_253("Fixed-Length Knight Arm", string.Empty),
        /*Desc*/field_1530 = class_134.method_253("An assembly of six arms and grippers, with a bend.", string.Empty),
        /*Cost*/field_1531 = 30,
        field_1532 = (enum_2)1,
        field_1533 = true,
        field_1534 = new HexRotation[6]
        {
            HexRotation.R0,
            HexRotation.R60,
            HexRotation.R120,
            HexRotation.R180,
            HexRotation.R240,
            HexRotation.R300,
        },
        field_1536 = true,
        field_1551 = enum_149.MultiArms,
    };

    public static void Initialize()
    {
        (new DynamicData(class_191.field_1764)).Set("PartTypeIsKnight", KnightArmDirection.None);
        KnightArmIncrement[class_191.field_1764] = MonoKnightArmLeft;
        KnightArmDecrement[MonoKnightArmLeft] = class_191.field_1764;
        (new DynamicData(class_191.field_1765)).Set("PartTypeIsKnight", KnightArmDirection.None);
        KnightArmIncrement[class_191.field_1765] = BisexualKnightArmLeft;
        KnightArmDecrement[BisexualKnightArmLeft] = class_191.field_1765;
        (new DynamicData(class_191.field_1766)).Set("PartTypeIsKnight", KnightArmDirection.None);
        KnightArmIncrement[class_191.field_1766] = TriKnightArmLeft;
        KnightArmDecrement[TriKnightArmLeft] = class_191.field_1766;
        (new DynamicData(class_191.field_1767)).Set("PartTypeIsKnight", KnightArmDirection.None);
        KnightArmIncrement[class_191.field_1767] = HexKnightArmLeft;
        KnightArmDecrement[HexKnightArmLeft] = class_191.field_1767;

        (new DynamicData(MonoKnightArmLeft)).Set("PartTypeIsKnight", KnightArmDirection.Left);
        KnightArmIncrement[MonoKnightArmLeft] = MonoKnightArmRight;
        KnightArmDecrement[MonoKnightArmRight] = MonoKnightArmLeft;
        (new DynamicData(BisexualKnightArmLeft)).Set("PartTypeIsKnight", KnightArmDirection.Left);
        KnightArmIncrement[BisexualKnightArmLeft] = BisexualKnightArmRight;
        KnightArmDecrement[BisexualKnightArmRight] = BisexualKnightArmLeft;
        (new DynamicData(TriKnightArmLeft)).Set("PartTypeIsKnight", KnightArmDirection.Left);
        KnightArmIncrement[TriKnightArmLeft] = TriKnightArmRight;
        KnightArmDecrement[TriKnightArmRight] = TriKnightArmLeft;
        (new DynamicData(HexKnightArmLeft)).Set("PartTypeIsKnight", KnightArmDirection.Left);
        KnightArmIncrement[HexKnightArmLeft] = HexKnightArmRight;
        KnightArmDecrement[HexKnightArmRight] = HexKnightArmLeft;

        (new DynamicData(MonoKnightArmRight)).Set("PartTypeIsKnight", KnightArmDirection.Right);
        KnightArmIncrement[MonoKnightArmRight] = class_191.field_1764;
        KnightArmDecrement[class_191.field_1764] = MonoKnightArmRight;
        (new DynamicData(BisexualKnightArmRight)).Set("PartTypeIsKnight", KnightArmDirection.Right);
        KnightArmIncrement[BisexualKnightArmRight] = class_191.field_1765;
        KnightArmDecrement[class_191.field_1765] = BisexualKnightArmRight;
        (new DynamicData(TriKnightArmRight)).Set("PartTypeIsKnight", KnightArmDirection.Right);
        KnightArmIncrement[TriKnightArmRight] = class_191.field_1766;
        KnightArmDecrement[class_191.field_1766] = TriKnightArmRight;
        (new DynamicData(HexKnightArmRight)).Set("PartTypeIsKnight", KnightArmDirection.Right);
        KnightArmIncrement[HexKnightArmRight] = class_191.field_1767;
        KnightArmDecrement[class_191.field_1767] = HexKnightArmRight;
        
        QApi.AddPartType(MonoKnightArmLeft);
        QApi.AddPartType(MonoKnightArmRight);
        QApi.AddPartType(BisexualKnightArmLeft);
        QApi.AddPartType(BisexualKnightArmRight);
        QApi.AddPartType(TriKnightArmLeft);
        QApi.AddPartType(TriKnightArmRight);
        QApi.AddPartType(HexKnightArmLeft);
        QApi.AddPartType(HexKnightArmRight);
    }
}