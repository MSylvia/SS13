// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_RobotParts : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "buildpipe";
			this.flags = 64;
			this.slot_flags = 512;
			this.icon = "icons/obj/robot_parts.dmi";
			this.icon_state = "blank";
		}

		public Obj_Item_RobotParts ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}