// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Twohanded_Dualsaber_Toy : Obj_Item_Weapon_Twohanded_Dualsaber {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.attack_verb = new ByTable(new object [] { "attacked", "struck", "hit" });
		}

		public Obj_Item_Weapon_Twohanded_Dualsaber_Toy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toys.dm
		public override bool IsReflect( dynamic def_zone = null ) {
			return false;
		}

		// Function from file: toys.dm
		public override bool hit_reaction( Mob_Living_Carbon owner = null, string attack_text = null, int? final_block_chance = null, dynamic damage = null, int? attack_type = null ) {
			return false;
		}

	}

}