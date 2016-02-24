// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyPlasma : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Plasma);
			this.anchored = 1;
			this.state = 1;
			this.mineral = "plasma";
			this.icon = "icons/obj/doors/airlocks/station/plasma.dmi";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyPlasma ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}