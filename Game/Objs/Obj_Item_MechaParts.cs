// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 6;
			this.flags = 64;
			this.origin_tech = "programming=2;materials=2";
			this.icon = "icons/mecha/mech_construct.dmi";
			this.icon_state = "blank";
		}

		public Obj_Item_MechaParts ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}