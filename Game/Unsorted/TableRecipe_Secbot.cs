// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Secbot : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Secbot";
			this.result = typeof(Mob_Living_SimpleAnimal_Bot_Secbot);
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Device_Assembly_Signaler), 1 )
				.Set( typeof(Obj_Item_Clothing_Head_Helmet_Sec), 1 )
				.Set( typeof(Obj_Item_Weapon_Melee_Baton), 1 )
				.Set( typeof(Obj_Item_Device_Assembly_ProxSensor), 1 )
				.Set( typeof(Obj_Item_RobotParts_RArm), 1 )
			;
			this.tools = new ByTable(new object [] { typeof(Obj_Item_Weapon_Weldingtool) });
			this.time = 60;
			this.category = "Robots";
		}

	}

}