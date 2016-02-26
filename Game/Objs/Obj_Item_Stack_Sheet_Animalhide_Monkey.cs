// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Animalhide_Monkey : Obj_Item_Stack_Sheet_Animalhide {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "monkey hide piece";
			this.icon_state = "sheet-monkey";
		}

		// Function from file: leather.dm
		public Obj_Item_Stack_Sheet_Animalhide_Monkey ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			this.recipes = GlobalVars.monkey_recipes;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}