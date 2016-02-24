// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Deathberryseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "deathberry";
			this.plantname = "Death Berry Bush";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries_Death);
			this.lifespan = 30;
			this.endurance = 20;
			this.maturation = 5;
			this.production = 5;
			this.yield = 3;
			this.potency = 50;
			this.growthstages = 6;
			this.rarity = 30;
			this.icon_state = "seed-deathberry";
		}

		public Obj_Item_Seeds_Deathberryseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}