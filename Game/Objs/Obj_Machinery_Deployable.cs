// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Deployable : Obj_Machinery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 1 });
			this.icon = "icons/obj/objects.dmi";
		}

		public Obj_Machinery_Deployable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}