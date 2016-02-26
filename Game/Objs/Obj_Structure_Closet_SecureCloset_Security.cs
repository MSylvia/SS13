// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Security : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 1 });
			this.icon_state = "sec";
		}

		// Function from file: security.dm
		public Obj_Structure_Closet_SecureCloset_Security ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Suit_Armor_Vest( this );
			new Obj_Item_Device_Radio_Headset_HeadsetSec( this );
			new Obj_Item_Device_Radio_Headset_HeadsetSec_Alt( this );
			new Obj_Item_Weapon_ReagentContainers_Spray_Pepper( this );
			new Obj_Item_Device_Assembly_Flash_Handheld( this );
			new Obj_Item_Weapon_Grenade_Flashbang( this );
			new Obj_Item_Weapon_Storage_Belt_Security_Full( this );
			new Obj_Item_Clothing_Glasses_Hud_Security_Sunglasses( this );
			new Obj_Item_Clothing_Head_Helmet_Sec( this );
			return;
		}

	}

}