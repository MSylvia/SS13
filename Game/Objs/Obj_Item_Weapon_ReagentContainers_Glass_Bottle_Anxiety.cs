// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Anxiety : Obj_Item_Weapon_ReagentContainers_Glass_Bottle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawned_disease = typeof(Disease_Anxiety);
			this.icon_state = "bottle3";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Anxiety ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}