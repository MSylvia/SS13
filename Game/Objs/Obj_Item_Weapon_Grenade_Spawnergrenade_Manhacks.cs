// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_Spawnergrenade_Manhacks : Obj_Item_Weapon_Grenade_Spawnergrenade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawner_type = typeof(Mob_Living_SimpleAnimal_Hostile_Viscerator);
			this.deliveryamt = 5;
			this.origin_tech = "materials=3;magnets=4;syndicate=4";
		}

		public Obj_Item_Weapon_Grenade_Spawnergrenade_Manhacks ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}