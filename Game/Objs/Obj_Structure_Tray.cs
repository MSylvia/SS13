// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Tray : Obj_Structure {

		public Obj_Structure_Bodycontainer connected = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.pass_flags = 32;
			this.icon = "icons/obj/stationobjs.dmi";
			this.layer = 2.9;
		}

		public Obj_Structure_Tray ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: morgue.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			Ent_Static M = null;

			
			if ( !( dropping is Ent_Dynamic ) || Lang13.Bool( ((dynamic)dropping).anchored ) || !this.Adjacent( user ) || !user.Adjacent( dropping ) || dropping.loc == user ) {
				return false;
			}

			if ( !( dropping is Mob ) ) {
				
				if ( !( dropping is Obj_Structure_Closet_BodyBag ) ) {
					return false;
				}
			} else {
				M = dropping;

				if ( Lang13.Bool( ((dynamic)M).buckled ) ) {
					return false;
				}
			}

			if ( !( user is Mob ) || Lang13.Bool( user.lying ) || user.incapacitated() ) {
				return false;
			}
			dropping.loc = this.loc;

			if ( user != dropping ) {
				this.visible_message( "<span class='warning'>" + user + " stuffs " + dropping + " into " + this + ".</span>" );
			}
			return false;
		}

		// Function from file: morgue.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( this.connected != null ) {
				this.connected.close();
				this.add_fingerprint( a );
			} else {
				a.WriteMsg( "<span class='warning'>That's not connected to anything!</span>" );
			}
			return null;
		}

		// Function from file: morgue.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: morgue.dm
		public override dynamic Destroy(  ) {
			
			if ( this.connected != null ) {
				this.connected.connected = null;
				this.connected.update_icon();
				this.connected = null;
			}
			return base.Destroy();
		}

	}

}