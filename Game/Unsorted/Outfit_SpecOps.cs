// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_SpecOps : Outfit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Special Ops Officer";
			this.uniform = typeof(Obj_Item_Clothing_Under_Syndicate);
			this.suit = typeof(Obj_Item_Clothing_Suit_Space_Officer);
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Combat_Swat);
			this.gloves = typeof(Obj_Item_Clothing_Gloves_Combat);
			this.glasses = typeof(Obj_Item_Clothing_Glasses_Thermal_Eyepatch);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetCent_Commander);
			this.mask = typeof(Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana);
			this.head = typeof(Obj_Item_Clothing_Head_Helmet_Space_Beret);
			this.belt = typeof(Obj_Item_Weapon_Gun_Energy_Pulse_Pistol_M1911);
			this.r_pocket = typeof(Obj_Item_Weapon_Lighter);
			this.back = typeof(Obj_Item_Weapon_Storage_Backpack_Satchel);
			this.id = typeof(Obj_Item_Weapon_Card_Id);
		}

		// Function from file: standard.dm
		public override void post_equip( Mob H = null, int? visualsOnly = null ) {
			visualsOnly = visualsOnly ?? GlobalVars.FALSE;

			Obj_Item_Weapon_Card_Id W = null;
			Obj_Item_Device_Radio R = null;

			
			if ( Lang13.Bool( visualsOnly ) ) {
				return;
			}
			W = ((dynamic)H).wear_id;
			W.icon_state = "centcom";
			W.access = GlobalFuncs.get_all_accesses();
			W.access += GlobalFuncs.get_centcom_access( "Special Ops Officer" );
			W.assignment = "Special Ops Officer";
			W.registered_name = H.real_name;
			W.update_label();
			R = ((dynamic)H).ears;
			R.set_frequency( GlobalVars.CENTCOM_FREQ );
			R.freqlock = true;
			return;
		}

	}

}