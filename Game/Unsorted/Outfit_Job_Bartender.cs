// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_Bartender : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bartender";
			this.glasses = typeof(Obj_Item_Clothing_Glasses_Sunglasses_Reagent);
			this.belt = typeof(Obj_Item_Device_Pda_Bar);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetSrv);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_Bartender);
			this.suit = typeof(Obj_Item_Clothing_Suit_Armor_Vest);
			this.backpack_contents = new ByTable().Set( typeof(Obj_Item_Weapon_Storage_Box_Beanbag), 1 );
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Laceup);
		}

	}

}