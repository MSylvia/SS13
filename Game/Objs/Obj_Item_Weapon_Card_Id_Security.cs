// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Id_Security : Obj_Item_Weapon_Card_Id {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.registered_name = "Officer";
			this.access = new ByTable(new object [] { 63, 1, 2, 3, 4, 42, 58 });
			this.icon_state = "security";
		}

		public Obj_Item_Weapon_Card_Id_Security ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}