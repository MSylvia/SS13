// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Energy_Flora_Yield : Obj_Item_AmmoCasing_Energy_Flora {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Energy_Florayield);
			this.select_name = "yield";
		}

		public Obj_Item_AmmoCasing_Energy_Flora_Yield ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}