// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Pulse_Destroyer : Obj_Item_Weapon_Gun_Energy_Pulse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cell_type = "/obj/item/weapon/stock_parts/cell/infinite";
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Laser_Pulse) });
		}

		public Obj_Item_Weapon_Gun_Energy_Pulse_Destroyer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pulse.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			user.WriteMsg( "<span class='danger'>" + this.name + " has three settings, and they are all DESTROY.</span>" );
			return null;
		}

	}

}