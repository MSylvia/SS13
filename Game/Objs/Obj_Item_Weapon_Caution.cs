// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Caution : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 1;
			this.throwforce = 3;
			this.throw_range = 5;
			this.w_class = 2;
			this.attack_verb = new ByTable(new object [] { "warned", "cautioned", "smashed" });
			this.icon = "icons/obj/janitor.dmi";
			this.icon_state = "caution";
		}

		public Obj_Item_Weapon_Caution ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}