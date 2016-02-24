// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Snapcornseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "snapcorn";
			this.plantname = "Snapcorn Stalks";
			this.product = typeof(Obj_Item_Weapon_Grown_Snapcorn);
			this.lifespan = 25;
			this.endurance = 15;
			this.maturation = 8;
			this.production = 6;
			this.yield = 3;
			this.oneharvest = true;
			this.potency = 20;
			this.growthstages = 3;
			this.rarity = 10;
			this.icon_state = "seed-snapcorn";
		}

		public Obj_Item_Seeds_Snapcornseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}