// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Plasmacutter_Adv : Obj_Item_Weapon_Gun_Energy_Plasmacutter {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=3;materials=4;magnets=3;plasmatech=3;engineering=2";
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Plasma_Adv) });
			this.icon_state = "adv_plasmacutter";
		}

		public Obj_Item_Weapon_Gun_Energy_Plasmacutter_Adv ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}