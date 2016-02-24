// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Novaflowerseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "novaflower";
			this.plantname = "Novaflowers";
			this.product = typeof(Obj_Item_Weapon_Grown_Novaflower);
			this.lifespan = 25;
			this.endurance = 20;
			this.maturation = 6;
			this.production = 2;
			this.yield = 2;
			this.potency = 20;
			this.oneharvest = true;
			this.growthstages = 3;
			this.rarity = 20;
			this.icon_state = "seed-novaflower";
		}

		public Obj_Item_Seeds_Novaflowerseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}