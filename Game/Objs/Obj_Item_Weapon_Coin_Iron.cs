// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Coin_Iron : Obj_Item_Weapon_Coin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cmineral = "iron";
			this.value = 20;
			this.materials = new ByTable().Set( "$metal", 400 );
			this.icon_state = "coin_iron_heads";
		}

		public Obj_Item_Weapon_Coin_Iron ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}