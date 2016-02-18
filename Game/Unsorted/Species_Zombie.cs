// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Zombie : Species {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Brain-Munching Zombie";
			this.id = "zombie";
			this.say_mod = "moans";
			this.sexes = false;
			this.blacklisted = true;
			this.meat = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human_Mutant_Zombie);
			this.specflags = new ByTable(new object [] { 256, 64, "Cold Resistance", 1024, 128 });
		}

		// Function from file: species_types.dm
		public override dynamic handle_speech( dynamic message = null, Mob_Living_Carbon_Human H = null ) {
			ByTable message_list = null;
			int maxchanges = 0;
			int? i = null;
			int insertpos = 0;
			string inserttext = null;

			message_list = GlobalFuncs.splittext( message, " " );
			maxchanges = Num13.MaxInt( Num13.Floor( message_list.len / 1.5 ), 2 );
			i = null;
			i = Rand13.Int( ((int)( maxchanges / 2 )), maxchanges );

			while (( i ??0) > 0) {
				insertpos = Rand13.Int( 1, message_list.len - 1 );
				inserttext = message_list[insertpos];

				if ( !( String13.SubStr( inserttext, Lang13.Length( inserttext ) - 2, 0 ) == "..." ) ) {
					message_list[insertpos] = inserttext + "...";
				}

				if ( Rand13.PercentChance( 20 ) && message_list.len > 3 ) {
					message_list.Insert( insertpos, "" + Rand13.Pick(new object [] { "BRAINS", "Brains", "Braaaiinnnsss", "BRAAAIIINNSSS" }) + "..." );
				}
				i--;
			}
			return GlobalFuncs.jointext( message_list, " " );
		}

	}

}