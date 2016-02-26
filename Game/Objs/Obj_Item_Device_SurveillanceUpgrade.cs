// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_SurveillanceUpgrade : Obj_Item_Device {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/cloning.dmi";
			this.icon_state = "datadisk0";
		}

		public Obj_Item_Device_SurveillanceUpgrade ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ai_upgrades.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( !( target is Mob_Living_Silicon_Ai ) ) {
				return false;
			}

			if ( Lang13.Bool( target.eyeobj ) ) {
				target.eyeobj.relay_speech = GlobalVars.TRUE;
				target.WriteMsg( "<span class='userdanger'>" + user + " has upgraded you with surveillance software!</span>" );
				target.WriteMsg( "Via a combination of hidden microphones and lip reading software, you are able to use your cameras to listen in on conversations." );
			}
			user.WriteMsg( "<span class='notice'>You upgrade " + target + ". " + this + " is consumed in the process.</span>" );
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}