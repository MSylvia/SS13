// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Toolbox_Drone : Obj_Item_Weapon_Storage_Toolbox {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "toolbox_blue";
			this.icon_state = "blue";
		}

		// Function from file: toolbox.dm
		public Obj_Item_Weapon_Storage_Toolbox_Drone ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic color = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			color = Rand13.Pick(new object [] { "red", "yellow", "green", "blue", "pink", "orange", "cyan", "white" });
			new Obj_Item_Weapon_Screwdriver( this );
			new Obj_Item_Weapon_Wrench( this );
			new Obj_Item_Weapon_Weldingtool( this );
			new Obj_Item_Weapon_Crowbar( this );
			new Obj_Item_Stack_CableCoil( this, 30, color );
			new Obj_Item_Weapon_Wirecutters( this );
			new Obj_Item_Device_Multitool( this );
			return;
		}

	}

}