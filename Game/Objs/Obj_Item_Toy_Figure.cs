// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Figure : Obj_Item_Toy {

		public int cooldown = 0;
		public string toysay = "What the fuck did you do?";
		public string toysound = "sound/machines/click.ogg";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "nuketoy";
		}

		// Function from file: toys.dm
		public Obj_Item_Toy_Figure ( dynamic loc = null ) : base( (object)(loc) ) {
			this.desc = "A \"Space Life\" brand " + this + ".";
			return;
		}

		// Function from file: toys.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.cooldown <= Game13.time ) {
				this.cooldown = Game13.time + 50;
				user.WriteMsg( "<span class='notice'>The " + this + " says \"" + this.toysay + "\"</span>" );
				GlobalFuncs.playsound( user, this.toysound, 20, 1 );
			}
			return null;
		}

	}

}