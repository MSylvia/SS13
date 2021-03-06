// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Hardhat_Pumpkinhead : Obj_Item_Clothing_Head_Hardhat {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hardhat0_pumpkin";
			this.item_color = "pumpkin";
			this.flags = 32768;
			this.flags_inv = 15;
			this.action_button_name = "Toggle Pumpkin Light";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.brightness_on = 2;
			this.flags_cover = 4;
			this.icon_state = "hardhat0_pumpkin";
		}

		public Obj_Item_Clothing_Head_Hardhat_Pumpkinhead ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}