// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Gatfruit : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "gatfruit";
			this.plantname = "gatfruit";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Gatfruit);
			this.lifespan = 20;
			this.endurance = 20;
			this.maturation = 40;
			this.production = 10;
			this.yield = 2;
			this.potency = 60;
			this.growthstages = 2;
			this.rarity = 50;
			this.icon_state = "seed-gatfruit";
		}

		public Obj_Item_Seeds_Gatfruit ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}