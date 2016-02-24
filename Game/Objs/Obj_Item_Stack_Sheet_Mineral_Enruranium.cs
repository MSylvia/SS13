// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Mineral_Enruranium : Obj_Item_Stack_Sheet_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "enriched uranium sheet";
			this.origin_tech = "materials=6";
			this.materials = new ByTable().Set( "$uranium", 3000 );
			this.icon_state = "sheet-enruranium";
		}

		public Obj_Item_Stack_Sheet_Mineral_Enruranium ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}