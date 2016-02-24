// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Shuttle_Syndicate : Obj_Machinery_Computer_Shuttle {

		public int? challenge = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_screen = "syndishuttle";
			this.icon_keyboard = "syndie_key";
			this.req_access = new ByTable(new object [] { 150 });
			this.shuttleId = "syndicate";
			this.possible_destinations = "syndicate_away;syndicate_z5;syndicate_ne;syndicate_nw;syndicate_n;syndicate_se;syndicate_sw;syndicate_s";
		}

		public Obj_Machinery_Computer_Shuttle_Syndicate ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

		// Function from file: syndicate.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( href_list["move"] ) ) {
				
				if ( Lang13.Bool( this.challenge ) && Game13.time < 12000 ) {
					Task13.User.WriteMsg( "<span class='warning'>You've issued a combat challenge to the station! You've got to give them at least " + Num13.Floor( ( 12000 - Game13.time ) / 10 / 60 ) + " more minutes to allow them to prepare.</span>" );
					return 0;
				}
			}
			base.Topic( href, href_list, (object)(hsrc) );
			return null;
		}

	}

}