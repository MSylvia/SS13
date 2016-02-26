// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Soyaseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "soybean";
			this.plantname = "Soybean Plants";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Soybeans);
			this.lifespan = 25;
			this.endurance = 15;
			this.maturation = 4;
			this.production = 4;
			this.yield = 3;
			this.potency = 15;
			this.growthstages = 4;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Koiseed) });
			this.icon_state = "seed-soybean";
		}

		public Obj_Item_Seeds_Soyaseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}