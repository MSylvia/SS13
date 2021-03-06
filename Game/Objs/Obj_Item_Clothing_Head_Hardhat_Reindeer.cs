// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Hardhat_Reindeer : Obj_Item_Clothing_Head_Hardhat {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hardhat0_reindeer";
			this.item_color = "reindeer";
			this.action_button_name = "Toggle Nose Light";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.brightness_on = 1;
			this.icon_state = "hardhat0_reindeer";
		}

		public Obj_Item_Clothing_Head_Hardhat_Reindeer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}