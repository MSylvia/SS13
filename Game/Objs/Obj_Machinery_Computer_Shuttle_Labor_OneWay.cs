// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Shuttle_Labor_OneWay : Obj_Machinery_Computer_Shuttle_Labor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_destinations = "laborcamp_away";
			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_LaborShuttle_OneWay);
			this.req_access = new ByTable();
		}

		public Obj_Machinery_Computer_Shuttle_Labor_OneWay ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

		// Function from file: laborshuttle.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Obj_DockingPort_Mobile M = null;
			dynamic S = null;

			
			if ( Lang13.Bool( href_list["move"] ) ) {
				M = GlobalVars.SSshuttle.getShuttle( "laborcamp" );

				if ( !( M != null ) ) {
					Task13.User.WriteMsg( "<span class='warning'>Cannot locate shuttle!</span>" );
					return 0;
				}
				S = M.get_docked();

				if ( Lang13.Bool( S ) && S.name == "laborcamp_away" ) {
					Task13.User.WriteMsg( "<span class='warning'>Shuttle is already at the outpost!</span>" );
					return 0;
				}
			}
			base.Topic( href, href_list, (object)(hsrc) );
			return null;
		}

	}

}