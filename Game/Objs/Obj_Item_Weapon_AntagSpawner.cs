// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AntagSpawner : Obj_Item_Weapon {

		public bool used = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throw_speed = 1;
			this.throw_range = 5;
			this.w_class = 1;
		}

		public Obj_Item_Weapon_AntagSpawner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: antag_spawner.dm
		public virtual void equip_antag( Mob_Living_Carbon_Human target = null ) {
			return;
		}

		// Function from file: antag_spawner.dm
		public virtual void spawn_antag( dynamic C = null, dynamic T = null, string type = null ) {
			type = type ?? "";

			return;
		}

	}

}