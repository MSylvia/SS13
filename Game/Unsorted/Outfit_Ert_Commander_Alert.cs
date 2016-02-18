// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Ert_Commander_Alert : Outfit_Ert_Commander {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "ERT Commander - High Alert";
			this.backpack_contents = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Storage_Box_Engineer), 1 )
				.Set( typeof(Obj_Item_Weapon_Melee_Baton_Loaded), 1 )
				.Set( typeof(Obj_Item_Clothing_Mask_Gas_Sechailer_Swat), 1 )
				.Set( typeof(Obj_Item_Weapon_Gun_Energy_Pulse_Pistol_Loyalpin), 1 )
			;
			this.l_pocket = typeof(Obj_Item_Weapon_Melee_Energy_Sword_Saber);
		}

	}

}