// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Sbeacondrop : Obj_Item_Device {

		public Type droptype = typeof(Obj_Machinery_Power_SingularityBeacon_Syndicate);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "bluespace=1;syndicate=7";
			this.w_class = 2;
			this.icon = "icons/obj/radio.dmi";
			this.icon_state = "beacon";
		}

		public Obj_Item_Device_Sbeacondrop ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicatebeacon.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( Lang13.Bool( user ) ) {
				user.WriteMsg( "<span class='notice'>Locked In.</span>" );
				Lang13.Call( this.droptype, user.loc );
				GlobalFuncs.playsound( this, "sound/effects/pop.ogg", 100, 1, 1 );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}