// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Warden : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 3 });
			this.icon_state = "warden";
		}

		// Function from file: security.dm
		public Obj_Structure_Closet_SecureCloset_Warden ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Device_Radio_Headset_HeadsetSec( this );
			new Obj_Item_Clothing_Suit_Armor_Vest_Warden( this );
			new Obj_Item_Clothing_Head_Warden( this );
			new Obj_Item_Clothing_Head_Beret_Sec_Navywarden( this );
			new Obj_Item_Clothing_Suit_Armor_Vest_Warden_Alt( this );
			new Obj_Item_Clothing_Under_Rank_Warden_Navyblue( this );
			new Obj_Item_Clothing_Glasses_Hud_Security_Sunglasses( this );
			new Obj_Item_Clothing_Mask_Gas_Sechailer( this );
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Weapon_Storage_Box_Zipties( this );
			new Obj_Item_Tapeproj_Security( this );
			new Obj_Item_Weapon_ReagentContainers_Spray_Pepper( this );
			new Obj_Item_Weapon_Melee_Baton_Loaded( this );
			new Obj_Item_Weapon_Storage_Belt_Security_Full( this );
			return;
		}

	}

}