// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_GlassScience : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyScience_Glass);
			this.glass = true;
			this.icon = "icons/obj/doors/airlocks/station/science.dmi";
		}

		public Obj_Machinery_Door_Airlock_GlassScience ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}