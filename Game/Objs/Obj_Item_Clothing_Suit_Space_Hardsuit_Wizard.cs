// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Hardsuit_Wizard : Obj_Item_Clothing_Suit_Space_Hardsuit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "wiz_hardsuit";
			this.unacidable = true;
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 40 ).Set( "laser", 40 ).Set( "energy", 20 ).Set( "bomb", 35 ).Set( "bio", 100 ).Set( "rad", 50 );
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_TeleportationScroll), typeof(Obj_Item_Weapon_Tank_Internals) });
			this.max_heat_protection_temperature = 35000;
			this.helmettype = typeof(Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Wizard);
			this.icon_state = "hardsuit-wiz";
		}

		public Obj_Item_Clothing_Suit_Space_Hardsuit_Wizard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}