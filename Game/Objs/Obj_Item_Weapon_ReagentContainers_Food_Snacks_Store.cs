// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public bool stored_item = false;

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: snacks.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( ( ( Convert.ToDouble( A.w_class ) <= 2 ?1:0) & ( !( A is Obj_Item_Weapon_ReagentContainers_Food_Snacks ) ?1:0) ) != 0 ) {
				
				if ( ((Obj_Item)A).is_sharp() != 0 ) {
					return 0;
				}

				if ( this.stored_item ) {
					return 0;
				}

				if ( !( user is Mob_Living_Carbon ) ) {
					return 0;
				}

				if ( this.contents.len >= 20 ) {
					user.WriteMsg( "<span class='warning'>" + this + " is full.</span>" );
					return 0;
				}
				user.WriteMsg( "<span class='notice'>You slip " + A + " inside " + this + ".</span>" );
				((Mob)user).unEquip( A );
				this.add_fingerprint( user );
				this.contents.Add( A );
				this.stored_item = true;
				return 1;
			}
			return null;
		}

	}

}