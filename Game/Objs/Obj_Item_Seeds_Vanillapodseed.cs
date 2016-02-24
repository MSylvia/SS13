// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Vanillapodseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "vanillapod";
			this.plantname = "Vanilla Tree";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Vanillapod);
			this.lifespan = 20;
			this.endurance = 15;
			this.maturation = 5;
			this.production = 5;
			this.yield = 2;
			this.potency = 10;
			this.growthstages = 5;
			this.icon_state = "seed-vanillapod";
		}

		public Obj_Item_Seeds_Vanillapodseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}