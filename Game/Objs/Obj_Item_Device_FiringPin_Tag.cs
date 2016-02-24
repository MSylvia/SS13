// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_FiringPin_Tag : Obj_Item_Device_FiringPin {

		public Type suit_requirement = null;
		public string tagcolor = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fail_message = "<span class='warning'>SUIT CHECK FAILED.</span>";
		}

		public Obj_Item_Device_FiringPin_Tag ( dynamic newloc = null ) : base( (object)(newloc) ) {
			
		}

		// Function from file: pins.dm
		public override bool pin_auth( dynamic user = null ) {
			dynamic M = null;

			
			if ( user is Mob_Living_Carbon_Human ) {
				M = user;

				if ( Lang13.Bool( ((dynamic)this.suit_requirement).IsInstanceOfType( M.wear_suit ) ) ) {
					return true;
				}
			}
			user.WriteMsg( "<span class='warning'>You need to be wearing " + this.tagcolor + " laser tag armor!</span>" );
			return false;
		}

	}

}