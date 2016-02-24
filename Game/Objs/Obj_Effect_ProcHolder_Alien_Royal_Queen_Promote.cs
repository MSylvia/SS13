// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Royal_Queen_Promote : Obj_Effect_ProcHolder_Alien_Royal_Queen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.plasma_cost = 500;
			this.action_icon_state = "alien_queen_promote";
		}

		public Obj_Effect_ProcHolder_Alien_Royal_Queen_Promote ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: queen.dm
		public override bool fire( Mob user = null ) {
			Obj_Item_Queenpromote prom = null;

			
			if ( GlobalFuncs.alien_type_present( typeof(Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian) ) ) {
				user.WriteMsg( "<span class='noticealien'>You already have a Praetorian!</span>" );
				return false;
			} else {
				
				foreach (dynamic _a in Lang13.Enumerate( user, typeof(Obj_Item_Queenpromote) )) {
					prom = _a;
					
					user.WriteMsg( "<span class='noticealien'>You discard " + prom + ".</span>" );
					GlobalFuncs.qdel( prom );
					return false;
				}
				prom = new Obj_Item_Queenpromote( user.loc );

				if ( !user.put_in_active_hand( prom ) ) {
					user.WriteMsg( "<span class='warning'>You must empty your hands before preparing the parasite.</span>" );
					return false;
				} else {
					user.WriteMsg( "<span class='noticealien'>Use the royal parasite on one of your children to promote her to Praetorian!</span>" );
				}
			}
			return false;
		}

	}

}