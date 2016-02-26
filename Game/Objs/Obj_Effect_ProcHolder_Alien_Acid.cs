// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Acid : Obj_Effect_ProcHolder_Alien {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.plasma_cost = 200;
			this.action_icon_state = "alien_acid";
		}

		public Obj_Effect_ProcHolder_Alien_Acid ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_powers.dm
		public override bool fire( Mob user = null ) {
			dynamic O = null;

			O = Interface13.Input( "Select what to dissolve:", "Dissolve", null, null, Map13.FetchInViewExcludeThis( user, 1 ), InputType.Obj | InputType.Tile );

			if ( !Lang13.Bool( O ) ) {
				return false;
			}
			return this.corrode( O, user );
		}

		// Function from file: alien_powers.dm
		public bool corrode( dynamic target = null, Mob user = null ) {
			user = user ?? Task13.User;

			dynamic I = null;
			dynamic T = null;

			
			if ( Map13.FetchInViewExcludeThis( user, 1 ).Contains( target ) ) {
				
				if ( target is Obj ) {
					I = target;

					if ( I.unacidable ) {
						user.WriteMsg( "<span class='noticealien'>You cannot dissolve this object.</span>" );
						return false;
					}
				} else if ( target is Tile_Simulated ) {
					T = target;

					if ( T is Tile_Simulated_Wall_RWall ) {
						user.WriteMsg( "<span class='noticealien'>You cannot dissolve this object.</span>" );
						return false;
					}

					if ( T is Tile_Simulated_Floor_Engine ) {
						user.WriteMsg( "<span class='noticealien'>You cannot dissolve this object.</span>" );
						return false;
					}
				} else {
					return false;
				}
				new Obj_Effect_Acid( GlobalFuncs.get_turf( target ), target );
				user.visible_message( "<span class='alertalien'>" + user + " vomits globs of vile stuff all over " + target + ". It begins to sizzle and melt under the bubbling mess of acid!</span>" );
				return true;
			} else {
				((dynamic)this).WriteMsg( "<span class='noticealien'>Target is too far away.</span>" );
				return false;
			}
		}

		// Function from file: alien_powers.dm
		public override void on_lose( Mob_Living_Carbon user = null ) {
			user.verbs.Remove( typeof(Mob_Living_Carbon).GetMethod( "corrosive_acid" ) );
			return;
		}

		// Function from file: alien_powers.dm
		public override void on_gain( Mob_Living_Carbon user = null ) {
			user.verbs.Add( typeof(Mob_Living_Carbon).GetMethod( "corrosive_acid" ) );
			return;
		}

	}

}