// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bed_Dogbed : Obj_Structure_Bed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.buildstacktype = typeof(Obj_Item_Stack_Sheet_Mineral_Wood);
			this.buildstackamount = 10;
			this.icon_state = "dogbed";
		}

		public Obj_Structure_Bed_Dogbed ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}