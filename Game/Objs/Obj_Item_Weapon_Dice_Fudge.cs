// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Dice_Fudge : Obj_Item_Weapon_Dice {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.sides = 3;
			this.special_faces = new ByTable(new object [] { "minus", "blank", "plus" });
			this.icon_state = "fudge";
		}

		public Obj_Item_Weapon_Dice_Fudge ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}