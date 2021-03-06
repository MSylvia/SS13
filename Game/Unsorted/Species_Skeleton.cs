// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Skeleton : Species {

		public ByTable myspan = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spooky Scary Skeleton";
			this.id = "skeleton";
			this.say_mod = "rattles";
			this.need_nutrition = false;
			this.blacklisted = true;
			this.sexes = false;
			this.meat = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human_Mutant_Skeleton);
			this.specflags = new ByTable(new object [] { 256, 64, "Cold Resistance", 1024, 128, 4096, 8192 });
		}

		// Function from file: species_types.dm
		public Species_Skeleton (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.myspan = new ByTable(new object [] { Rand13.Pick(new object [] { "sans", "papyrus" }) });
			return;
		}

		// Function from file: species_types.dm
		public override dynamic get_spans(  ) {
			return this.myspan;
		}

	}

}