// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Engineering : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyEng);
			this.icon = "icons/obj/doors/airlocks/station/engineering.dmi";
		}

		public Obj_Machinery_Door_Airlock_Engineering ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}