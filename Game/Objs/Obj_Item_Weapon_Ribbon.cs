// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Ribbon : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot_flags = 64;
			this.throwforce = 0;
			this.w_class = 1;
			this.throw_range = 4;
			this.throw_speed = 1;
			this.icon = "icons/obj/paper.dmi";
			this.icon_state = "ribbon";
		}

		public Obj_Item_Weapon_Ribbon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}