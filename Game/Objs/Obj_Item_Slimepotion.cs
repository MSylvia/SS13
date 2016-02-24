// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Slimepotion : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.origin_tech = "biotech=4";
		}

		public Obj_Item_Slimepotion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: xenobiology.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( target is Obj_Item_Weapon_ReagentContainers ) {
				user.WriteMsg( "<span class='notice'>You cannot transfer " + this + " to " + target + "! It appears the potion must be given directly to a slime to absorb.</span>" );
				return false;
			}
			return false;
		}

	}

}