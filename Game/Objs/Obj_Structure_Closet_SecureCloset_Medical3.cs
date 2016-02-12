// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Medical3 : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 45 });
			this.icon_closed = "securemed";
			this.icon_locked = "securemed1";
			this.icon_opened = "securemedopen";
			this.icon_broken = "securemedbroken";
			this.icon_off = "securemedoff";
			this.icon_state = "securemed1";
		}

		// Function from file: medical.dm
		public Obj_Structure_Closet_SecureCloset_Medical3 ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );
			new Obj_Item_Clothing_Monkeyclothes_Doctor( this );
			new Obj_Item_Clothing_Monkeyclothes_Doctor( this );

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_Weapon_Storage_Backpack_Medic( this );
			} else {
				new Obj_Item_Weapon_Storage_Backpack_SatchelMed( this );
			}
			new Obj_Item_Clothing_Under_Rank_Nursesuit( this );
			new Obj_Item_Clothing_Head_Nursehat( this );

			dynamic _a = Rand13.Pick(new object [] { "blue", "green", "purple" }); // Was a switch-case, sorry for the mess.
			if ( _a=="blue" ) {
				new Obj_Item_Clothing_Under_Rank_Medical_Blue( this );
				new Obj_Item_Clothing_Head_Surgery_Blue( this );
			} else if ( _a=="green" ) {
				new Obj_Item_Clothing_Under_Rank_Medical_Green( this );
				new Obj_Item_Clothing_Head_Surgery_Green( this );
			} else if ( _a=="purple" ) {
				new Obj_Item_Clothing_Under_Rank_Medical_Purple( this );
				new Obj_Item_Clothing_Head_Surgery_Purple( this );
			}

			dynamic _b = Rand13.Pick(new object [] { "blue", "green", "purple" }); // Was a switch-case, sorry for the mess.
			if ( _b=="blue" ) {
				new Obj_Item_Clothing_Under_Rank_Medical_Blue( this );
				new Obj_Item_Clothing_Head_Surgery_Blue( this );
			} else if ( _b=="green" ) {
				new Obj_Item_Clothing_Under_Rank_Medical_Green( this );
				new Obj_Item_Clothing_Head_Surgery_Green( this );
			} else if ( _b=="purple" ) {
				new Obj_Item_Clothing_Under_Rank_Medical_Purple( this );
				new Obj_Item_Clothing_Head_Surgery_Purple( this );
			}
			new Obj_Item_Clothing_Under_Rank_Medical( this );
			new Obj_Item_Clothing_Under_Rank_Nurse( this );
			new Obj_Item_Clothing_Under_Rank_Orderly( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat( this );
			new Obj_Item_Clothing_Suit_Storage_FrJacket( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Device_Radio_Headset_HeadsetMed(  );
			new Obj_Item_Weapon_Storage_Belt_Medical( this );
			return;
		}

	}

}