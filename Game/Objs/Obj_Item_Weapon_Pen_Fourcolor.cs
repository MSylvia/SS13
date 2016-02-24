// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Pen_Fourcolor : Obj_Item_Weapon_Pen {

		public Obj_Item_Weapon_Pen_Fourcolor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pen.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			switch ((string)( this.colour )) {
				case "black":
					this.colour = "red";
					break;
				case "red":
					this.colour = "green";
					break;
				case "green":
					this.colour = "blue";
					break;
				default:
					this.colour = "black";
					break;
			}
			user.WriteMsg( new Txt( "<span class='notice'>" ).The( this ).item().str( " will now write in " ).item( this.colour ).str( ".</span>" ).ToString() );
			this.desc = "It's a fancy four-color ink pen, set to " + this.colour + ".";
			return null;
		}

	}

}