// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Figure_Scientist : Obj_Item_Toy_Figure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.toysay = "For science!";
			this.toysound = "sound/effects/explosionfar.ogg";
			this.icon_state = "scientist";
		}

		public Obj_Item_Toy_Figure_Scientist ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}