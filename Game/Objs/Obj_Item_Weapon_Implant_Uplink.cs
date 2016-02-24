// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implant_Uplink : Obj_Item_Weapon_Implant {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=2;magnets=4;programming=4;biotech=4;syndicate=8;bluespace=5";
			this.icon = "icons/obj/radio.dmi";
			this.icon_state = "radio";
		}

		// Function from file: implantuplink.dm
		public Obj_Item_Weapon_Implant_Uplink ( dynamic loc = null ) : base( (object)(loc) ) {
			this.hidden_uplink = new Obj_Item_Device_Uplink( this );
			this.hidden_uplink.telecrystals = 10;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: implantuplink.dm
		public override bool activate( dynamic cause = null ) {
			
			if ( this.hidden_uplink != null ) {
				this.hidden_uplink.interact( Task13.User );
			}
			return false;
		}

		// Function from file: implantuplink.dm
		public override int implant( dynamic source = null, dynamic user = null ) {
			dynamic imp_e = null;

			imp_e = Lang13.FindIn( this.type, source );

			if ( Lang13.Bool( imp_e ) && imp_e != this ) {
				imp_e.hidden_uplink.telecrystals += this.hidden_uplink.telecrystals;
				GlobalFuncs.qdel( this );
				return 1;
			}

			if ( base.implant( (object)(source), (object)(user) ) != 0 ) {
				this.hidden_uplink.owner = "" + source.key;
				return 1;
			}
			return 0;
		}

	}

}