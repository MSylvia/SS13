// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Monkey_Unathi : Mob_Living_Carbon_Monkey {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.voice_name = "stok";
			this.speak_emote = new ByTable(new object [] { "hisses" });
			this.uni_append = new ByTable(new object [] { 68, 3165 });
			this.canWearClothes = false;
			this.species_type = typeof(Mob_Living_Carbon_Monkey_Unathi);
			this.icon_state = "stokkey1";
		}

		// Function from file: monkey.dm
		public Mob_Living_Carbon_Monkey_Unathi ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.dna.mutantrace = "lizard";
			this.greaterform = "Unathi";
			this.add_language( "Sinta'unathi" );
			return;
		}

	}

}