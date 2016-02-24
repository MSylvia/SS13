// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Engineer : Obj_Effect_Landmark_Corpse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.corpseradio = typeof(Obj_Item_Device_Radio_Headset_HeadsetEng);
			this.corpseuniform = typeof(Obj_Item_Clothing_Under_Rank_Engineer);
			this.corpseback = typeof(Obj_Item_Weapon_Storage_Backpack_Industrial);
			this.corpseshoes = typeof(Obj_Item_Clothing_Shoes_Sneakers_Orange);
			this.corpsebelt = typeof(Obj_Item_Weapon_Storage_Belt_Utility_Full);
			this.corpsegloves = typeof(Obj_Item_Clothing_Gloves_Color_Yellow);
			this.corpsehelmet = typeof(Obj_Item_Clothing_Head_Hardhat);
			this.corpseid = true;
			this.corpseidjob = "Station Engineer";
			this.corpseidaccess = "Station Engineer";
		}

		public Obj_Effect_Landmark_Corpse_Engineer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}