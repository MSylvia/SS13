// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Dnainjector_Antidwarf : Obj_Item_Weapon_Dnainjector {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.remove_mutations_static = new ByTable(new object [] { "Dwarfism" });
		}

		public Obj_Item_Weapon_Dnainjector_Antidwarf ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}