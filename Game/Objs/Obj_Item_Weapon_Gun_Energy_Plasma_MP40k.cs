// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Plasma_MP40k : Obj_Item_Weapon_Gun_Energy_Plasma {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Energy_Plasma_MP40k);
			this.charge_cost = 75;
			this.icon_state = "PlasMP";
		}

		public Obj_Item_Weapon_Gun_Energy_Plasma_MP40k ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}