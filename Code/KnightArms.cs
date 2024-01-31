using MonoMod.Utils;
using Quintessential;
using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System.Collections.Generic;
using System.Reflection;
using SDL2;
using MonoMod.RuntimeDetour;
using FTSIGCTU;
using System.Linq;

namespace KnightArms
{

    public class KnightArms : QuintessentialMod
    {
        private static SDL.enum_160 KnightKey = SDL.enum_160.SDLK_k;

        private ILHook method_2008_hook;

        public static void method_231_knightarms(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);
            if(
                !cursor.TryGotoNext(MoveType.After, instr => instr.Match(OpCodes.Ldloc_1))
            ) { return; }
            cursor.RemoveRange(2);
            cursor.Emit(OpCodes.Ldarg_1);
            cursor.EmitDelegate<Func<int, Part, HexIndex>>((int q, Part partType) => {
                var partDyn = new DynamicData(partType.method_1159());
                var IsKnight = partDyn.Get("PartTypeIsKnight");
                if(IsKnight == null) {
                    return new HexIndex(q, 0);
                }
                switch(IsKnight) {
                    case Parts.KnightArmDirection.Left: 
                        return new HexIndex(q, 1);
                    case Parts.KnightArmDirection.Right: 
                        return new HexIndex(q + 1, -1);
                    default: 
                        return new HexIndex(q, 0);
                }
            });
        }

        private static void SEB_method_2008(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);
            if(
                !cursor.TryGotoNext(MoveType.Before, instr => instr.Match(OpCodes.Stloc_1))
            ) { return; }
            cursor.Emit(OpCodes.Ldarg_0);
            cursor.EmitDelegate<Func<class_126, Part, class_126>>((normal_textures, partType) => {
                var partDyn = new DynamicData(partType.method_1159());
                var IsKnight = partDyn.Get("PartTypeIsKnight");
                if(IsKnight == null) {
                    return normal_textures;
                }
                switch(IsKnight) {
                    case Parts.KnightArmDirection.Left:
                        return CustomTextures.KnightArmGripperLightingLeft;
                    case Parts.KnightArmDirection.Right:
                        return CustomTextures.KnightArmGripperLightingRight;
                    default:
                    return normal_textures;
                }
            });
        }

        public static void SolutionEditorScreen_method_50(On.SolutionEditorScreen.orig_method_50 orig, SolutionEditorScreen SES_self, float param_5703)
        {
            var current_interface = SES_self.field_4010;
            if(Input.IsSdlKeyPressed(KnightKey) && current_interface.GetType() == new PartDraggingInputMode().GetType()) {
                bool isModKeyPressed = Input.IsShiftHeld();
                DynamicData interfaceDyn = new DynamicData(current_interface);
                var draggedParts = interfaceDyn.Get<List<PartDraggingInputMode.DraggedPart>>("field_2712");

                foreach(var draggedPart in draggedParts)
                {
                    class_139 draggedPartType = draggedPart.field_2722.method_1159();
                    
                    if(!Parts.KnightArmIncrement.ContainsKey(draggedPartType)) continue;
                    
                    class_139 newPartType;
                    if(isModKeyPressed) {
                        newPartType = Parts.KnightArmDecrement[draggedPartType];
                    } else {
                        newPartType = Parts.KnightArmIncrement[draggedPartType];
                    }
                    DynamicData draggedPartDyn = new DynamicData(draggedPart.field_2722);
                    draggedPartDyn.Set("field_2691", newPartType);
                }
            }

            orig(SES_self, param_5703);
        }
        
        // FTSIGCTU Mirroring
        public static bool mirror_KnightArmLeft(SolutionEditorScreen ses, Part part, bool mirrorVert, HexIndex pivot)
        {
            FTSIGCTU.MirrorTool.mirrorVanillaArm(ses, part, mirrorVert, pivot);
            (new DynamicData(part)).Set("field_2691", Parts.KnightArmIncrement[part.method_1159()]);
            return true;
        }

        public static bool mirror_KnightArmRight(SolutionEditorScreen ses, Part part, bool mirrorVert, HexIndex pivot)
        {
            FTSIGCTU.MirrorTool.mirrorVanillaArm(ses, part, mirrorVert, pivot);
            (new DynamicData(part)).Set("field_2691", Parts.KnightArmDecrement[part.method_1159()]);
            return true;
        }

        private static void LoadMirrorRules()
        {
            FTSIGCTU.MirrorTool.addRule(Parts.MonoKnightArmLeft, mirror_KnightArmLeft);
            FTSIGCTU.MirrorTool.addRule(Parts.BisexualKnightArmLeft, mirror_KnightArmLeft);
            FTSIGCTU.MirrorTool.addRule(Parts.TriKnightArmLeft, mirror_KnightArmLeft);
            FTSIGCTU.MirrorTool.addRule(Parts.HexKnightArmLeft, mirror_KnightArmLeft);

            FTSIGCTU.MirrorTool.addRule(Parts.MonoKnightArmRight, mirror_KnightArmRight);
            FTSIGCTU.MirrorTool.addRule(Parts.BisexualKnightArmRight, mirror_KnightArmRight);
            FTSIGCTU.MirrorTool.addRule(Parts.TriKnightArmRight, mirror_KnightArmRight);
            FTSIGCTU.MirrorTool.addRule(Parts.HexKnightArmRight, mirror_KnightArmRight);
        }

        public override void Load() {
            
        }   

        public override void LoadPuzzleContent() {
            Logger.Log("Loading KnightArms");
            Parts.Initialize();
            
            IL.class_123.method_231 += method_231_knightarms;
            On.SolutionEditorScreen.method_50 += SolutionEditorScreen_method_50;

            method_2008_hook = new ILHook(typeof(SolutionEditorBase).GetMethod("method_2008", BindingFlags.Static | BindingFlags.NonPublic),
                        SEB_method_2008);
        }

        public override void PostLoad() {
            if(QuintessentialLoader.CodeMods.Any(mod => mod.Meta.Name == "FTSIGCTU"))
            {
                Logger.Log("I loved the part where the knight arms said \"It's mirrorin' time\" and mirror'd all over those guys");
                LoadMirrorRules();
            }
        }

        public override void Unload() {
            IL.class_123.method_231 -= method_231_knightarms;
            On.SolutionEditorScreen.method_50 -= SolutionEditorScreen_method_50;
            method_2008_hook.Dispose();
        }
    }
}