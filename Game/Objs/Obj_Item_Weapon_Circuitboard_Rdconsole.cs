// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Rdconsole : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Computer_Rdconsole_Core);
		}

		public Obj_Item_Weapon_Circuitboard_Rdconsole ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: buildandrepair.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Screwdriver ) {
				
				if ( this.build_path == typeof(Obj_Machinery_Computer_Rdconsole_Core) ) {
					this.name = "circuit board (RD Console - Robotics)";
					this.build_path = typeof(Obj_Machinery_Computer_Rdconsole_Robotics);
					user.WriteMsg( "<span class='notice'>Access protocols successfully updated.</span>" );
				} else {
					this.name = "circuit board (RD Console)";
					this.build_path = typeof(Obj_Machinery_Computer_Rdconsole_Core);
					user.WriteMsg( "<span class='notice'>Defaulting access protocols.</span>" );
				}
			}
			return null;
		}

	}

}