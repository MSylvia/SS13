// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Tapeproj_Security : Obj_Item_Tapeproj {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.tape_type = typeof(Obj_Item_Holotape_Security);
			this.icon_base = "security";
			this.icon_state = "security_start";
		}

		public Obj_Item_Tapeproj_Security ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}