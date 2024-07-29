using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace RW_CustomPawnGeneration
{
	[StaticConstructorOnStartup]
	public class RW_CustomPawnGeneration
	{
		public const string ID = "com.rimworld.mod.nyan.custom_pawn_generation";

		public static Harmony patcher;

		static RW_CustomPawnGeneration()
		{
			// Initialize default settings.

			Settings.IntDefaults[GenderWindow.GenderSlider] = 50;

			Settings.IntDefaults[AgeWindow.MaxAge] = 999;
			Settings.IntDefaults[AgeWindow.AgeTick] = 1000;
			Settings.IntDefaults[Settings.CustomAging] = 999;
			Settings.IntDefaults[Settings.UngenderedParent] = 1000;

			foreach (BodyTypeDef def in DefDatabase<BodyTypeDef>.AllDefs)
				Settings.IntDefaults[def.defName] = 99;


			// Patch hooks.

			patcher = new Harmony(ID);
			patcher.PatchAll(Assembly.GetExecutingAssembly());

			Module.InitializeAll();
		}
	}
}
